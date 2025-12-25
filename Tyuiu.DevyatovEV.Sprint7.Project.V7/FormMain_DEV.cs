using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tyuiu.DevyatovEV.Sprint7.Project.V7.Lib;

namespace Tyuiu.DevyatovEV.Sprint7.Project.V7
{
    public partial class FormMain_DEV : Form
    {
        // СОЗДАЕМ ЭКЗЕМПЛЯР DataService_DEV
        private readonly DataService_DEV dataService_DEV = new DataService_DEV();
        private DataTable table_DEV;
        private DataView view_DEV;

        private const string CsvPath = @"C:\Users\Egor\source\repos\Tyuiu.DevyatovEV.Sprint7\Data\HousingManagement.csv";

        // Кнопки (добавлены как поля класса)
        private Button Add_DEV;
        private Button Delete_DEV;
        private Button Graph_DEV;
        private Button About_DEV;
        private Button Guide_DEV;

        public FormMain_DEV()
        {
            InitializeComponent();
            LoadData_DEV();
            ConfigureDataGridViewForEditing();
        }

        private void LoadData_DEV()
        {
            try
            {
                // СОЗДАЕМ ПАПКУ И ФАЙЛ ЕСЛИ ИХ НЕТ
                string directory = Path.GetDirectoryName(CsvPath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                if (!File.Exists(CsvPath))
                {
                    // СОЗДАЕМ ПУСТОЙ ФАЙЛ С ЗАГОЛОВКАМИ
                    File.WriteAllText(CsvPath, "НомерПодъезда,НомерКвартиры,ОбщаяПлощадь,ЖилаяПлощадь,КоличествоКомнат,Фамилия,ДатаРегистрации,ЧленовСемьи,КоличествоДетей,НаличиеДолга,Примечание\n", Encoding.UTF8);
                }

                // ИСПОЛЬЗУЕМ ЭКЗЕМПЛЯР dataService_DEV ДЛЯ ЗАГРУЗКИ
                table_DEV = dataService_DEV.LoadFromCsv_DEV(CsvPath);
                view_DEV = new DataView(table_DEV);
                dataGridViewBase_DEV.DataSource = view_DEV;
                SetColumnHeaders_DEV();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridViewForEditing()
        {
            // КРИТИЧЕСКИ ВАЖНО: Настройка DataGridView для редактирования
            dataGridViewBase_DEV.ReadOnly = false;
            dataGridViewBase_DEV.AllowUserToAddRows = false;
            dataGridViewBase_DEV.AllowUserToDeleteRows = true;
            dataGridViewBase_DEV.EditMode = DataGridViewEditMode.EditOnEnter;

            // Разрешаем редактирование всех ячеек
            foreach (DataGridViewColumn column in dataGridViewBase_DEV.Columns)
            {
                column.ReadOnly = false;
            }

            // Подписываемся на событие окончания редактирования
            dataGridViewBase_DEV.CellEndEdit += DataGridViewBase_DEV_CellEndEdit;
        }

        private void SetColumnHeaders_DEV()
        {
            if (dataGridViewBase_DEV.Columns.Contains("EntranceNumber"))
                dataGridViewBase_DEV.Columns["EntranceNumber"].HeaderText = "Подъезд";
            if (dataGridViewBase_DEV.Columns.Contains("ApartmentNumber"))
                dataGridViewBase_DEV.Columns["ApartmentNumber"].HeaderText = "Квартира";
            if (dataGridViewBase_DEV.Columns.Contains("TotalArea"))
                dataGridViewBase_DEV.Columns["TotalArea"].HeaderText = "Общая площадь";
            if (dataGridViewBase_DEV.Columns.Contains("LivingArea"))
                dataGridViewBase_DEV.Columns["LivingArea"].HeaderText = "Жилая площадь";
            if (dataGridViewBase_DEV.Columns.Contains("RoomsCount"))
                dataGridViewBase_DEV.Columns["RoomsCount"].HeaderText = "Комнаты";
            if (dataGridViewBase_DEV.Columns.Contains("TenantLastName"))
                dataGridViewBase_DEV.Columns["TenantLastName"].HeaderText = "Фамилия";
            if (dataGridViewBase_DEV.Columns.Contains("RegistrationDate"))
                dataGridViewBase_DEV.Columns["RegistrationDate"].HeaderText = "Дата";
            if (dataGridViewBase_DEV.Columns.Contains("FamilyMembers"))
                dataGridViewBase_DEV.Columns["FamilyMembers"].HeaderText = "Семья";
            if (dataGridViewBase_DEV.Columns.Contains("ChildrenCount"))
                dataGridViewBase_DEV.Columns["ChildrenCount"].HeaderText = "Дети";
            if (dataGridViewBase_DEV.Columns.Contains("HasDebt"))
                dataGridViewBase_DEV.Columns["HasDebt"].HeaderText = "Долг";
            if (dataGridViewBase_DEV.Columns.Contains("Note"))
                dataGridViewBase_DEV.Columns["Note"].HeaderText = "Примечание";
        }

        private FilterState_DEV filterState_DEV = new FilterState_DEV();

        // ===== РЕАЛИТИМ-ТАЙМ РЕДАКТИРОВАНИЕ =====

        private void DataGridViewBase_DEV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try
                {
                    // Получаем измененную ячейку
                    var cell = dataGridViewBase_DEV.Rows[e.RowIndex].Cells[e.ColumnIndex];

                    // Получаем соответствующую строку в DataTable
                    DataRowView rowView = (DataRowView)dataGridViewBase_DEV.Rows[e.RowIndex].DataBoundItem;
                    DataRow row = rowView.Row;

                    // Обновляем значение в DataTable
                    string columnName = dataGridViewBase_DEV.Columns[e.ColumnIndex].DataPropertyName;
                    row[columnName] = cell.Value ?? DBNull.Value;

                    // Сохраняем изменения в файл
                    dataService_DEV.SaveToCsv_DEV(CsvPath, table_DEV);

                    // Показываем сообщение об успешном сохранении (опционально)
                    // MessageBox.Show("Изменения сохранены!", "Успех", 
                    //     MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ===== ОБРАБОТЧИКИ ДЛЯ КНОПОК =====

        // Кнопка Добавить (Add_DEV)
        private void buttonAdd_DEV_Click(object sender, EventArgs e)
        {
            var form = new FormEdit_DEV(table_DEV);
            if (form.ShowDialog() == DialogResult.OK)
            {
                table_DEV.Rows.Add(form.RowResult);
                // ИСПОЛЬЗУЕМ ЭКЗЕМПЛЯР dataService_DEV ДЛЯ СОХРАНЕНИЯ
                dataService_DEV.SaveToCsv_DEV(CsvPath, table_DEV);

                // Обновляем DataView
                view_DEV = new DataView(table_DEV);
                dataGridViewBase_DEV.DataSource = view_DEV;
                ConfigureDataGridViewForEditing();

                MessageBox.Show("Запись успешно добавлена!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Кнопка Удалить (Delete_DEV)
        private void buttonDelete_DEV_Click(object sender, EventArgs e)
        {
            if (dataGridViewBase_DEV.CurrentRow == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataRow row =
                ((DataRowView)dataGridViewBase_DEV.CurrentRow.DataBoundItem).Row;

            if (MessageBox.Show("Удалить выбранную запись?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                table_DEV.Rows.Remove(row);
                // ИСПОЛЬЗУЕМ ЭКЗЕМПЛЯР dataService_DEV ДЛЯ СОХРАНЕНИЯ
                dataService_DEV.SaveToCsv_DEV(CsvPath, table_DEV);

                // Обновляем DataView
                view_DEV = new DataView(table_DEV);
                dataGridViewBase_DEV.DataSource = view_DEV;
                ConfigureDataGridViewForEditing();

                MessageBox.Show("Запись успешно удалена!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Кнопка График (Graph_DEV) - замена MenuChart_DEV
        private void buttonGraph_DEV_Click(object sender, EventArgs e)
        {
            new FormChart_DEV(table_DEV).ShowDialog();
        }

        // Кнопка Руководство (Guide_DEV) - замена MenuManual_DEV
        private void buttonGuide_DEV_Click(object sender, EventArgs e)
        {
            new FormHelp_DEV().ShowDialog();
        }

        // Кнопка О программе (About_DEV) - замена MenuAbout_DEV
        private void buttonAbout_DEV_Click(object sender, EventArgs e)
        {
            new FormAbout_DEV().ShowDialog();
        }

        // ===== СУЩЕСТВУЮЩИЕ ОБРАБОТЧИКИ =====

        private void TextSearch_DEV_TextChanged(object sender, EventArgs e)
        {
            string text = textBoxSearch_DEV.Text.Trim().Replace("'", "''");
            view_DEV.RowFilter = string.IsNullOrEmpty(text)
                ? ""
                : $"TenantLastName LIKE '%{text}%'";
        }

        private void BtnResetSearch_DEV_Click(object sender, EventArgs e)
        {
            textBoxSearch_DEV.Text = "";
            view_DEV.RowFilter = "";
        }

        private void MenuStatistics_DEV_Click(object sender, EventArgs e)
        {
            if (view_DEV.Count == 0)
            {
                MessageBox.Show("Нет данных для анализа", "Статистика",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var areas = view_DEV.Cast<DataRowView>()
                .Select(r => Convert.ToDouble(r["TotalArea"]))
                .ToList();

            double maxArea = areas.Max();
            double minArea = areas.Min();
            double avgArea = areas.Average();

            var families = view_DEV.Cast<DataRowView>()
                .Select(r => new
                {
                    LastName = r["TenantLastName"].ToString(),
                    Family = Convert.ToInt32(r["FamilyMembers"])
                })
                .OrderByDescending(x => x.Family)
                .First();

            string statText =
$@"СТАТИСТИКА ПО ТЕКУЩЕЙ ТАБЛИЦЕ

Количество записей: {view_DEV.Count}

ОБЩАЯ ПЛОЩАДЬ:
Максимальная: {maxArea} м²
Минимальная: {minArea} м²
Средняя: {avgArea:F2} м²

МНОГОДЕТНАЯ СЕМЬЯ:
Фамилия: {families.LastName}
Количество членов семьи: {families.Family}
";

            var result = MessageBox.Show(
                statText + "\nСохранить статистику в файл?",
                "Статистика",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "TXT файлы (*.txt)|*.txt";
                sfd.FileName = $"статистика_{DateTime.Now:yyyy-MM-dd}.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, statText, Encoding.UTF8);
                    MessageBox.Show("Статистика сохранена",
                        "Готово",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void MenuExport_DEV_Click(object sender, EventArgs e)
        {
            using SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV файлы (*.csv)|*.csv";
            sfd.FileName = $"таблица_домоуправление_{DateTime.Now:yyyy-MM-dd}.csv";

            if (sfd.ShowDialog() != DialogResult.OK) return;

            StringBuilder sb = new StringBuilder();

            // Заголовки
            for (int i = 0; i < view_DEV.Table.Columns.Count; i++)
            {
                sb.Append(view_DEV.Table.Columns[i].ColumnName);
                if (i < view_DEV.Table.Columns.Count - 1)
                    sb.Append(",");
            }
            sb.AppendLine();

            // Данные
            foreach (DataRowView row in view_DEV)
            {
                for (int i = 0; i < view_DEV.Table.Columns.Count; i++)
                {
                    sb.Append(row[i]);
                    if (i < view_DEV.Table.Columns.Count - 1)
                        sb.Append(",");
                }
                sb.AppendLine();
            }

            File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
            MessageBox.Show("Экспорт завершён", "Готово",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MenuFilter_DEV_Click(object sender, EventArgs e)
        {
            var form = new FormFilter_DEV(filterState_DEV);

            if (form.ShowDialog() == DialogResult.OK)
            {
                view_DEV.RowFilter = form.ResultFilter;
            }
        }

        private void MenuEdit_DEV_Click(object sender, EventArgs e)
        {
            if (dataGridViewBase_DEV.CurrentRow == null) return;

            DataRow row =
                ((DataRowView)dataGridViewBase_DEV.CurrentRow.DataBoundItem).Row;

            var form = new FormEdit_DEV(table_DEV, row);
            if (form.ShowDialog() == DialogResult.OK)
            {
                // ИСПОЛЬЗУЕМ ЭКЗЕМПЛЯР dataService_DEV ДЛЯ СОХРАНЕНИЯ
                dataService_DEV.SaveToCsv_DEV(CsvPath, table_DEV);
                MessageBox.Show("Запись успешно обновлена!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MenuExit_DEV_Click(object sender, EventArgs e) => Close();

        // ===== ФУНКЦИОНАЛ ЗАГРУЗКИ ИЗ ФАЙЛА =====

        private void buttonLoadData_DEV_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.Title = "Выберите файл данных";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string openFilePath = openFileDialog.FileName;

                        // Загружаем данные из выбранного файла
                        DataTable newTable = dataService_DEV.LoadFromCsv_DEV(openFilePath);

                        // Обновляем текущую таблицу
                        table_DEV.Clear();
                        foreach (DataRow row in newTable.Rows)
                        {
                            table_DEV.ImportRow(row);
                        }

                        // Обновляем DataView
                        view_DEV = new DataView(table_DEV);
                        dataGridViewBase_DEV.DataSource = view_DEV;

                        // Настраиваем заголовки
                        SetColumnHeaders_DEV();
                        ConfigureDataGridViewForEditing();

                        // Сохраняем в основной файл
                        dataService_DEV.SaveToCsv_DEV(CsvPath, table_DEV);

                        MessageBox.Show($"Данные успешно загружены из файла!\n{openFilePath}", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // НЕИЗМЕНЕННЫЕ МЕТОДЫ
        private void panelSearch_DEV_Paint(object sender, PaintEventArgs e) { }

        // Старые обработчики
        private void button1_Click(object sender, EventArgs e)
        {
            buttonAdd_DEV_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonDelete_DEV_Click(sender, e);
        }

        private void labelSearch_DEV_Click(object sender, EventArgs e) { }
    }
}
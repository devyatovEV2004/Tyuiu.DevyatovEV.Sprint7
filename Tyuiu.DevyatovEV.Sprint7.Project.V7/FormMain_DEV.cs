using System;
using System.Data;
using System.Diagnostics;
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
        private const string ManualPath = @"C:\Users\Egor\source\repos\Tyuiu.DevyatovEV.Sprint7\Data\Руководство_пользователя.txt";

        public FormMain_DEV()
        {
            InitializeComponent();
            LoadData_DEV();
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

        private void MenuManual_DEV_Click(object sender, EventArgs e)
        {
            if (!File.Exists(ManualPath))
            {
                MessageBox.Show("Файл руководства не найден",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = ManualPath,
                UseShellExecute = true
            });
        }

        private void MenuChart_DEV_Click(object sender, EventArgs e)
        {
            new FormChart_DEV(table_DEV).ShowDialog();
        }

        private FilterState_DEV filterState_DEV = new FilterState_DEV();

        private void MenuFilter_DEV_Click(object sender, EventArgs e)
        {
            var form = new FormFilter_DEV(filterState_DEV);

            if (form.ShowDialog() == DialogResult.OK)
            {
                view_DEV.RowFilter = form.ResultFilter;
            }
        }

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

        private void MenuAdd_DEV_Click(object sender, EventArgs e)
        {
            var form = new FormEdit_DEV(table_DEV);
            if (form.ShowDialog() == DialogResult.OK)
            {
                table_DEV.Rows.Add(form.RowResult);
                // ИСПОЛЬЗУЕМ ЭКЗЕМПЛЯР dataService_DEV ДЛЯ СОХРАНЕНИЯ
                dataService_DEV.SaveToCsv_DEV(CsvPath, table_DEV);
                MessageBox.Show("Запись успешно добавлена!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void MenuDelete_DEV_Click(object sender, EventArgs e)
        {
            if (dataGridViewBase_DEV.CurrentRow == null) return;

            DataRow row =
                ((DataRowView)dataGridViewBase_DEV.CurrentRow.DataBoundItem).Row;

            if (MessageBox.Show("Удалить запись?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                table_DEV.Rows.Remove(row);
                // ИСПОЛЬЗУЕМ ЭКЗЕМПЛЯР dataService_DEV ДЛЯ СОХРАНЕНИЯ
                dataService_DEV.SaveToCsv_DEV(CsvPath, table_DEV);
                MessageBox.Show("Запись успешно удалена!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MenuExit_DEV_Click(object sender, EventArgs e) => Close();

        private void MenuAbout_DEV_Click(object sender, EventArgs e)
            => new FormAbout_DEV().ShowDialog();
    }
}
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Tyuiu.DevyatovEV.Sprint7.Project.V7.Lib
{
    public class DataService_DEV
    {
        /// <summary>
        /// Загружает данные из CSV файла в DataTable
        /// </summary>
        /// <param name="path">Путь к CSV файлу</param>
        /// <returns>DataTable с данными</returns>
        public DataTable LoadFromCsv_DEV(string path)
        {
            DataTable table = new DataTable();

            // Создаем колонки
            table.Columns.Add("EntranceNumber", typeof(int));
            table.Columns.Add("ApartmentNumber", typeof(int));
            table.Columns.Add("TotalArea", typeof(double));
            table.Columns.Add("LivingArea", typeof(double));
            table.Columns.Add("RoomsCount", typeof(int));
            table.Columns.Add("TenantLastName", typeof(string));
            table.Columns.Add("RegistrationDate", typeof(string));
            table.Columns.Add("FamilyMembers", typeof(int));
            table.Columns.Add("ChildrenCount", typeof(int));
            table.Columns.Add("HasDebt", typeof(string));
            table.Columns.Add("Note", typeof(string));

            // Проверяем существование файла
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файл не найден: {path}");
            }

            try
            {
                // Читаем все строки из файла
                string[] lines = File.ReadAllLines(path, Encoding.UTF8);

                // Пропускаем первую строку, если она содержит заголовки
                bool hasHeader = lines.Length > 0 && !char.IsDigit(lines[0].Trim()[0]);
                int startLine = hasHeader ? 1 : 0;

                for (int i = startLine; i < lines.Length; i++)
                {
                    string line = lines[i].Trim();
                    if (string.IsNullOrEmpty(line)) continue;

                    var parts = line.Split(',');

                    // Проверяем корректное количество полей
                    if (parts.Length < 11)
                    {
                        // Дополняем недостающие поля пустыми значениями
                        parts = parts.Concat(Enumerable.Repeat("", 11 - parts.Length)).ToArray();
                    }

                    table.Rows.Add(
                        SafeParseInt(parts[0]),
                        SafeParseInt(parts[1]),
                        SafeParseDouble(parts[2]),
                        SafeParseDouble(parts[3]),
                        SafeParseInt(parts[4]),
                        parts[5]?.Trim() ?? "",
                        parts[6]?.Trim() ?? DateTime.Now.ToString("yyyy-MM-dd"),
                        SafeParseInt(parts[7]),
                        SafeParseInt(parts[8]),
                        (parts[9]?.Trim()?.ToLower() == "да" || parts[9]?.Trim()?.ToLower() == "true") ? "да" : "нет",
                        parts[10]?.Trim() ?? "-"
                    );
                }

                return table;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка загрузки данных из файла {path}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Сохраняет DataTable в CSV файл
        /// </summary>
        /// <param name="path">Путь для сохранения файла</param>
        /// <param name="table">DataTable с данными</param>
        public void SaveToCsv_DEV(string path, DataTable table)
        {
            try
            {
                var sb = new StringBuilder();

                // Добавляем заголовки
                sb.AppendLine("НомерПодъезда,НомерКвартиры,ОбщаяПлощадь,ЖилаяПлощадь,КоличествоКомнат,Фамилия,ДатаРегистрации,ЧленовСемьи,КоличествоДетей,НаличиеДолга,Примечание");

                foreach (DataRow row in table.Rows)
                {
                    sb.AppendLine(string.Join(",",
                        row["EntranceNumber"],
                        row["ApartmentNumber"],
                        ((double)row["TotalArea"]).ToString("F2", CultureInfo.InvariantCulture),
                        ((double)row["LivingArea"]).ToString("F2", CultureInfo.InvariantCulture),
                        row["RoomsCount"],
                        EscapeString(row["TenantLastName"].ToString()),
                        row["RegistrationDate"],
                        row["FamilyMembers"],
                        row["ChildrenCount"],
                        row["HasDebt"],
                        EscapeString(row["Note"].ToString())
                    ));
                }

                // Создаем директорию, если она не существует
                string directory = Path.GetDirectoryName(path);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка сохранения данных в файл {path}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Создает пустую таблицу с правильной структурой
        /// </summary>
        /// <returns>Пустой DataTable с колонками</returns>
        public DataTable CreateEmptyTable_DEV()
        {
            DataTable table = new DataTable();

            table.Columns.Add("EntranceNumber", typeof(int));
            table.Columns.Add("ApartmentNumber", typeof(int));
            table.Columns.Add("TotalArea", typeof(double));
            table.Columns.Add("LivingArea", typeof(double));
            table.Columns.Add("RoomsCount", typeof(int));
            table.Columns.Add("TenantLastName", typeof(string));
            table.Columns.Add("RegistrationDate", typeof(string));
            table.Columns.Add("FamilyMembers", typeof(int));
            table.Columns.Add("ChildrenCount", typeof(int));
            table.Columns.Add("HasDebt", typeof(string));
            table.Columns.Add("Note", typeof(string));

            return table;
        }

        /// <summary>
        /// Добавляет новую запись в таблицу
        /// </summary>
        public DataRow AddNewRecord_DEV(DataTable table, int entrance, int apartment,
            double totalArea, double livingArea, int rooms, string lastName,
            DateTime registrationDate, int familyMembers, int childrenCount,
            bool hasDebt, string note)
        {
            DataRow row = table.NewRow();

            row["EntranceNumber"] = entrance;
            row["ApartmentNumber"] = apartment;
            row["TotalArea"] = totalArea;
            row["LivingArea"] = livingArea;
            row["RoomsCount"] = rooms;
            row["TenantLastName"] = lastName;
            row["RegistrationDate"] = registrationDate.ToString("yyyy-MM-dd");
            row["FamilyMembers"] = familyMembers;
            row["ChildrenCount"] = childrenCount;
            row["HasDebt"] = hasDebt ? "да" : "нет";
            row["Note"] = note;

            table.Rows.Add(row);
            return row;
        }

        /// <summary>
        /// Проверяет, существует ли квартира в базе
        /// </summary>
        public bool ApartmentExists_DEV(DataTable table, int entrance, int apartment)
        {
            foreach (DataRow row in table.Rows)
            {
                if ((int)row["EntranceNumber"] == entrance &&
                    (int)row["ApartmentNumber"] == apartment)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Получает статистику по данным
        /// </summary>
        public string GetStatistics_DEV(DataTable table)
        {
            if (table.Rows.Count == 0)
                return "Нет данных для анализа";

            int totalApartments = table.Rows.Count;
            int totalResidents = table.AsEnumerable().Sum(row => (int)row["FamilyMembers"]);
            int totalChildren = table.AsEnumerable().Sum(row => (int)row["ChildrenCount"]);
            double avgArea = table.AsEnumerable().Average(row => (double)row["TotalArea"]);
            int apartmentsWithDebt = table.AsEnumerable().Count(row => row["HasDebt"].ToString() == "да");

            return $@"СТАТИСТИКА БАЗЫ ДАННЫХ:

Общее количество квартир: {totalApartments}
Общее количество жильцов: {totalResidents}
Общее количество детей: {totalChildren}
Средняя площадь квартиры: {avgArea:F2} м²
Квартир с задолженностью: {apartmentsWithDebt}
Квартир без задолженности: {totalApartments - apartmentsWithDebt}";
        }

        #region Вспомогательные методы

        private int SafeParseInt(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0;
            if (int.TryParse(value, out int result)) return result;
            return 0;
        }

        private double SafeParseDouble(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0.0;

            // Пробуем разные форматы чисел
            value = value.Replace(',', '.');
            if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
                return result;

            return 0.0;
        }

        private string EscapeString(string value)
        {
            if (string.IsNullOrEmpty(value)) return "";

            // Экранируем точку с запятой и кавычки
            return value.Replace(";", ",").Replace("\"", "'");
        }

        #endregion
    }

    /// <summary>
    /// Класс для хранения состояния фильтров
    /// </summary>
    public class FilterState_DEV
    {
        public decimal EntranceFrom { get; set; } = 0;
        public decimal EntranceTo { get; set; } = 0;
        public decimal ApartmentFrom { get; set; } = 0;
        public decimal ApartmentTo { get; set; } = 0;
        public decimal TotalFrom { get; set; } = 0;
        public decimal TotalTo { get; set; } = 0;
        public decimal LivingFrom { get; set; } = 0;
        public decimal LivingTo { get; set; } = 0;
        public decimal RoomsFrom { get; set; } = 0;
        public decimal RoomsTo { get; set; } = 0;
        public decimal FamilyFrom { get; set; } = 0;
        public decimal FamilyTo { get; set; } = 0;
        public decimal ChildrenFrom { get; set; } = 0;
        public decimal ChildrenTo { get; set; } = 0;

        public string LastName { get; set; } = "";
        public string Note { get; set; } = "";

        public bool UseDate { get; set; } = false;
        public DateTime DateFrom { get; set; } = DateTime.Now.AddYears(-1);
        public DateTime DateTo { get; set; } = DateTime.Now;

        public bool DebtYes { get; set; } = false;
        public bool DebtNo { get; set; } = false;

        /// <summary>
        /// Сбрасывает все фильтры к значениям по умолчанию
        /// </summary>
        public void Reset()
        {
            EntranceFrom = 0;
            EntranceTo = 0;
            ApartmentFrom = 0;
            ApartmentTo = 0;
            TotalFrom = 0;
            TotalTo = 0;
            LivingFrom = 0;
            LivingTo = 0;
            RoomsFrom = 0;
            RoomsTo = 0;
            FamilyFrom = 0;
            FamilyTo = 0;
            ChildrenFrom = 0;
            ChildrenTo = 0;
            LastName = "";
            Note = "";
            UseDate = false;
            DateFrom = DateTime.Now.AddYears(-1);
            DateTo = DateTime.Now;
            DebtYes = false;
            DebtNo = false;
        }

        /// <summary>
        /// Проверяет, активны ли какие-либо фильтры
        /// </summary>
        public bool HasActiveFilters()
        {
            return EntranceFrom > 0 || EntranceTo > 0 ||
                   ApartmentFrom > 0 || ApartmentTo > 0 ||
                   TotalFrom > 0 || TotalTo > 0 ||
                   LivingFrom > 0 || LivingTo > 0 ||
                   RoomsFrom > 0 || RoomsTo > 0 ||
                   FamilyFrom > 0 || FamilyTo > 0 ||
                   ChildrenFrom > 0 || ChildrenTo > 0 ||
                   !string.IsNullOrWhiteSpace(LastName) ||
                   !string.IsNullOrWhiteSpace(Note) ||
                   UseDate || DebtYes || DebtNo;
        }
    }
}
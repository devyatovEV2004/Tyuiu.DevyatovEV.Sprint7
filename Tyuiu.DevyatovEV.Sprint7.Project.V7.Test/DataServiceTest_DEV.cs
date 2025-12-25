using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using Tyuiu.DevyatovEV.Sprint7.Project.V7.Lib;

namespace Tyuiu.DevyatovEV.Sprint7.Project.V7.Test
{
    [TestClass]
    public sealed class DataServiceTest_DEV
    {
        private string testFilePath = null!;
        private string outFilePath = null!;

        [TestInitialize]
        public void Setup()
        {
            // Создаем временные файлы для тестов
            testFilePath = Path.Combine(
                Path.GetTempPath(),
                $"test_{Guid.NewGuid()}.csv");

            outFilePath = Path.Combine(
                Path.GetTempPath(),
                $"output_{Guid.NewGuid()}.csv");

            // Создаем тестовый CSV файл с разделителем ;
            File.WriteAllText(testFilePath,
                "НомерПодъезда;НомерКвартиры;ОбщаяПлощадь;ЖилаяПлощадь;КоличествоКомнат;Фамилия;ДатаРегистрации;ЧленовСемьи;КоличествоДетей;НаличиеДолга;Примечание\n" +
                "1;1;45.6;32.4;2;Иванов;2015-03-12;3;1;нет;—\n" +
                "2;5;60.0;40.0;3;Петров;2012-06-25;4;2;да;Долг за коммуналку\n" +
                "3;12;85.5;60.2;4;Сидоров;2020-01-15;5;3;нет;Многодетная семья\n" +
                "1;3;33.3;25.0;1;Кузнецов;2018-11-30;2;0;да;Временно не проживает",
                Encoding.UTF8);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Удаляем временные файлы после тестов
            try
            {
                if (File.Exists(testFilePath))
                    File.Delete(testFilePath);

                if (File.Exists(outFilePath))
                    File.Delete(outFilePath);
            }
            catch
            {
                // Игнорируем ошибки удаления файлов
            }
        }

        [TestMethod]
        public void LoadFromCsv_DEV_ReturnsCorrectTable()
        {
            // Arrange
            var service = new DataService_DEV();

            // Act
            DataTable table = service.LoadFromCsv_DEV(testFilePath);

            // Assert
            Assert.IsNotNull(table);
            Assert.AreEqual(4, table.Rows.Count);

            // Проверяем структуру таблицы
            Assert.AreEqual(11, table.Columns.Count);
            Assert.AreEqual("EntranceNumber", table.Columns[0].ColumnName);
            Assert.AreEqual("ApartmentNumber", table.Columns[1].ColumnName);
            Assert.AreEqual("TotalArea", table.Columns[2].ColumnName);
            Assert.AreEqual("LivingArea", table.Columns[3].ColumnName);
            Assert.AreEqual("RoomsCount", table.Columns[4].ColumnName);
            Assert.AreEqual("TenantLastName", table.Columns[5].ColumnName);
            Assert.AreEqual("RegistrationDate", table.Columns[6].ColumnName);
            Assert.AreEqual("FamilyMembers", table.Columns[7].ColumnName);
            Assert.AreEqual("ChildrenCount", table.Columns[8].ColumnName);
            Assert.AreEqual("HasDebt", table.Columns[9].ColumnName);
            Assert.AreEqual("Note", table.Columns[10].ColumnName);
        }

        [TestMethod]
        public void LoadFromCsv_DEV_CorrectDataParsing()
        {
            // Arrange
            var service = new DataService_DEV();

            // Act
            DataTable table = service.LoadFromCsv_DEV(testFilePath);

            // Assert
            DataRow firstRow = table.Rows[0];
            Assert.AreEqual(1, firstRow["EntranceNumber"]);
            Assert.AreEqual(1, firstRow["ApartmentNumber"]);
            Assert.AreEqual(45.6, (double)firstRow["TotalArea"], 0.001);
            Assert.AreEqual(32.4, (double)firstRow["LivingArea"], 0.001);
            Assert.AreEqual(2, firstRow["RoomsCount"]);
            Assert.AreEqual("Иванов", firstRow["TenantLastName"]);
            Assert.AreEqual("2015-03-12", firstRow["RegistrationDate"]);
            Assert.AreEqual(3, firstRow["FamilyMembers"]);
            Assert.AreEqual(1, firstRow["ChildrenCount"]);
            Assert.AreEqual("нет", firstRow["HasDebt"]);
            Assert.AreEqual("—", firstRow["Note"]);
        }

        [TestMethod]
        public void SaveToCsv_DEV_CreatesValidCsvFile()
        {
            // Arrange
            var service = new DataService_DEV();
            DataTable table = service.LoadFromCsv_DEV(testFilePath);

            // Act
            service.SaveToCsv_DEV(outFilePath, table);

            // Assert
            Assert.IsTrue(File.Exists(outFilePath), "Файл не был создан");

            string[] lines = File.ReadAllLines(outFilePath, Encoding.UTF8);
            Assert.AreEqual(5, lines.Length, "Неверное количество строк в файле"); // 1 заголовок + 4 данных

            // Проверяем заголовок
            string[] headers = lines[0].Split(';');
            Assert.AreEqual("НомерПодъезда", headers[0]);
            Assert.AreEqual("НомерКвартиры", headers[1]);
            Assert.AreEqual("ОбщаяПлощадь", headers[2]);

            // Проверяем первую строку данных
            string[] firstDataRow = lines[1].Split(';');
            Assert.AreEqual("1", firstDataRow[0]);
            Assert.AreEqual("1", firstDataRow[1]);
            Assert.AreEqual("45.60", firstDataRow[2]); // Форматирование до 2 знаков
        }

        [TestMethod]
        public void LoadSaveLoad_DEV_PreservesRowCount()
        {
            // Arrange
            var service = new DataService_DEV();

            // Act
            DataTable table1 = service.LoadFromCsv_DEV(testFilePath);
            service.SaveToCsv_DEV(outFilePath, table1);
            DataTable table2 = service.LoadFromCsv_DEV(outFilePath);

            // Assert
            Assert.AreEqual(table1.Rows.Count, table2.Rows.Count, "Количество строк не совпадает");
        }

        [TestMethod]
        public void LoadSaveLoad_DEV_PreservesDataIntegrity()
        {
            // Arrange
            var service = new DataService_DEV();

            // Act
            DataTable table1 = service.LoadFromCsv_DEV(testFilePath);
            service.SaveToCsv_DEV(outFilePath, table1);
            DataTable table2 = service.LoadFromCsv_DEV(outFilePath);

            // Assert
            for (int i = 0; i < table1.Rows.Count; i++)
            {
                DataRow row1 = table1.Rows[i];
                DataRow row2 = table2.Rows[i];

                Assert.AreEqual(row1["EntranceNumber"], row2["EntranceNumber"], $"Строка {i}: не совпадает подъезд");
                Assert.AreEqual(row1["ApartmentNumber"], row2["ApartmentNumber"], $"Строка {i}: не совпадает квартира");
                Assert.AreEqual((double)row1["TotalArea"], (double)row2["TotalArea"], 0.001, $"Строка {i}: не совпадает площадь");
                Assert.AreEqual(row1["TenantLastName"], row2["TenantLastName"], $"Строка {i}: не совпадает фамилия");
            }
        }

        [TestMethod]
        public void CreateEmptyTable_DEV_ReturnsCorrectStructure()
        {
            // Arrange
            var service = new DataService_DEV();

            // Act
            DataTable table = service.CreateEmptyTable_DEV();

            // Assert
            Assert.IsNotNull(table);
            Assert.AreEqual(0, table.Rows.Count);
            Assert.AreEqual(11, table.Columns.Count);
            Assert.AreEqual(typeof(int), table.Columns["EntranceNumber"].DataType);
            Assert.AreEqual(typeof(double), table.Columns["TotalArea"].DataType);
            Assert.AreEqual(typeof(string), table.Columns["TenantLastName"].DataType);
        }

        [TestMethod]
        public void AddNewRecord_DEV_AddsCorrectData()
        {
            // Arrange
            var service = new DataService_DEV();
            DataTable table = service.CreateEmptyTable_DEV();

            DateTime testDate = new DateTime(2023, 10, 15);

            // Act
            DataRow newRow = service.AddNewRecord_DEV(table,
                entrance: 5,
                apartment: 10,
                totalArea: 75.5,
                livingArea: 55.0,
                rooms: 3,
                lastName: "Смирнов",
                registrationDate: testDate,
                familyMembers: 4,
                childrenCount: 2,
                hasDebt: false,
                note: "Новая запись");

            // Assert
            Assert.AreEqual(1, table.Rows.Count);
            Assert.AreEqual(5, newRow["EntranceNumber"]);
            Assert.AreEqual(10, newRow["ApartmentNumber"]);
            Assert.AreEqual(75.5, (double)newRow["TotalArea"], 0.001);
            Assert.AreEqual("Смирнов", newRow["TenantLastName"]);
            Assert.AreEqual(testDate.ToString("yyyy-MM-dd"), newRow["RegistrationDate"]);
            Assert.AreEqual("нет", newRow["HasDebt"]);
        }

        [TestMethod]
        public void ApartmentExists_DEV_FindsExistingApartment()
        {
            // Arrange
            var service = new DataService_DEV();
            DataTable table = service.LoadFromCsv_DEV(testFilePath);

            // Act & Assert
            Assert.IsTrue(service.ApartmentExists_DEV(table, 1, 1), "Квартира 1-1 должна существовать");
            Assert.IsTrue(service.ApartmentExists_DEV(table, 2, 5), "Квартира 2-5 должна существовать");
            Assert.IsFalse(service.ApartmentExists_DEV(table, 99, 99), "Квартира 99-99 не должна существовать");
        }

        [TestMethod]
        public void GetStatistics_DEV_ReturnsCorrectStatistics()
        {
            // Arrange
            var service = new DataService_DEV();
            DataTable table = service.LoadFromCsv_DEV(testFilePath);

            // Act
            string statistics = service.GetStatistics_DEV(table);

            // Assert
            Assert.IsNotNull(statistics);
            Assert.IsTrue(statistics.Contains("Общее количество квартир: 4"));
            Assert.IsTrue(statistics.Contains("Общее количество жильцов: 14")); // 3+4+5+2
            Assert.IsTrue(statistics.Contains("Общее количество детей: 6")); // 1+2+3+0
            Assert.IsTrue(statistics.Contains("Квартир с задолженностью: 2"));
            Assert.IsTrue(statistics.Contains("Квартир без задолженности: 2"));
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void LoadFromCsv_DEV_ThrowsFileNotFoundException()
        {
            // Arrange
            var service = new DataService_DEV();
            string nonExistentFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".csv");

            // Act
            service.LoadFromCsv_DEV(nonExistentFile);
        }

        [TestMethod]
        public void LoadFromCsv_DEV_HandlesEmptyFile()
        {
            // Arrange
            var service = new DataService_DEV();
            string emptyFilePath = Path.Combine(Path.GetTempPath(), $"empty_{Guid.NewGuid()}.csv");
            File.WriteAllText(emptyFilePath, "", Encoding.UTF8);

            try
            {
                // Act
                DataTable table = service.LoadFromCsv_DEV(emptyFilePath);

                // Assert
                Assert.IsNotNull(table);
                Assert.AreEqual(0, table.Rows.Count);
                Assert.AreEqual(11, table.Columns.Count);
            }
            finally
            {
                if (File.Exists(emptyFilePath))
                    File.Delete(emptyFilePath);
            }
        }

        [TestMethod]
        public void FilterState_DEV_ResetMethodWorks()
        {
            // Arrange
            var filterState = new FilterState_DEV
            {
                EntranceFrom = 5,
                EntranceTo = 10,
                LastName = "Иванов",
                UseDate = true,
                DebtYes = true
            };

            // Act
            filterState.Reset();

            // Assert
            Assert.AreEqual(0, filterState.EntranceFrom);
            Assert.AreEqual(0, filterState.EntranceTo);
            Assert.AreEqual("", filterState.LastName);
            Assert.IsFalse(filterState.UseDate);
            Assert.IsFalse(filterState.DebtYes);
            Assert.IsFalse(filterState.HasActiveFilters());
        }

        [TestMethod]
        public void FilterState_DEV_HasActiveFilters_ReturnsCorrectValue()
        {
            // Arrange & Act
            var filterState1 = new FilterState_DEV();
            var filterState2 = new FilterState_DEV { LastName = "Иванов" };
            var filterState3 = new FilterState_DEV { EntranceFrom = 1 };

            // Assert
            Assert.IsFalse(filterState1.HasActiveFilters());
            Assert.IsTrue(filterState2.HasActiveFilters());
            Assert.IsTrue(filterState3.HasActiveFilters());
        }
    }
}
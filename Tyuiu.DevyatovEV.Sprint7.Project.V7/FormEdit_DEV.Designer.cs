namespace Tyuiu.DevyatovEV.Sprint7.Project.V7
{
    partial class FormEdit_DEV
    {
        private NumericUpDown numericUpDownEntrance_DEV;
        private NumericUpDown numericUpDownApartment_DEV;
        private NumericUpDown numericUpDownTotalArea_DEV;
        private NumericUpDown numericUpDownLivingArea_DEV;
        private NumericUpDown numericUpDownRooms_DEV;
        private NumericUpDown numericUpDownFamily_DEV;
        private NumericUpDown numericUpDownChildren_DEV;
        private TextBox textBoxLastName_DEV;
        private TextBox textBoxNote_DEV;
        private DateTimePicker dateTimePickerRegistration_DEV;
        private CheckBox checkBoxDebt_DEV;
        private Button buttonOk_DEV;
        private Button buttonCancel_DEV;
        private Label labelTitle_DEV;

        private void InitializeComponent()
        {
            Text = "Добавление / Изменение записи";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            ClientSize = new Size(550, 560);
            BackColor = Color.FromArgb(245, 245, 255);
            Font = new Font("Segoe UI", 10F);

            int y = 70;

            // Заголовок
            labelTitle_DEV = new Label
            {
                Text = "Форма редактирования записи",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 102, 204),
                Location = new Point(20, 20),
                Size = new Size(500, 30),
                TextAlign = ContentAlignment.MiddleCenter
            };
            Controls.Add(labelTitle_DEV);

            numericUpDownEntrance_DEV = NewNumeric_DEV("Подъезд:", ref y, 0, 50);
            numericUpDownApartment_DEV = NewNumeric_DEV("Квартира:", ref y, 0, 500);
            numericUpDownTotalArea_DEV = NewNumeric_DEV("Общая площадь (м²):", ref y, 2, 300);
            numericUpDownLivingArea_DEV = NewNumeric_DEV("Жилая площадь (м²):", ref y, 2, 200);
            numericUpDownRooms_DEV = NewNumeric_DEV("Количество комнат:", ref y, 0, 10);
            textBoxLastName_DEV = NewTextBox_DEV("Фамилия жильца:", ref y);
            dateTimePickerRegistration_DEV = NewDateTimePicker_DEV("Дата регистрации:", ref y);
            numericUpDownFamily_DEV = NewNumeric_DEV("Членов семьи:", ref y, 0, 20);
            numericUpDownChildren_DEV = NewNumeric_DEV("Детей в семье:", ref y, 0, 10);

            // Чекбокс долга
            checkBoxDebt_DEV = new CheckBox
            {
                Text = "Есть задолженность",
                Location = new Point(220, y),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(192, 0, 0),
                Size = new Size(200, 25),
                CheckAlign = ContentAlignment.MiddleLeft
            };
            Controls.Add(checkBoxDebt_DEV);
            y += 35;

            // Примечание
            var lblNote = new Label
            {
                Text = "Примечание:",
                Location = new Point(20, y),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 64, 64)
            };
            Controls.Add(lblNote);
            y += 25;

            textBoxNote_DEV = new TextBox
            {
                Location = new Point(20, y),
                Size = new Size(500, 80),
                Multiline = true,
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                ScrollBars = ScrollBars.Vertical
            };
            Controls.Add(textBoxNote_DEV);
            y += 100;

            // Кнопки
            buttonOk_DEV = new Button
            {
                Text = "Сохранить",
                Location = new Point(290, y),
                Size = new Size(110, 40),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 102, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            buttonOk_DEV.FlatAppearance.BorderSize = 0;
            buttonOk_DEV.Click += ButtonOk_DEV_Click;

            buttonCancel_DEV = new Button
            {
                Text = "Отмена",
                Location = new Point(410, y),
                Size = new Size(110, 40),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(128, 128, 128),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            buttonCancel_DEV.FlatAppearance.BorderSize = 0;
            buttonCancel_DEV.Click += ButtonCancel_DEV_Click;

            Controls.Add(buttonOk_DEV);
            Controls.Add(buttonCancel_DEV);
        }

        private NumericUpDown NewNumeric_DEV(string label, ref int y, int decimals, int maxValue)
        {
            var lbl = new Label
            {
                Text = label,
                Location = new Point(20, y),
                Size = new Size(180, 25),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 64, 64),
                TextAlign = ContentAlignment.MiddleLeft
            };
            Controls.Add(lbl);

            var num = new NumericUpDown
            {
                Location = new Point(220, y),
                Size = new Size(300, 25),
                DecimalPlaces = decimals,
                Maximum = maxValue,
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                ThousandsSeparator = true
            };
            Controls.Add(num);
            y += 35;
            return num;
        }

        private TextBox NewTextBox_DEV(string label, ref int y)
        {
            var lbl = new Label
            {
                Text = label,
                Location = new Point(20, y),
                Size = new Size(180, 25),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 64, 64),
                TextAlign = ContentAlignment.MiddleLeft
            };
            Controls.Add(lbl);

            var txt = new TextBox
            {
                Location = new Point(220, y),
                Size = new Size(300, 25),
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            Controls.Add(txt);
            y += 35;
            return txt;
        }

        private DateTimePicker NewDateTimePicker_DEV(string label, ref int y)
        {
            var lbl = new Label
            {
                Text = label,
                Location = new Point(20, y),
                Size = new Size(180, 25),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 64, 64),
                TextAlign = ContentAlignment.MiddleLeft
            };
            Controls.Add(lbl);

            var dt = new DateTimePicker
            {
                Location = new Point(220, y),
                Size = new Size(300, 25),
                Font = new Font("Segoe UI", 10F),
                Format = DateTimePickerFormat.Short,
                BackColor = Color.White,
                CalendarFont = new Font("Segoe UI", 10F)
            };
            Controls.Add(dt);
            y += 35;
            return dt;
        }
    }
}
namespace Tyuiu.DevyatovEV.Sprint7.Project.V7
{
    partial class FormFilter_DEV
    {
        private NumericUpDown numEntranceFrom_DEV = null!;
        private NumericUpDown numEntranceTo_DEV = null!;
        private NumericUpDown numApartmentFrom_DEV = null!;
        private NumericUpDown numApartmentTo_DEV = null!;
        private NumericUpDown numTotalFrom_DEV = null!;
        private NumericUpDown numTotalTo_DEV = null!;
        private NumericUpDown numLivingFrom_DEV = null!;
        private NumericUpDown numLivingTo_DEV = null!;
        private NumericUpDown numRoomsFrom_DEV = null!;
        private NumericUpDown numRoomsTo_DEV = null!;
        private NumericUpDown numFamilyFrom_DEV = null!;
        private NumericUpDown numFamilyTo_DEV = null!;
        private NumericUpDown numChildrenFrom_DEV = null!;
        private NumericUpDown numChildrenTo_DEV = null!;

        private TextBox txtLastName_DEV = null!;
        private TextBox txtNote_DEV = null!;
        private DateTimePicker dtFrom_DEV = null!;
        private DateTimePicker dtTo_DEV = null!;
        private CheckBox chkDate_DEV = null!;
        private CheckedListBox chkDebt_DEV = null!;
        private Button btnApply_DEV = null!;
        private Button btnReset_DEV = null!;

        private void InitializeComponent()
        {
            Text = "Фильтр - Домоуправление";
            ClientSize = new Size(800, 600);
            StartPosition = FormStartPosition.CenterParent;
            Font = new Font("Segoe UI", 10F);
            BackColor = Color.FromArgb(245, 245, 255);

            TableLayoutPanel panel = new()
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                Padding = new Padding(20),
                BackColor = Color.White
            };

            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));

            Controls.Add(panel);

            int r = 0;

            void AddRange(string text, out NumericUpDown f, out NumericUpDown t)
            {
                panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
                panel.Controls.Add(new Label
                {
                    Text = text,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(64, 64, 64)
                }, 0, r);

                f = new NumericUpDown
                {
                    Maximum = 100000,
                    Font = new Font("Segoe UI", 10F),
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle
                };

                t = new NumericUpDown
                {
                    Maximum = 100000,
                    Font = new Font("Segoe UI", 10F),
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle
                };

                panel.Controls.Add(f, 1, r);

                panel.Controls.Add(new Label
                {
                    Text = "—",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(128, 128, 128)
                }, 2, r);

                panel.Controls.Add(t, 3, r);
                r++;
            }

            // Заголовок
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            var lblTitle = new Label
            {
                Text = "Настройка фильтров",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 102, 204),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            panel.Controls.Add(lblTitle, 0, r);
            panel.SetColumnSpan(lblTitle, 4);
            r++;

            AddRange("Подъезд", out numEntranceFrom_DEV, out numEntranceTo_DEV);
            AddRange("Квартира", out numApartmentFrom_DEV, out numApartmentTo_DEV);
            AddRange("Общая площадь (м²)", out numTotalFrom_DEV, out numTotalTo_DEV);
            AddRange("Жилая площадь (м²)", out numLivingFrom_DEV, out numLivingTo_DEV);
            AddRange("Комнаты", out numRoomsFrom_DEV, out numRoomsTo_DEV);

            // Фамилия
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
            panel.Controls.Add(new Label
            {
                Text = "Фамилия",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 64, 64)
            }, 0, r);

            txtLastName_DEV = new TextBox
            {
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            panel.Controls.Add(txtLastName_DEV, 1, r);
            panel.SetColumnSpan(txtLastName_DEV, 3);
            r++;

            // Дата регистрации
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
            chkDate_DEV = new CheckBox
            {
                Text = "Дата регистрации",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 64, 64)
            };
            panel.Controls.Add(chkDate_DEV, 0, r);

            dtFrom_DEV = new DateTimePicker
            {
                Font = new Font("Segoe UI", 10F),
                Format = DateTimePickerFormat.Short,
                BackColor = Color.White
            };

            dtTo_DEV = new DateTimePicker
            {
                Font = new Font("Segoe UI", 10F),
                Format = DateTimePickerFormat.Short,
                BackColor = Color.White
            };

            panel.Controls.Add(dtFrom_DEV, 1, r);
            panel.Controls.Add(new Label
            {
                Text = "—",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(128, 128, 128)
            }, 2, r);
            panel.Controls.Add(dtTo_DEV, 3, r);
            r++;

            AddRange("Семья (чел.)", out numFamilyFrom_DEV, out numFamilyTo_DEV);
            AddRange("Дети (чел.)", out numChildrenFrom_DEV, out numChildrenTo_DEV);

            // Долг
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
            panel.Controls.Add(new Label
            {
                Text = "Долг",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 64, 64)
            }, 0, r);

            chkDebt_DEV = new CheckedListBox
            {
                Height = 50,
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                CheckOnClick = true
            };
            chkDebt_DEV.Items.AddRange(new object[] { "Да", "Нет" });
            panel.Controls.Add(chkDebt_DEV, 1, r);
            panel.SetColumnSpan(chkDebt_DEV, 3);
            r++;

            // Примечание
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
            panel.Controls.Add(new Label
            {
                Text = "Примечание",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 64, 64)
            }, 0, r);

            txtNote_DEV = new TextBox
            {
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            panel.Controls.Add(txtNote_DEV, 1, r);
            panel.SetColumnSpan(txtNote_DEV, 3);
            r++;

            // Пустая строка для разделения
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            r++;

            // Кнопки
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            FlowLayoutPanel buttons = new()
            {
                FlowDirection = FlowDirection.RightToLeft,
                Dock = DockStyle.Fill,
                Padding = new Padding(10, 10, 0, 10)
            };

            btnApply_DEV = new Button
            {
                Text = "Применить фильтр",
                Width = 180,
                Height = 40,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 102, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnApply_DEV.FlatAppearance.BorderSize = 0;

            btnReset_DEV = new Button
            {
                Text = "Сбросить фильтры",
                Width = 180,
                Height = 40,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(192, 0, 0),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 0, 10, 0)
            };
            btnReset_DEV.FlatAppearance.BorderSize = 0;

            btnApply_DEV.Click += BtnApply_DEV_Click;
            btnReset_DEV.Click += BtnReset_DEV_Click;

            buttons.Controls.Add(btnApply_DEV);
            buttons.Controls.Add(btnReset_DEV);

            panel.Controls.Add(buttons, 0, r);
            panel.SetColumnSpan(buttons, 4);
        }
    }
}
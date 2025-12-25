namespace Tyuiu.DevyatovEV.Sprint7.Project.V7
{
    partial class FormMain_DEV
    {
        private MenuStrip menuStripMain_DEV;
        private ToolStripMenuItem menuMain_DEV;
        private ToolStripMenuItem menuExport_DEV;
        private ToolStripMenuItem menuStatistics_DEV;
        private ToolStripMenuItem menuManual_DEV;
        private ToolStripMenuItem menuAdd_DEV;
        private ToolStripMenuItem menuEdit_DEV;
        private ToolStripMenuItem menuDelete_DEV;
        private ToolStripMenuItem menuChart_DEV;
        private ToolStripMenuItem menuAbout_DEV;
        private ToolStripMenuItem menuExit_DEV;
        private ToolStripMenuItem menuFilter_DEV;
        private DataGridView dataGridViewBase_DEV;
        private Panel panelSearch_DEV;
        private Label labelSearch_DEV;
        private TextBox textBoxSearch_DEV;
        private Button btnResetSearch_DEV;

        private void SetColumnHeaders_DEV()
        {
            dataGridViewBase_DEV.Columns["EntranceNumber"].HeaderText = "Подъезд";
            dataGridViewBase_DEV.Columns["ApartmentNumber"].HeaderText = "Квартира";
            dataGridViewBase_DEV.Columns["TotalArea"].HeaderText = "Общая площадь";
            dataGridViewBase_DEV.Columns["LivingArea"].HeaderText = "Жилая площадь";
            dataGridViewBase_DEV.Columns["RoomsCount"].HeaderText = "Комнаты";
            dataGridViewBase_DEV.Columns["TenantLastName"].HeaderText = "Фамилия";
            dataGridViewBase_DEV.Columns["RegistrationDate"].HeaderText = "Дата";
            dataGridViewBase_DEV.Columns["FamilyMembers"].HeaderText = "Семья";
            dataGridViewBase_DEV.Columns["ChildrenCount"].HeaderText = "Дети";
            dataGridViewBase_DEV.Columns["HasDebt"].HeaderText = "Долг";
            dataGridViewBase_DEV.Columns["Note"].HeaderText = "Примечание";
        }

        private void InitializeComponent()
        {
            menuStripMain_DEV = new MenuStrip();
            menuFilter_DEV = new ToolStripMenuItem();
            menuMain_DEV = new ToolStripMenuItem();
            menuAdd_DEV = new ToolStripMenuItem();
            menuEdit_DEV = new ToolStripMenuItem();
            menuManual_DEV = new ToolStripMenuItem();
            menuDelete_DEV = new ToolStripMenuItem();
            menuChart_DEV = new ToolStripMenuItem();
            menuAbout_DEV = new ToolStripMenuItem();
            menuExit_DEV = new ToolStripMenuItem();
            menuExport_DEV = new ToolStripMenuItem();
            menuStatistics_DEV = new ToolStripMenuItem();
            dataGridViewBase_DEV = new DataGridView();
            panelSearch_DEV = new Panel();
            labelSearch_DEV = new Label();
            textBoxSearch_DEV = new TextBox();
            btnResetSearch_DEV = new Button();
            menuStripMain_DEV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBase_DEV).BeginInit();
            panelSearch_DEV.SuspendLayout();
            SuspendLayout();
            // 
            // menuStripMain_DEV
            // 
            menuStripMain_DEV.ImageScalingSize = new Size(20, 20);
            menuStripMain_DEV.Items.AddRange(new ToolStripItem[] { menuFilter_DEV, menuMain_DEV, menuExport_DEV, menuStatistics_DEV });
            menuStripMain_DEV.Location = new Point(0, 0);
            menuStripMain_DEV.Name = "menuStripMain_DEV";
            menuStripMain_DEV.Size = new Size(1024, 28);
            menuStripMain_DEV.TabIndex = 2;
            // 
            // menuFilter_DEV
            // 
            menuFilter_DEV.Name = "menuFilter_DEV";
            menuFilter_DEV.Size = new Size(74, 24);
            menuFilter_DEV.Text = "Фильтр";
            menuFilter_DEV.Click += MenuFilter_DEV_Click;
            // 
            // menuMain_DEV
            // 
            menuMain_DEV.DropDownItems.AddRange(new ToolStripItem[] { menuAdd_DEV, menuEdit_DEV, menuManual_DEV, menuDelete_DEV, menuChart_DEV, menuAbout_DEV, menuExit_DEV });
            menuMain_DEV.Name = "menuMain_DEV";
            menuMain_DEV.Size = new Size(79, 24);
            menuMain_DEV.Text = "Файл";
            // 
            // menuAdd_DEV
            // 
            menuAdd_DEV.Name = "menuAdd_DEV";
            menuAdd_DEV.Size = new Size(278, 26);
            menuAdd_DEV.Text = "Добавить";
            menuAdd_DEV.Click += MenuAdd_DEV_Click;
            // 
            // menuEdit_DEV
            // 
            menuEdit_DEV.Name = "menuEdit_DEV";
            menuEdit_DEV.Size = new Size(278, 26);
            menuEdit_DEV.Text = "Изменить";
            menuEdit_DEV.Click += MenuEdit_DEV_Click;
            // 
            // menuManual_DEV
            // 
            menuManual_DEV.Name = "menuManual_DEV";
            menuManual_DEV.Size = new Size(278, 26);
            menuManual_DEV.Text = "Руководство пользователя";
            menuManual_DEV.Click += MenuManual_DEV_Click;
            // 
            // menuDelete_DEV
            // 
            menuDelete_DEV.Name = "menuDelete_DEV";
            menuDelete_DEV.Size = new Size(278, 26);
            menuDelete_DEV.Text = "Удалить";
            menuDelete_DEV.Click += MenuDelete_DEV_Click;
            // 
            // menuChart_DEV
            // 
            menuChart_DEV.Name = "menuChart_DEV";
            menuChart_DEV.Size = new Size(278, 26);
            menuChart_DEV.Text = "График";
            menuChart_DEV.Click += MenuChart_DEV_Click;
            // 
            // menuAbout_DEV
            // 
            menuAbout_DEV.Name = "menuAbout_DEV";
            menuAbout_DEV.Size = new Size(278, 26);
            menuAbout_DEV.Text = "О программе";
            menuAbout_DEV.Click += MenuAbout_DEV_Click;
            // 
            // menuExit_DEV
            // 
            menuExit_DEV.Name = "menuExit_DEV";
            menuExit_DEV.Size = new Size(278, 26);
            menuExit_DEV.Text = "Выход";
            menuExit_DEV.Click += MenuExit_DEV_Click;
            // 
            // menuExport_DEV
            // 
            menuExport_DEV.Name = "menuExport_DEV";
            menuExport_DEV.Size = new Size(121, 24);
            menuExport_DEV.Text = "Экспорт в CSV";
            menuExport_DEV.Click += MenuExport_DEV_Click;
            // 
            // menuStatistics_DEV
            // 
            menuStatistics_DEV.Name = "menuStatistics_DEV";
            menuStatistics_DEV.Size = new Size(98, 24);
            menuStatistics_DEV.Text = "Статистика";
            menuStatistics_DEV.Click += MenuStatistics_DEV_Click;
            // 
            // dataGridViewBase_DEV
            // 
            dataGridViewBase_DEV.AllowUserToAddRows = false;
            dataGridViewBase_DEV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBase_DEV.ColumnHeadersHeight = 29;
            dataGridViewBase_DEV.Dock = DockStyle.Fill;
            dataGridViewBase_DEV.Location = new Point(0, 68);
            dataGridViewBase_DEV.Name = "dataGridViewBase_DEV";
            dataGridViewBase_DEV.ReadOnly = true;
            dataGridViewBase_DEV.RowHeadersWidth = 51;
            dataGridViewBase_DEV.Size = new Size(1024, 522);
            dataGridViewBase_DEV.TabIndex = 0;
            // 
            // panelSearch_DEV
            // 
            panelSearch_DEV.BackColor = Color.FromArgb(240, 240, 255);
            panelSearch_DEV.Controls.Add(labelSearch_DEV);
            panelSearch_DEV.Controls.Add(textBoxSearch_DEV);
            panelSearch_DEV.Controls.Add(btnResetSearch_DEV);
            panelSearch_DEV.Dock = DockStyle.Top;
            panelSearch_DEV.Location = new Point(0, 28);
            panelSearch_DEV.Name = "panelSearch_DEV";
            panelSearch_DEV.Size = new Size(1024, 40);
            panelSearch_DEV.TabIndex = 1;
            // 
            // labelSearch_DEV
            // 
            labelSearch_DEV.AutoSize = true;
            labelSearch_DEV.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelSearch_DEV.Location = new Point(10, 10);
            labelSearch_DEV.Name = "labelSearch_DEV";
            labelSearch_DEV.Size = new Size(165, 23);
            labelSearch_DEV.TabIndex = 0;
            labelSearch_DEV.Text = "Поиск по фамилии:";
            // 
            // textBoxSearch_DEV
            // 
            textBoxSearch_DEV.Location = new Point(180, 7);
            textBoxSearch_DEV.Name = "textBoxSearch_DEV";
            textBoxSearch_DEV.Size = new Size(300, 27);
            textBoxSearch_DEV.TabIndex = 1;
            textBoxSearch_DEV.TextChanged += TextSearch_DEV_TextChanged;
            // 
            // btnResetSearch_DEV
            // 
            btnResetSearch_DEV.Location = new Point(490, 6);
            btnResetSearch_DEV.Name = "btnResetSearch_DEV";
            btnResetSearch_DEV.Size = new Size(120, 31);
            btnResetSearch_DEV.TabIndex = 2;
            btnResetSearch_DEV.Text = "Сбросить";
            btnResetSearch_DEV.Click += BtnResetSearch_DEV_Click;
            // 
            // FormMain_DEV
            // 
            ClientSize = new Size(1024, 590);
            Controls.Add(dataGridViewBase_DEV);
            Controls.Add(panelSearch_DEV);
            Controls.Add(menuStripMain_DEV);
            Name = "FormMain_DEV";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Домоуправление | Девятов Егор Владимирович | Истнб-25-1";
            menuStripMain_DEV.ResumeLayout(false);
            menuStripMain_DEV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBase_DEV).EndInit();
            panelSearch_DEV.ResumeLayout(false);
            panelSearch_DEV.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
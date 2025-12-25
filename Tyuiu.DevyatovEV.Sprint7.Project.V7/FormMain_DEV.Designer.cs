namespace Tyuiu.DevyatovEV.Sprint7.Project.V7
{
    partial class FormMain_DEV
    {
        private MenuStrip menuStripMain_DEV;
        private ToolStripMenuItem menuExport_DEV;
        private ToolStripMenuItem menuStatistics_DEV;
        private ToolStripMenuItem menuFilter_DEV;
        private DataGridView dataGridViewBase_DEV;
        private Panel panelSearch_DEV;
        private Label labelSearch_DEV;
        private TextBox textBoxSearch_DEV;
        private Button btnResetSearch_DEV;


        private void InitializeComponent()
        {
            Button Add_DEV;
            Button Delete_DEV;
            Button Graph_DEV;
            Button About_DEV;
            Button Guide_DEV;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain_DEV));
            menuStripMain_DEV = new MenuStrip();
            menuFilter_DEV = new ToolStripMenuItem();
            menuExport_DEV = new ToolStripMenuItem();
            menuStatistics_DEV = new ToolStripMenuItem();
            dataGridViewBase_DEV = new DataGridView();
            panelSearch_DEV = new Panel();
            Guide_DEV = new Button();
            About_DEV = new Button();
            Graph_DEV = new Button();
            Delete_DEV = new Button();
            Add_DEV = new Button();
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
            menuStripMain_DEV.Items.AddRange(new ToolStripItem[] { menuFilter_DEV, menuExport_DEV, menuStatistics_DEV });
            menuStripMain_DEV.Location = new Point(0, 0);
            menuStripMain_DEV.Name = "menuStripMain_DEV";
            menuStripMain_DEV.Size = new Size(1024, 24);
            menuStripMain_DEV.TabIndex = 2;
            // 
            // menuFilter_DEV
            // 
            menuFilter_DEV.Name = "menuFilter_DEV";
            menuFilter_DEV.Size = new Size(60, 20);
            menuFilter_DEV.Text = "Фильтр";
            menuFilter_DEV.Click += MenuFilter_DEV_Click;
            // 
            // menuExport_DEV
            // 
            menuExport_DEV.Name = "menuExport_DEV";
            menuExport_DEV.Size = new Size(97, 20);
            menuExport_DEV.Text = "Экспорт в CSV";
            menuExport_DEV.Click += MenuExport_DEV_Click;
            // 
            // menuStatistics_DEV
            // 
            menuStatistics_DEV.Name = "menuStatistics_DEV";
            menuStatistics_DEV.Size = new Size(80, 20);
            menuStatistics_DEV.Text = "Статистика";
            menuStatistics_DEV.Click += MenuStatistics_DEV_Click;
            // 
            // dataGridViewBase_DEV
            // 
            dataGridViewBase_DEV.AllowUserToAddRows = false;
            dataGridViewBase_DEV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBase_DEV.ColumnHeadersHeight = 29;
            dataGridViewBase_DEV.Dock = DockStyle.Fill;
            dataGridViewBase_DEV.Location = new Point(0, 103);
            dataGridViewBase_DEV.Name = "dataGridViewBase_DEV";
            dataGridViewBase_DEV.ReadOnly = true;
            dataGridViewBase_DEV.RowHeadersWidth = 51;
            dataGridViewBase_DEV.Size = new Size(1024, 487);
            dataGridViewBase_DEV.TabIndex = 0;
            // 
            // panelSearch_DEV
            // 
            panelSearch_DEV.BackColor = Color.FromArgb(240, 240, 255);
            panelSearch_DEV.Controls.Add(Guide_DEV);
            panelSearch_DEV.Controls.Add(About_DEV);
            panelSearch_DEV.Controls.Add(Graph_DEV);
            panelSearch_DEV.Controls.Add(Delete_DEV);
            panelSearch_DEV.Controls.Add(Add_DEV);
            panelSearch_DEV.Controls.Add(labelSearch_DEV);
            panelSearch_DEV.Controls.Add(textBoxSearch_DEV);
            panelSearch_DEV.Controls.Add(btnResetSearch_DEV);
            panelSearch_DEV.Dock = DockStyle.Top;
            panelSearch_DEV.Location = new Point(0, 24);
            panelSearch_DEV.Name = "panelSearch_DEV";
            panelSearch_DEV.Size = new Size(1024, 79);
            panelSearch_DEV.TabIndex = 1;
            panelSearch_DEV.Paint += panelSearch_DEV_Paint;
            // 
            // Guide_DEV
            // 
            Guide_DEV.BackgroundImage = (System.Drawing.Image)resources.GetObject("Guide_DEV.BackgroundImage"); // ИСПРАВЛЕНО
            Guide_DEV.BackgroundImageLayout = ImageLayout.Center;
            Guide_DEV.ForeColor = SystemColors.ActiveCaption;
            Guide_DEV.Location = new Point(271, 8);
            Guide_DEV.Name = "Guide_DEV";
            Guide_DEV.Size = new Size(60, 60);
            Guide_DEV.TabIndex = 7;
            Guide_DEV.UseVisualStyleBackColor = true;
            Guide_DEV.Click += buttonGuide_DEV_Click;
            // 
            // About_DEV
            // 
            About_DEV.BackgroundImage = (System.Drawing.Image)resources.GetObject("About_DEV.BackgroundImage"); // ИСПРАВЛЕНО
            About_DEV.BackgroundImageLayout = ImageLayout.Center;
            About_DEV.ForeColor = SystemColors.ActiveCaption;
            About_DEV.Location = new Point(205, 8);
            About_DEV.Name = "About_DEV";
            About_DEV.Size = new Size(60, 60);
            About_DEV.TabIndex = 6;
            About_DEV.UseVisualStyleBackColor = true;
            About_DEV.Click += buttonAbout_DEV_Click;
            // 
            // Graph_DEV
            // 
            Graph_DEV.BackgroundImage = (System.Drawing.Image)resources.GetObject("Graph_DEV.BackgroundImage"); // ИСПРАВЛЕНО
            Graph_DEV.BackgroundImageLayout = ImageLayout.Center;
            Graph_DEV.ForeColor = SystemColors.ActiveCaption;
            Graph_DEV.Location = new Point(139, 8);
            Graph_DEV.Name = "Graph_DEV";
            Graph_DEV.Size = new Size(60, 60);
            Graph_DEV.TabIndex = 5;
            Graph_DEV.UseVisualStyleBackColor = true;
            Graph_DEV.Click += buttonGraph_DEV_Click;
            // 
            // Delete_DEV
            // 
            Delete_DEV.BackgroundImage = (System.Drawing.Image)resources.GetObject("Delete_DEV.BackgroundImage"); // ИСПРАВЛЕНО
            Delete_DEV.BackgroundImageLayout = ImageLayout.Center;
            Delete_DEV.ForeColor = SystemColors.ActiveCaption;
            Delete_DEV.Location = new Point(73, 8);
            Delete_DEV.Name = "Delete_DEV";
            Delete_DEV.Size = new Size(60, 60);
            Delete_DEV.TabIndex = 4;
            Delete_DEV.UseVisualStyleBackColor = true;
            Delete_DEV.Click += buttonDelete_DEV_Click;
            // 
            // Add_DEV
            // 
            Add_DEV.BackgroundImage = (System.Drawing.Image)resources.GetObject("Add_DEV.BackgroundImage"); // ИСПРАВЛЕНО
            Add_DEV.BackgroundImageLayout = ImageLayout.Center;
            Add_DEV.ForeColor = SystemColors.ActiveCaption;
            Add_DEV.Location = new Point(9, 8);
            Add_DEV.Name = "Add_DEV";
            Add_DEV.Size = new Size(60, 60);
            Add_DEV.TabIndex = 3;
            Add_DEV.UseVisualStyleBackColor = true;
            Add_DEV.Click += buttonAdd_DEV_Click;
            // 
            // labelSearch_DEV
            // 
            labelSearch_DEV.AutoSize = true;
            labelSearch_DEV.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelSearch_DEV.Location = new Point(567, 34);
            labelSearch_DEV.Name = "labelSearch_DEV";
            labelSearch_DEV.Size = new Size(57, 19);
            labelSearch_DEV.TabIndex = 0;
            labelSearch_DEV.Text = "Поиск:";
            labelSearch_DEV.Click += labelSearch_DEV_Click;
            // 
            // textBoxSearch_DEV
            // 
            textBoxSearch_DEV.Location = new Point(630, 31);
            textBoxSearch_DEV.Name = "textBoxSearch_DEV";
            textBoxSearch_DEV.Size = new Size(300, 23);
            textBoxSearch_DEV.TabIndex = 1;
            textBoxSearch_DEV.TextChanged += TextSearch_DEV_TextChanged;
            // 
            // btnResetSearch_DEV
            // 
            btnResetSearch_DEV.Location = new Point(936, 32);
            btnResetSearch_DEV.Name = "btnResetSearch_DEV";
            btnResetSearch_DEV.Size = new Size(75, 23);
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
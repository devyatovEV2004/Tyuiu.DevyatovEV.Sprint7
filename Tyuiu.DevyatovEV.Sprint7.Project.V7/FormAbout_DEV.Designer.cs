namespace Tyuiu.DevyatovEV.Sprint7.Project.V7
{
    partial class FormAbout_DEV
    {
        private System.ComponentModel.IContainer components = null;

        private PictureBox pictureBoxLogo_DEV;
        private Label labelTitle_DEV;
        private Label labelInfo_DEV;
        private Label labelVersion_DEV;
        private Label labelDeveloper_DEV;
        private Label labelGroup_DEV;
        private Label labelCourse_DEV;
        private Button buttonClose_DEV;
        private Panel panelHeader_DEV;
        private Panel panelFooter_DEV;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout_DEV));
            pictureBoxLogo_DEV = new PictureBox();
            labelTitle_DEV = new Label();
            labelInfo_DEV = new Label();
            labelVersion_DEV = new Label();
            labelDeveloper_DEV = new Label();
            labelGroup_DEV = new Label();
            labelCourse_DEV = new Label();
            buttonClose_DEV = new Button();
            panelHeader_DEV = new Panel();
            panelFooter_DEV = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo_DEV).BeginInit();
            panelHeader_DEV.SuspendLayout();
            panelFooter_DEV.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxLogo_DEV
            // 
            pictureBoxLogo_DEV.Image = (Image)resources.GetObject("pictureBoxLogo_DEV.Image");
            pictureBoxLogo_DEV.Location = new Point(30, 30);
            pictureBoxLogo_DEV.Name = "pictureBoxLogo_DEV";
            pictureBoxLogo_DEV.Size = new Size(150, 150);
            pictureBoxLogo_DEV.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo_DEV.TabIndex = 0;
            pictureBoxLogo_DEV.TabStop = false;
            pictureBoxLogo_DEV.Click += pictureBoxLogo_DEV_Click;
            // 
            // labelTitle_DEV
            // 
            labelTitle_DEV.AutoSize = true;
            labelTitle_DEV.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelTitle_DEV.ForeColor = Color.FromArgb(0, 102, 204);
            labelTitle_DEV.Location = new Point(200, 30);
            labelTitle_DEV.Name = "labelTitle_DEV";
            labelTitle_DEV.Size = new Size(251, 30);
            labelTitle_DEV.TabIndex = 1;
            labelTitle_DEV.Text = "Домоуправление v1.0";
            // 
            // labelInfo_DEV
            // 
            labelInfo_DEV.Font = new Font("Segoe UI", 10F);
            labelInfo_DEV.ForeColor = Color.FromArgb(64, 64, 64);
            labelInfo_DEV.Location = new Point(200, 80);
            labelInfo_DEV.Name = "labelInfo_DEV";
            labelInfo_DEV.Size = new Size(380, 100);
            labelInfo_DEV.TabIndex = 2;
            labelInfo_DEV.Text = "Программа для управления жилым фондом.\r\n\r\nОсновные функции:\r\n• Учет квартир и жильцов\r\n• Фильтрация и поиск\r\n• Статистика и графики\r\n• Экспорт данных";
            // 
            // labelVersion_DEV
            // 
            labelVersion_DEV.AutoSize = true;
            labelVersion_DEV.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelVersion_DEV.ForeColor = Color.FromArgb(128, 128, 128);
            labelVersion_DEV.Location = new Point(30, 200);
            labelVersion_DEV.Name = "labelVersion_DEV";
            labelVersion_DEV.Size = new Size(93, 15);
            labelVersion_DEV.TabIndex = 3;
            labelVersion_DEV.Text = "Версия: 1.0.0.0";
            labelVersion_DEV.Click += labelVersion_DEV_Click;
            // 
            // labelDeveloper_DEV
            // 
            labelDeveloper_DEV.AutoSize = true;
            labelDeveloper_DEV.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelDeveloper_DEV.ForeColor = Color.FromArgb(0, 102, 204);
            labelDeveloper_DEV.Location = new Point(30, 240);
            labelDeveloper_DEV.Name = "labelDeveloper_DEV";
            labelDeveloper_DEV.Size = new Size(310, 19);
            labelDeveloper_DEV.TabIndex = 4;
            labelDeveloper_DEV.Text = "Разработчик: Девятов Егор Владимирович";
            // 
            // labelGroup_DEV
            // 
            labelGroup_DEV.AutoSize = true;
            labelGroup_DEV.Font = new Font("Segoe UI", 10F);
            labelGroup_DEV.ForeColor = Color.FromArgb(64, 64, 64);
            labelGroup_DEV.Location = new Point(30, 270);
            labelGroup_DEV.Name = "labelGroup_DEV";
            labelGroup_DEV.Size = new Size(135, 19);
            labelGroup_DEV.TabIndex = 5;
            labelGroup_DEV.Text = "Группа: Истнб-25-1";
            // 
            // labelCourse_DEV
            // 
            labelCourse_DEV.AutoSize = true;
            labelCourse_DEV.Font = new Font("Segoe UI", 10F);
            labelCourse_DEV.ForeColor = Color.FromArgb(64, 64, 64);
            labelCourse_DEV.Location = new Point(30, 300);
            labelCourse_DEV.Name = "labelCourse_DEV";
            labelCourse_DEV.Size = new Size(177, 19);
            labelCourse_DEV.TabIndex = 6;
            labelCourse_DEV.Text = "Курс: 1 (Спринт 7, Проект)";
            labelCourse_DEV.Click += labelCourse_DEV_Click;
            // 
            // buttonClose_DEV
            // 
            buttonClose_DEV.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonClose_DEV.BackColor = Color.FromArgb(0, 102, 204);
            buttonClose_DEV.FlatStyle = FlatStyle.Flat;
            buttonClose_DEV.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonClose_DEV.ForeColor = Color.White;
            buttonClose_DEV.Location = new Point(551, 321);
            buttonClose_DEV.Name = "buttonClose_DEV";
            buttonClose_DEV.Size = new Size(150, 40);
            buttonClose_DEV.TabIndex = 8;
            buttonClose_DEV.Text = "Закрыть";
            buttonClose_DEV.UseVisualStyleBackColor = false;
            buttonClose_DEV.Click += buttonClose_DEV_Click;
            // 
            // panelHeader_DEV
            // 
            panelHeader_DEV.BackColor = Color.FromArgb(240, 240, 255);
            panelHeader_DEV.Controls.Add(pictureBoxLogo_DEV);
            panelHeader_DEV.Controls.Add(labelTitle_DEV);
            panelHeader_DEV.Controls.Add(labelInfo_DEV);
            panelHeader_DEV.Dock = DockStyle.Top;
            panelHeader_DEV.Location = new Point(0, 0);
            panelHeader_DEV.Name = "panelHeader_DEV";
            panelHeader_DEV.Size = new Size(721, 200);
            panelHeader_DEV.TabIndex = 9;
            // 
            // panelFooter_DEV
            // 
            panelFooter_DEV.BackColor = Color.White;
            panelFooter_DEV.Controls.Add(labelVersion_DEV);
            panelFooter_DEV.Controls.Add(labelDeveloper_DEV);
            panelFooter_DEV.Controls.Add(labelGroup_DEV);
            panelFooter_DEV.Controls.Add(labelCourse_DEV);
            panelFooter_DEV.Controls.Add(buttonClose_DEV);
            panelFooter_DEV.Dock = DockStyle.Fill;
            panelFooter_DEV.Location = new Point(0, 200);
            panelFooter_DEV.Name = "panelFooter_DEV";
            panelFooter_DEV.Size = new Size(721, 381);
            panelFooter_DEV.TabIndex = 10;
            // 
            // FormAbout_DEV
            // 
            AutoSize = true;
            ClientSize = new Size(721, 581);
            Controls.Add(panelFooter_DEV);
            Controls.Add(panelHeader_DEV);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(720, 620);
            Name = "FormAbout_DEV";
            StartPosition = FormStartPosition.CenterParent;
            Text = "О программе - Домоуправление";
            Load += FormAbout_DEV_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo_DEV).EndInit();
            panelHeader_DEV.ResumeLayout(false);
            panelHeader_DEV.PerformLayout();
            panelFooter_DEV.ResumeLayout(false);
            panelFooter_DEV.PerformLayout();
            ResumeLayout(false);
        }
    }
}
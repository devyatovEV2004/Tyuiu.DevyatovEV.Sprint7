namespace Tyuiu.DevyatovEV.Sprint7.Project.V7
{
    partial class FormChart_DEV
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // FormChart_DEV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(900, 700);
            DoubleBuffered = true;

            // Для полной свободы изменения размера:
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimizeBox = true;

            // Минимальный размер окна
            MinimumSize = new Size(600, 400);

            // Максимальный размер окна (необязательно)
            // MaximumSize = new Size(1200, 900);

            Name = "FormChart_DEV";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "График распределения квартир по количеству комнат";
            Load += FormChart_DEV_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
namespace Tyuiu.DevyatovEV.Sprint7.Project.V7
{
    partial class FormHelp_DEV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHelp_DEV));
            label1 = new Label();
            textBoxHelp = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(271, 25);
            label1.TabIndex = 1;
            label1.Text = "Руководство пользователя";
            // 
            // textBoxHelp
            // 
            textBoxHelp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxHelp.BackColor = Color.White;
            textBoxHelp.BorderStyle = BorderStyle.FixedSingle;
            textBoxHelp.Font = new Font("Segoe UI", 10F);
            textBoxHelp.ForeColor = Color.Black;
            textBoxHelp.Location = new Point(12, 50);
            textBoxHelp.Margin = new Padding(10);
            textBoxHelp.Multiline = true;
            textBoxHelp.Name = "textBoxHelp";
            textBoxHelp.ReadOnly = true;
            textBoxHelp.ScrollBars = ScrollBars.Vertical;
            textBoxHelp.Size = new Size(776, 388);
            textBoxHelp.TabIndex = 2;
            // 
            // FormHelp_DEV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxHelp);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(600, 400);
            Name = "FormHelp_DEV";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Домоуправление | Руководство пользователя";
            Load += FormHelp_DEV_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxHelp;
    }
}
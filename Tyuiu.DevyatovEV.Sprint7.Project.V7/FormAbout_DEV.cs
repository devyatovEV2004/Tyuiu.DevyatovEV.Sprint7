using System;
using System.Windows.Forms;

namespace Tyuiu.DevyatovEV.Sprint7.Project.V7
{
    public partial class FormAbout_DEV : Form
    {
        public FormAbout_DEV()
        {
            InitializeComponent();
        }

        private void buttonClose_DEV_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabelGitHub_DEV_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось открыть ссылку: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBoxLogo_DEV_Click(object sender, EventArgs e)
        {

        }
    }
}
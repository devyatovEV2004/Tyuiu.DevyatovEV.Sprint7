using System;
using System.Data;
using System.Windows.Forms;
using Tyuiu.DevyatovEV.Sprint7.Project.V7.Lib;

namespace Tyuiu.DevyatovEV.Sprint7.Project.V7
{
    public partial class FormEdit_DEV : Form
    {
        public DataRow RowResult { get; private set; }
        private readonly DataTable table_DEV;

        public FormEdit_DEV(DataTable table)
        {
            InitializeComponent();
            table_DEV = table;
            textBoxNote_DEV.Text = "-";
        }

        public FormEdit_DEV(DataTable table, DataRow row) : this(table)
        {
            numericUpDownEntrance_DEV.Value = Convert.ToDecimal(row["EntranceNumber"]);
            numericUpDownApartment_DEV.Value = Convert.ToDecimal(row["ApartmentNumber"]);
            numericUpDownTotalArea_DEV.Value = Convert.ToDecimal(row["TotalArea"]);
            numericUpDownLivingArea_DEV.Value = Convert.ToDecimal(row["LivingArea"]);
            numericUpDownRooms_DEV.Value = Convert.ToDecimal(row["RoomsCount"]);
            textBoxLastName_DEV.Text = row["TenantLastName"].ToString();
            dateTimePickerRegistration_DEV.Value = DateTime.Parse(row["RegistrationDate"].ToString());
            numericUpDownFamily_DEV.Value = Convert.ToDecimal(row["FamilyMembers"]);
            numericUpDownChildren_DEV.Value = Convert.ToDecimal(row["ChildrenCount"]);
            checkBoxDebt_DEV.Checked =
                row["HasDebt"].ToString().Trim().ToLower() == "да";
            textBoxNote_DEV.Text = row["Note"].ToString();
            RowResult = row;
        }

        private void ButtonOk_DEV_Click(object sender, EventArgs e)
        {
            if (RowResult == null)
                RowResult = table_DEV.NewRow();

            RowResult["EntranceNumber"] = (int)numericUpDownEntrance_DEV.Value;
            RowResult["ApartmentNumber"] = (int)numericUpDownApartment_DEV.Value;
            RowResult["TotalArea"] = (double)numericUpDownTotalArea_DEV.Value;
            RowResult["LivingArea"] = (double)numericUpDownLivingArea_DEV.Value;
            RowResult["RoomsCount"] = (int)numericUpDownRooms_DEV.Value;
            RowResult["TenantLastName"] = textBoxLastName_DEV.Text;
            RowResult["RegistrationDate"] =
                dateTimePickerRegistration_DEV.Value.ToString("yyyy-MM-dd");
            RowResult["FamilyMembers"] = (int)numericUpDownFamily_DEV.Value;
            RowResult["ChildrenCount"] = (int)numericUpDownChildren_DEV.Value;
            RowResult["HasDebt"] = checkBoxDebt_DEV.Checked ? "да" : "нет";
            RowResult["Note"] = textBoxNote_DEV.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonCancel_DEV_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
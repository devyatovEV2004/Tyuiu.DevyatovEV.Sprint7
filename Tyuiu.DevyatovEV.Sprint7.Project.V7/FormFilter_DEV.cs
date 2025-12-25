using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tyuiu.DevyatovEV.Sprint7.Project.V7.Lib;

namespace Tyuiu.DevyatovEV.Sprint7.Project.V7
{
    public partial class FormFilter_DEV : Form
    {
        private readonly FilterState_DEV _state;

        public string ResultFilter { get; private set; } = "";

        public FormFilter_DEV(FilterState_DEV state)
        {
            _state = state;
            InitializeComponent();
            RestoreState();
        }

        private void BtnApply_DEV_Click(object? sender, EventArgs e)
        {
            SaveState();

            List<string> filters = new();

            void AddRange(string col, decimal f, decimal t)
            {
                if (f > 0 || t > 0)
                    filters.Add($"{col} >= {f} AND {col} <= {t}");
            }

            AddRange("EntranceNumber", numEntranceFrom_DEV.Value, numEntranceTo_DEV.Value);
            AddRange("ApartmentNumber", numApartmentFrom_DEV.Value, numApartmentTo_DEV.Value);
            AddRange("TotalArea", numTotalFrom_DEV.Value, numTotalTo_DEV.Value);
            AddRange("LivingArea", numLivingFrom_DEV.Value, numLivingTo_DEV.Value);
            AddRange("RoomsCount", numRoomsFrom_DEV.Value, numRoomsTo_DEV.Value);
            AddRange("FamilyMembers", numFamilyFrom_DEV.Value, numFamilyTo_DEV.Value);
            AddRange("ChildrenCount", numChildrenFrom_DEV.Value, numChildrenTo_DEV.Value);

            if (!string.IsNullOrWhiteSpace(txtLastName_DEV.Text))
                filters.Add($"TenantLastName LIKE '%{txtLastName_DEV.Text.Replace("'", "''")}%'");

            if (!string.IsNullOrWhiteSpace(txtNote_DEV.Text))
                filters.Add($"Note LIKE '%{txtNote_DEV.Text.Replace("'", "''")}%'");

            if (chkDate_DEV.Checked)
                filters.Add(
                    $"RegistrationDate >= #{dtFrom_DEV.Value:yyyy-MM-dd}# AND RegistrationDate <= #{dtTo_DEV.Value:yyyy-MM-dd}#");

            if (chkDebt_DEV.CheckedItems.Count == 1)
                filters.Add($"HasDebt = '{chkDebt_DEV.CheckedItems[0]}'");

            ResultFilter = string.Join(" AND ", filters);
            DialogResult = DialogResult.OK;
        }

        private void BtnReset_DEV_Click(object? sender, EventArgs e)
        {
            _state.Reset();
            ResultFilter = "";
            DialogResult = DialogResult.OK;
        }

        private void SaveState()
        {
            _state.EntranceFrom = numEntranceFrom_DEV.Value;
            _state.EntranceTo = numEntranceTo_DEV.Value;
            _state.ApartmentFrom = numApartmentFrom_DEV.Value;
            _state.ApartmentTo = numApartmentTo_DEV.Value;
            _state.TotalFrom = numTotalFrom_DEV.Value;
            _state.TotalTo = numTotalTo_DEV.Value;
            _state.LivingFrom = numLivingFrom_DEV.Value;
            _state.LivingTo = numLivingTo_DEV.Value;
            _state.RoomsFrom = numRoomsFrom_DEV.Value;
            _state.RoomsTo = numRoomsTo_DEV.Value;
            _state.FamilyFrom = numFamilyFrom_DEV.Value;
            _state.FamilyTo = numFamilyTo_DEV.Value;
            _state.ChildrenFrom = numChildrenFrom_DEV.Value;
            _state.ChildrenTo = numChildrenTo_DEV.Value;

            _state.LastName = txtLastName_DEV.Text;
            _state.Note = txtNote_DEV.Text;

            _state.UseDate = chkDate_DEV.Checked;
            _state.DateFrom = dtFrom_DEV.Value;
            _state.DateTo = dtTo_DEV.Value;

            _state.DebtYes = chkDebt_DEV.GetItemChecked(0);
            _state.DebtNo = chkDebt_DEV.GetItemChecked(1);
        }

        private void RestoreState()
        {
            numEntranceFrom_DEV.Value = _state.EntranceFrom;
            numEntranceTo_DEV.Value = _state.EntranceTo;
            numApartmentFrom_DEV.Value = _state.ApartmentFrom;
            numApartmentTo_DEV.Value = _state.ApartmentTo;
            numTotalFrom_DEV.Value = _state.TotalFrom;
            numTotalTo_DEV.Value = _state.TotalTo;
            numLivingFrom_DEV.Value = _state.LivingFrom;
            numLivingTo_DEV.Value = _state.LivingTo;
            numRoomsFrom_DEV.Value = _state.RoomsFrom;
            numRoomsTo_DEV.Value = _state.RoomsTo;
            numFamilyFrom_DEV.Value = _state.FamilyFrom;
            numFamilyTo_DEV.Value = _state.FamilyTo;
            numChildrenFrom_DEV.Value = _state.ChildrenFrom;
            numChildrenTo_DEV.Value = _state.ChildrenTo;

            txtLastName_DEV.Text = _state.LastName;
            txtNote_DEV.Text = _state.Note;

            chkDate_DEV.Checked = _state.UseDate;
            dtFrom_DEV.Value = _state.DateFrom;
            dtTo_DEV.Value = _state.DateTo;

            chkDebt_DEV.SetItemChecked(0, _state.DebtYes);
            chkDebt_DEV.SetItemChecked(1, _state.DebtNo);
        }
    }
}
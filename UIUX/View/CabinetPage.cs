using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIUX.Popup;
using TransferObject;
using BusinessLayer;

namespace UIUX.View
{
    public partial class CabinetPage: Form
    {

        private static ObservableCollection<TransferObject.Medicine> medicines;

        public CabinetPage()
        {
            InitializeComponent();
            LoadMedicine();
            sfDataGrid.FilterRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top;
        }

        public void LoadMedicine()
        {
            sfDataGrid.DataSource = new MedicineBL().GetMedicines();
            sfDataGrid.Columns["id"].Visible = false;  
        }

        private void addNewMedicine_btn_Click(object sender, EventArgs e)
        {
            NewMedicinePopup newMedicinePopup = new NewMedicinePopup();
            newMedicinePopup.addMedicineEvent += AddNewMedicine;
            newMedicinePopup.ShowDialog();
        }

        private void AddNewMedicine(object medicine, EventArgs e)
        {
            try
            {
                MedicineBL medicineBL = new MedicineBL();

                medicineBL.Add((Medicine)medicine);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Cancel;
                MessageBox.Show(ex.Message);
            }
        }

        private void sfDataGrid_CellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            if (e.DataRow.Index == 1) return;

            Medicine medicine = e.DataRow.RowData as Medicine;
            MedicineEditPopup medicineEditPopup = new MedicineEditPopup(medicine);
            medicineEditPopup.editMedicine += EditMedicine;
            DialogResult result = medicineEditPopup.ShowDialog();   
        }

        private void EditMedicine(object medicine, EventArgs e)
        {
            try
            {
                //MedicineBL medicineBL = new MedicineBL();
                //medicineBL.MedicineUpdate((Medicine)medicine);
                //this.DialogResult = DialogResult.OK;
                LoadMedicine();
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Cancel;
                MessageBox.Show(ex.Message);
            }
        }
    }
}

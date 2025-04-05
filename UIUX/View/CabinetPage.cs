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

namespace UIUX.View
{
    public partial class CabinetPage: Form
    {

        private static ObservableCollection<TransferObject.Medicine> medicines;

        public CabinetPage()
        {
            InitializeComponent();
            medicines = new ObservableCollection<TransferObject.Medicine>();
            sfDataGrid.DataSource = medicines;
            sfDataGrid.FilterRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top;
        }

        private void addNewMedicine_btn_Click(object sender, EventArgs e)
        {
            NewMedicinePopup newMedicinePopup = new NewMedicinePopup();
            newMedicinePopup.addMedicineEvent += AddNewMedicine;
            newMedicinePopup.ShowDialog();
        }

        private void AddNewMedicine(object medicine, EventArgs e)
        {
            medicines.Add((TransferObject.Medicine)medicine);
        }

    }
}

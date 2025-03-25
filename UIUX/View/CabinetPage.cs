using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIUX.Popup;

namespace UIUX.View
{
    public partial class CabinetPage: Form
    {
        public CabinetPage()
        {
            InitializeComponent();
            sfDataGrid.DataSource = new List<TransferObject.Medicine>();
            sfDataGrid.FilterRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top;
        }

        private void addNewMedicine_btn_Click(object sender, EventArgs e)
        {
            NewMedicinePopup newMedicinePopup = new NewMedicinePopup();
            newMedicinePopup.ShowDialog();
        }
    }
}

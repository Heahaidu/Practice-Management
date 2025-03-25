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
    public partial class PatientPage: Form
    {
        public PatientPage()
        {
            InitializeComponent();

            sfDataGrid.DataSource = new List<TransferObject.Patient>();
            sfDataGrid.FilterRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top;

        }

        private void addNewPatient_btn_Click(object sender, EventArgs e)
        {
            NewPatientPopup newPatientPopup = new NewPatientPopup();
            newPatientPopup.ShowDialog();
        }
    }
}

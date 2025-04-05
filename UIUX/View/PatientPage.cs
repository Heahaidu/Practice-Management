using Bunifu.Framework.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using TransferObject;
using UIUX.Popup;
using UIUX.ViewForm;

namespace UIUX.View
{
    public partial class PatientPage: Form
    {

        private static ObservableCollection<TransferObject.Patient> patients;

        public PatientPage()
        {
            InitializeComponent();
            patients = new ObservableCollection<TransferObject.Patient>();

            sfDataGrid.DataSource = patients;

            //var editColumn = new Syncfusion.WinForms.DataGrid.GridButtonColumn()
            //{
            //    HeaderText = "",
            //    MappingName = "ASD",
            //    AllowFiltering = false,
            //    AllowSorting = false,
            //    AllowResizing = false,
            //    AllowEditing = false,
            //    ImageSize = new Size(16, 16),
            //    ButtonSize = new Size(24, 24),
            //    Image = Properties.Resources.icons8_create_24,

            //};
            //editColumn.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            ////editColumn.CellStyle.VerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;

            //sfDataGrid.Columns.Add(editColumn);
            //sfDataGrid.Columns.Move(sfDataGrid.Columns.Count - 1, 0);
            sfDataGrid.FilterRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top;
        }

        private void addNewPatient_btn_Click(object sender, EventArgs e)
        {
            NewPatientPopup newPatientPopup = new NewPatientPopup();
            newPatientPopup.addPatientEvent += AddNewPatient;
            newPatientPopup.ShowDialog();
        }

        private void AddNewPatient(object patient, EventArgs e)
        {
            patients.Add((Patient)patient);
        }

        private void sfDataGrid_CellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            Patient row = e.DataRow.RowData as Patient;
            Console.WriteLine(row.ToString());
            PatientForm patientForm = new PatientForm(row);
            patientForm.ShowDialog();
        }

    }
}

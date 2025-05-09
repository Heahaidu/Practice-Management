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
using BusinessLayer;

namespace UIUX.View
{
    public partial class PatientPage: Form
    {

        private static ObservableCollection<TransferObject.Patient> patients;

        public PatientPage()
        {
            InitializeComponent();
            sfDataGrid.FilterRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top;

            LoadPatient();

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

        }

        private void LoadPatient()
        {
            sfDataGrid.DataSource = new PatientBL().GetPatients();

            sfDataGrid.Columns["id"].Visible = false;
            sfDataGrid.Columns["healthInsuranceId"].Visible = false;
            sfDataGrid.Columns["name"].MinimumWidth = 200;
            sfDataGrid.Columns["dob"].Format = "dd/MM/yyyy";
            sfDataGrid.Columns["idCard"].Visible = false;
            sfDataGrid.Columns["email"].MinimumWidth = 250;
            sfDataGrid.Columns["address"].MinimumWidth = 270;
            sfDataGrid.Columns["medicalHistory"].MinimumWidth = 350;
            Console.WriteLine("Load Patients");
            sfDataGrid.QueryCellStyle += (sender, e) =>
            {
                switch (e.Column.MappingName)
                {
                    case "gender":
                        e.DisplayText = (e.DisplayText == "MALE" ? "Nam" : e.DisplayText == "FEMALE"? "Nữ": e.DisplayText);
                        break;
                    default:
                        break;
                }
            };
        }

        private void addNewPatient_btn_Click(object sender, EventArgs e)
        {
            NewPatientPopup newPatientPopup = new NewPatientPopup();
            newPatientPopup.addPatientEvent += AddNewPatient;
            newPatientPopup.ShowDialog();
        }

        private void AddNewPatient(object patient, EventArgs e)
        {
           try
            {
                PatientBL patientBL = new PatientBL();

                patientBL.Add((Patient)patient);

                this.DialogResult = DialogResult.OK;

                LoadPatient(); 

            }
            catch (Exception ex) { 
                this.DialogResult = DialogResult.No;
                MessageBox.Show(ex.Message);
            }
        }

        private void sfDataGrid_CellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            try
            {
                if (e.DataRow.Index == 1) return;
                Patient row = e.DataRow.RowData as Patient;
                PatientForm patientForm = new PatientForm(row);
                patientForm.updatePatientsEvent += updatePatientsEvent;
                patientForm.ShowDialog();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void updatePatientsEvent(object sender, EventArgs e)
        {
            Patient updatedPatient = sender as Patient;
            if (updatedPatient != null)
            {
                LoadPatient();
            }
        }
    }
}

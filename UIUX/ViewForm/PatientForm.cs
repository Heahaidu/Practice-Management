using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;
using UIUX.Popup;
using BusinessLayer;
using Syncfusion.Windows.Forms.Interop;

namespace UIUX.ViewForm
{
    public partial class PatientForm: Form
    {

        private Patient patient;
        private static ObservableCollection<Examination> examinations;
        private static ObservableCollection<Indication> indications;
        public EventHandler updatePatientEvent;
        public PatientForm(Patient patient)
        {
            this.patient = patient;
            InitializeComponent();
            tbPatientName.Text = patient.name;
            tbLocation.Text = patient.address;
            tbPhone.Text = patient.phone;
            //tbEmail.Text = patient.email;
            tbMedicalHistory.Text = patient.medicalHistory;
            tbIdCard.Text = patient.idCard;
            dtDob.Value = patient.dob;
            ddGender.Text = patient.gender == Gender.MALE? "Nam" : "Nữ";

            // Initialize the data grid for examinations
            LoadExam();
            dataGridExamination.FilterRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top;


            // Initialize the data grid for indications
            LoadIndication();
            dataGridIndication.FilterRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top;

        }

        private void LoadExam()
        {
            dataGridExamination.DataSource = new ExaminationBL().GetExaminations(patient.id);
        }

        private void LoadIndication()
        {
            dataGridIndication.DataSource = new IndicationBL().GetIndications(patient.id);
        }

        private void btnAddNewExamination_Click(object sender, EventArgs e)
        {
            NewExaminationPopup newExaminationPopup = new NewExaminationPopup(patientId:patient.id);
            newExaminationPopup.addExaminationEvent += addNewExaminationEvent;
            newExaminationPopup.ShowDialog();
        }

        private void btnAddNewIndication_Click(object sender, EventArgs e)
        {
            NewIndicationPopup newIndicationPopup = new NewIndicationPopup(patientId: patient.id);
            newIndicationPopup.addIndicationEvent += addNewIndicationEvent;
            newIndicationPopup.ShowDialog();
        }

        private void addNewExaminationEvent(object examination, EventArgs e)
        {
            try
            {
                ExaminationBL examinationBL = new ExaminationBL();
                examinationBL.Add((Examination)examination, patientId: patient.id);
                LoadExam();
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Cancel;
                MessageBox.Show(ex.Message);
            }
        }

        private void addNewIndicationEvent(object indication, EventArgs e)
        {
            try
            {
                IndicationBL indicationBL = new IndicationBL();
                indicationBL.Add((Indication)indication, patientId: patient.id);
                LoadIndication();
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Cancel;
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdatePatient_Click(object sender, EventArgs e)
        {
            Gender gender = ddGender.SelectedIndex == 0 ? Gender.MALE : Gender.FEMALE;
            Patient patient_update = new Patient(id: patient.id,name: tbPatientName.Text, dob: dtDob.Value.Value, gender: gender, address: tbLocation.Text, phone: tbPhone.Text, idCard: tbIdCard.Text, medicalHistory: tbMedicalHistory.Text);
            PatientBL patientBL = new PatientBL();
            try
            {
                patientBL.Update(patient_update);
                updatePatientEvent?.Invoke(patient, e);
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Cancel;
                MessageBox.Show(ex.Message);
            }
        }
    }
}

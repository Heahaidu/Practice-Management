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

namespace UIUX.ViewForm
{
    public partial class PatientForm: Form
    {

        private Patient patient;
        private static ObservableCollection<TransferObject.Examination> examinations;
        private static ObservableCollection<TransferObject.Indication> indications;

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
            dateTimeDob.Value = patient.dob;
            dropdowGender.Text = patient.gender == Gender.MALE? "Nam" : "Nữ";

            // Initialize the data grid for examinations
            examinations = new ObservableCollection<TransferObject.Examination>();
            dataGridExamination.DataSource = examinations;
            dataGridExamination.FilterRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top;


            // Initialize the data grid for indications
            indications = new ObservableCollection<TransferObject.Indication>();
            dataGridIndication.DataSource = indications;
            dataGridIndication.FilterRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top;

        }

        private void btnAddNewExamination_Click(object sender, EventArgs e)
        {
            NewExaminationPopup newExaminationPopup = new NewExaminationPopup();
            newExaminationPopup.addExaminationEvent += addNewExaminationEvent;
            newExaminationPopup.ShowDialog();
        }

        private void btnAddNewIndication_Click(object sender, EventArgs e)
        {
            NewIndicationPopup newIndicationPopup = new NewIndicationPopup();
            newIndicationPopup.addIndicationEvent += addNewIndicationEvent;
            newIndicationPopup.ShowDialog();
        }

        private void addNewExaminationEvent(object sender, EventArgs e)
        {
            Examination examination = sender as TransferObject.Examination;
            examinations.Add(examination);
            Console.WriteLine("Name: " + examination.DiagnosisName);
        }

        private void addNewIndicationEvent(object sender, EventArgs e)
        {
            Indication indication = sender as TransferObject.Indication;
            indications.Add(indication);
            Console.WriteLine(indication.ToString());
        }

    }
}

using System;
using System.Collections.ObjectModel;
using TransferObject;
using UIUX.Popup;
using BusinessLayer;
using System.Windows;
using System.Windows.Forms;
using System.Collections;
using System.Windows.Controls;
using Syncfusion.WinForms.DataGrid;
using UIUX.View;

namespace UIUX.ViewForm
{
    public partial class PatientForm : Form
    {

        private Patient patient;
        private static ObservableCollection<Examination> examinations;
        private static ObservableCollection<Indication> indications;
        public EventHandler updatePatientsEvent;

        public PatientForm(Patient patient)
        {
            this.patient = patient;
            InitializeComponent();
            tbPatientName.Text = patient.name;
            tbLocation.Text = patient.address;
            tbPhone.Text = patient.phone;
            tbEmail.Text = patient.email;
            tbMedicalHistory.Text = patient.medicalHistory;
            tbIdCard.Text = patient.idCard;
            dtDob.Value = patient.dob;
            ddGender.Items.Add(Gender.MALE.GetDescription());
            ddGender.Items.Add(Gender.FEMALE.GetDescription());
            ddGender.SelectedIndex = patient.gender == Gender.MALE ? 0 : 1;


            tbHealthInsuranceId.Text = patient.healthInsuranceId;
            // Initialize the data grid for examinations
            LoadExam();
            dataGridExamination.FilterRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top;


            // Initialize the data grid for indications
            LoadIndication();
            dataGridIndication.FilterRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top;

            btnSave.Visible = false;
            btnExit.Visible = false;

            altPanel.Dock = DockStyle.Fill;

        }

        private void LoadExam()
        {
            dataGridExamination.DataSource = new ExaminationBL().GetExaminations(patient.id);
            dataGridExamination.Columns["Id"].Visible = false;
            dataGridExamination.Columns["PatientId"].Visible = false;
            dataGridExamination.Columns["DoctorId"].Visible = false;
        }

        private void LoadIndication()
        {
            dataGridIndication.DataSource = new IndicationBL().GetIndications(patient.id);
            dataGridIndication.Columns["Id"].Visible = false;
            dataGridIndication.Columns["PatientId"].Visible = false;
            dataGridIndication.Columns["DoctorId"].Visible = false;
        }

        private void btnAddNewExamination_Click(object sender, EventArgs e)
        {
            NewExaminationPopup newExaminationPopup = new NewExaminationPopup(patientId: patient.id);
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
                System.Windows.MessageBox.Show(ex.Message);
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
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Gender gender = ddGender.SelectedIndex == 0?Gender.MALE: Gender.FEMALE;

            Patient patient_update = new Patient(id: patient.id, name: tbPatientName.Text, dob: dtDob.Value.Value, gender: gender, address: tbLocation.Text, phone: tbPhone.Text, email:tbEmail.Text, idCard: tbIdCard.Text, medicalHistory: tbMedicalHistory.Text);
            PatientBL patientBL = new PatientBL();
            try
            {
                if (patientBL.Update(patient_update) == 0)
                {
                    System.Windows.MessageBox.Show("Cập nhật thông tin bệnh nhân không thành công");
                    return;
                }

                btnChangeInfo.Visible = true;
                btnSave.Visible = false;
                btnExit.Visible = false;
                ChangePatientInfoElemnts(false);
                updatePatientsEvent?.Invoke(patient, e);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void btnChangeInfo_Click(object sender, EventArgs e)
        {
            btnChangeInfo.Visible = false;
            btnSave.Visible = true;
            btnExit.Visible = true;

            ChangePatientInfoElemnts(true);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            btnChangeInfo.Visible = true;
            btnSave.Visible = false;
            btnExit.Visible = false;

            ChangePatientInfoElemnts(false);
        }

        private void ChangePatientInfoElemnts(bool isEnabled)
        {
            tbPatientName.Enabled = isEnabled;
            ddGender.Enabled = isEnabled;
            dtDob.Enabled = isEnabled;
            tbLocation.Enabled = isEnabled;
            tbPhone.Enabled = isEnabled;
            tbIdCard.Enabled = isEnabled;
            tbMedicalHistory.Enabled = isEnabled;
            tbHealthInsuranceId.Enabled = isEnabled;
            tbEmail.Enabled = isEnabled;
            btnDeletePatient.Enabled = isEnabled;
        }

        private void btnDeletePatient_Click(object sender, EventArgs e)
        {
            System.Windows.MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (messageBoxResult == MessageBoxResult.No)
            {
                return;
            }
            BusinessLayer.PatientBL patientBL = new BusinessLayer.PatientBL();
            patientBL.Delete(patient.id);
            updatePatientsEvent?.Invoke(patient, e);
            this.Close();
        }

        private void dataGridExamination_CellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            if (e.DataRow.RowIndex == 1) return;
            Examination examination = e.DataRow.RowData as Examination;
            if (examination == null) return;

            PrescriptionPage prescriptionPage = new PrescriptionPage()
            {
                TopLevel = false,
                Dock = DockStyle.Fill,
                FormBorderStyle = FormBorderStyle.None,
                Visible = false
            };

            this.Controls.Add(prescriptionPage);

            prescriptionPage.backEvent += (sender_, e_) =>
            {
                prescriptionPage.Visible = false;
                Controls.Remove(prescriptionPage);
            };

            prescriptionPage.deleteEvent += (sender_, e_) =>
            {
                prescriptionPage.Visible = false;
                LoadExam();
            };

            prescriptionPage.SetData(examination, patient);
            prescriptionPage.Visible = true;
            prescriptionPage.Refresh();
            prescriptionPage.BringToFront();
        }

        private void dataGridIndication_CellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            if (e.DataRow.RowIndex == 1) return;
            Indication indication = e.DataRow.RowData as Indication; 
            Patient row = e.DataRow.RowData as Patient;
            if (indication == null) return;


            MedicalTestsScriptionPage medicalTestsScriptionPage = new MedicalTestsScriptionPage()
            {
                TopLevel = false,
                Dock = DockStyle.Fill,
                FormBorderStyle = FormBorderStyle.None,
                Visible = false
            };

            this.Controls.Add(medicalTestsScriptionPage);

            medicalTestsScriptionPage.backEvent += (sender_, e_) =>
            {
                medicalTestsScriptionPage.Visible = false;
                Controls.Remove(medicalTestsScriptionPage);
            };

            medicalTestsScriptionPage.deleteEvent += (sender_, e_) =>
            {
                medicalTestsScriptionPage.Visible = false;
                LoadIndication();
            };

            medicalTestsScriptionPage.Visible = true;
            medicalTestsScriptionPage.SetData(indication, patient);
            medicalTestsScriptionPage.Refresh();
            medicalTestsScriptionPage.BringToFront();
        }
    }
}

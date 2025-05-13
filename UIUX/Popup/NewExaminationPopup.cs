using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace UIUX.Popup
{
    public partial class NewExaminationPopup: Form
    {

        public EventHandler addExaminationEvent;
        private int patientId;

        public NewExaminationPopup(int patientId)
        {
            InitializeComponent();
            dtExamination.Value = DateTime.Now;
            this.patientId = patientId;
            tbDoctorName.Text = "B.s " + UserSession.Instance.CurrentUser.displayName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddNewExamination_Click(object sender, EventArgs e)
        {
            if (tbDiagnosisName.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }
            DateTime examinationDate = dtExamination.Value.Value;
            Examination examination = new Examination(examinationDate: examinationDate,
                doctorName: tbDoctorName.Text, medicalHistory: tbMedicalHistory.Text,
                diagnosisName: tbDiagnosisName.Text, notes: tbNote.Text, patientId: patientId, doctorId: UserSession.Instance.CurrentUser.id);
            addExaminationEvent?.Invoke(examination, e);
            Close();
        }
    }
}

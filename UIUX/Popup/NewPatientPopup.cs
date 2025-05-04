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
    public partial class NewPatientPopup: Form
    {
        public EventHandler addPatientEvent;

        public NewPatientPopup()
        {
            InitializeComponent();
            InitializeControls();
        }

        public class GenderDisplay
        {
            public string DisplayName { get; set; }
            public Gender Value { get; set; }
        }

        private void InitializeControls()
        {
            var genderList = new List<GenderDisplay>
            {
                new GenderDisplay { DisplayName = "Nam", Value = Gender.MALE },
                new GenderDisplay { DisplayName = "Nữ", Value = Gender.FEMALE }
            };

            if (genderList == null || genderList.Count == 0)
            {
                MessageBox.Show("Lỗi: Danh sách giới tính rỗng.");
                return;
            }
            ddGender.DataSource = null;
            ddGender.DataSource = genderList;
            ddGender.DisplayMember = "DisplayName";
            ddGender.ValueMember = "Value";
            ddGender.SelectedIndex = 0;
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddNewPatient_Click(object sender, EventArgs e)
        {
            if (!dtDob.Value.HasValue)
            {
                MessageBox.Show("Vui lòng chọn ngày sinh.");
                return;
            }
            if (ddGender.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn giới tính.");
                return;
            }
            DateTime dob = dtDob.Value.Value;
            Gender gender = ddGender.SelectedIndex == 0 ? Gender.MALE : Gender.FEMALE;

            Patient patient = new Patient(name: tbName.Text, dob: dob, 
                gender: gender, 
                address: tbAddress.Text, phone: tbPhone.Text, 
                email: tbEmail.Text, healthInsuranceId: tbHealthInsuranceId.Text, 
                idCard: tbCardId.Text, medicalHistory: tbMedicalHistory.Text);

            addPatientEvent?.Invoke(patient, e);

            Close();
        }
    }
}

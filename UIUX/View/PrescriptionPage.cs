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

namespace UIUX.View
{
    public partial class PrescriptionPage: Form
    {

        public EventHandler backEvent;
        public EventHandler deleteEvent;
        private Patient patient;
        private Examination examination;
        List<Prescription> prescriptions;
        List<Medicine> medicines;

        public PrescriptionPage()
        {
            InitializeComponent();
        }

        public void SetData(Examination examination, Patient patient)
        {
            this.patient = patient;
            this.examination = examination;
            patient_name.Text = patient_name_2.Text = patient.name;
            previous_cause.Text = "Không có";
            diagnosis_name.Text = diagnosis_name_2.Text = examination.DiagnosisName;
            doctor_name.Text = "B.s " + examination.DoctorName; 
            date.Text = examination.ExaminationDate.ToString("dd/MM/yyyy");
            location.Text = patient.address;
            phone_number.Text = patient.phone;
            age.Text = (DateTime.Now.Year - patient.dob.Year + 1).ToString();
            gender.Text = patient.gender.GetDescription();
            medicalHistory.Text = patient.medicalHistory ?? "Không có";

            List<Prescription> prescriptions = new ExaminationBL().GetPrescription(examination.Id);
            if (prescriptions != null && prescriptions.Count > 0)
            {
                this.prescriptions = prescriptions;
                btnPrintPrescription.Visible = false;
                GetMedicines();
                Bill();
                ShowPrintPreview();
                return;
            }
            btnDeletePrescription.Visible = true;
        }

        private void GetMedicines()
        {
            medicines = new MedicineBL().GetMedicines(prescriptions);
            if (medicines == null)
            {
                return;
            }
        }

        private void btnAddMoreMedicine_Click(object sender, EventArgs e)
        {
            MedicineItem prescription = new MedicineItem();
            prescription.deleteEvent += (item, event_) =>
            {
                panelMedicineList.Controls.Remove((MedicineItem)item);
                btnAddMoreMedicine.Location = new Point(10, btnAddMoreMedicine.Location.Y - prescription.Height);
            };
            prescription.TopLevel = false;
            prescription.FormBorderStyle = FormBorderStyle.None;
            prescription.Dock = DockStyle.Top;
            prescription.BringToFront();
            panelMedicineList.Controls.Add(prescription);
            prescription.Show();
            btnAddMoreMedicine.Location = new Point(10, btnAddMoreMedicine.Location.Y + prescription.Height);
        }

        private void btnBack_MouseEnter(object sender, EventArgs e)
        {
            this.SelectNextControl(btnBack, true, true, true, true);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.SelectNextControl(btnBack, true, true, true, true);

            backEvent?.Invoke(this, e);
        }

        private void btnPrintPrescription_Click(object sender, EventArgs e)
        {
            List<TransferObject.Prescription> prescriptions = new List<TransferObject.Prescription>();
            if (panelMedicineList.Controls.Count == 1)
            {
                MessageBox.Show("Vui lòng thêm thuốc vào đơn thuốc.");
                return;
            }


            foreach (var item in panelMedicineList.Controls)
            {
                if (item is MedicineItem medicineItem)
                {
                    var data = medicineItem.GetData();
                    if (data == null)
                    {
                        MessageBox.Show("Vui lòng nhập đúng và đầy đủ thông tin thuốc.");
                        return;
                    }

                    prescriptions.Add(data);

                }
            }

            ExaminationBL examinationBL = new ExaminationBL();
            examinationBL.AddPrescription(examination, prescriptions);
            this.prescriptions = prescriptions;
            GetMedicines();
            Bill();
            ShowPrintPreview();
        }

        private void Bill()
        {
            total_cost.Text = new PrescriptionBL().MedicinesBill(prescriptions, medicines, patient.healthInsuranceId != "") + "đ";
            cost_title.Visible = true;
            total_cost.Visible = true;
        }

        private void ShowPrintPreview()
        {
            //panel1.Controls.Clear();
            printPreviewDialog.FormBorderStyle = FormBorderStyle.None;
            printPreviewDialog.TopLevel = false;
            panel1.Controls.Add(printPreviewDialog);
            printPreviewDialog.Dock = DockStyle.Fill;
            printPreviewDialog.BringToFront();
            printPreviewDialog.Show();
            printPreviewDialog.Dock = DockStyle.Fill;
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            float yPos = 100;
            float leftMargin = e.MarginBounds.Left;
            float rightMargin = e.MarginBounds.Right;
            float spacing = 27;
            Font titleFont = new Font("Arial", 24, FontStyle.Bold);
            Font regularFont = new Font("Arial", 14);
            Font boldFont = new Font("Arial", 14, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(Color.Black);

            // Tiêu đề
            graphics.DrawString("ĐƠN THUỐC", titleFont, brush, e.PageBounds.Width / 2 - e.Graphics.MeasureString("ĐƠN THUỐC", titleFont).Width / 2, yPos);

            graphics.DrawString(String.Format("Họ tên: {0}", patient.name), regularFont, brush, leftMargin, yPos += 100);
            graphics.DrawString(String.Format("Gới tính: {0}", patient.gender.GetDescription()), regularFont, brush, rightMargin - 70, yPos);
            graphics.DrawString(String.Format("Tuổi: {0}", (DateTime.Now.Year - patient.dob.Year + 1)), regularFont, brush, rightMargin - 200, yPos);
            graphics.DrawString(String.Format("Địa chỉ: {0}", patient.address), regularFont, brush, leftMargin, yPos += spacing);
            graphics.DrawString(String.Format("SĐT: {0}", patient.phone), regularFont, brush, rightMargin - 200, yPos);
            graphics.DrawString(String.Format("Chuẩn đoán: {0}", examination.DiagnosisName), regularFont, brush, leftMargin, yPos += spacing);
            graphics.DrawString(String.Format("Tiền căn: {0}", patient.medicalHistory), regularFont, brush, leftMargin, yPos += spacing);
            graphics.DrawString(String.Format("BHYT: {0}", patient.healthInsuranceId == "" ? "Không" : patient.healthInsuranceId), regularFont, brush,
                rightMargin - 200, yPos);

            graphics.DrawString("Thuốc", boldFont, brush, leftMargin, yPos += 120);
            graphics.DrawString("Số lượng", boldFont, brush, rightMargin - 130, yPos);

            yPos += 30;
            foreach (Prescription prescription in prescriptions)
            {
                string medicineName = new PrescriptionBL().GetMedicineName(prescription, medicines);
                int quantity = prescription.DateUses * (prescription.Moring + prescription.Noon + prescription.Evening);
                graphics.DrawString(medicineName, regularFont, brush, leftMargin, yPos);
                string s = String.Format("SL: {0} ({1} ngày)", quantity, prescription.DateUses);
                graphics.DrawString(s, regularFont, brush,                     
                    rightMargin - e.Graphics.MeasureString(s,regularFont).Width
                    , yPos);
                yPos += spacing;
                s = String.Format("Sáng: {0} - Trưa: {1} - Tối: {2}", prescription.Moring, prescription.Noon, prescription.Evening);
                graphics.DrawString(s, regularFont, brush, 
                    leftMargin,
                    yPos);
                yPos += spacing + 10;
            }

            DateTime dateTime = DateTime.Now;
            string date = String.Format("Ngày {0} tháng {1} năm {2}", dateTime.Day, dateTime.Month, dateTime.Year);
            graphics.DrawString(date, regularFont, brush, rightMargin - 200, yPos += 150);
            graphics.DrawString("Bác sĩ điều trị", regularFont, brush, rightMargin - 142, yPos += spacing);
            graphics.DrawString(doctor_name.Text, boldFont, brush,
                rightMargin - 200 + e.Graphics.MeasureString(date, regularFont).Width/2 - e.Graphics.MeasureString(doctor_name.Text, boldFont).Width / 2,
                yPos += 50);
        }

        private void btnDeletePrescription_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn chắc muốn xóa đơn khám này chứ?", "Xóa đơn khám", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ExaminationBL examinationBL = new ExaminationBL();
                if (examinationBL.Delete(examination.Id) == 1)
                {
                    MessageBox.Show("Xóa tài khoản thành công!");
                    deleteEvent?.Invoke(sender, e);
                    return;
                }
                MessageBox.Show("Xóa tài khoản thất bại!");
            }
        }
    }
}

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
using BusinessLayer;
using System.Windows.Media;

namespace UIUX.View
{
    public partial class MedicalTestsScriptionPage : Form
    {

        public EventHandler backEvent;
        public EventHandler deleteEvent;
        private Patient patient;
        private Indication indication;
        List<MedicineTestPrescription> medicineTestPrescriptions;
        List<TechnicalCatalog> technicalCatalogs;
        public MedicalTestsScriptionPage()
        {
            InitializeComponent();
        }

        public void SetData(Indication indication, Patient patient)
        {
            this.patient = patient;
            this.indication = indication;
            title.Text = String.Format("Phiếu chỉ định - {0}", indication.IndicationType);
            patient_name.Text = patient_name_2.Text = patient.name;
            previous_cause.Text = "Không có";
            diagnosis_name.Text = diagnosis_name_2.Text = indication.DiagnosisName;
            doctor_name.Text = "B.s " + indication.DoctorName;
            date.Text = indication.IndicationDate.ToString("dd/MM/yyyy");
            location.Text = patient.address;
            phone_number.Text = patient.phone;
            age.Text = (DateTime.Now.Year - patient.dob.Year + 1).ToString();
            gender.Text = patient.gender.GetDescription();
            medicalHistory.Text = patient.medicalHistory ?? "Không có";

            List<MedicineTestPrescription> medicineTestPrescriptions = new IndicationBL().GetTestsPrescription(indication.Id);
            if (medicineTestPrescriptions != null && medicineTestPrescriptions.Count > 0)
            {
                this.medicineTestPrescriptions = medicineTestPrescriptions;
                btnPrintTestsScription.Visible = false;
                GetTechnical();
                Bill();
                ShowPrintPreview();
                return;
            }
            btnDeletePrescription.Visible = true;
        }

        private void GetTechnical()
        {
            technicalCatalogs = new TechCatalogBL().GetTechnicalCatalogs(medicineTestPrescriptions);
        }

        private void Bill()
        {
            total_cost.Text = new PrescriptionBL().TechnicalBill(medicineTestPrescriptions, technicalCatalogs, patient.healthInsuranceId != "") + "đ";
            cost_title.Visible = true;
            total_cost.Visible = true;
        }


        private void btnAddMoreMedicine_Click(object sender, EventArgs e)
        {
            IndicationItem indicationItem = new IndicationItem(indication.IndicationType);
            indicationItem.deleteEvent += (item, event_) =>
            {
                panelMedicineList.Controls.Remove((IndicationItem)item);
                btnAddMoreMedicine.Location = new Point(10, btnAddMoreMedicine.Location.Y - indicationItem.Height);
            };
            indicationItem.TopLevel = false;
            indicationItem.FormBorderStyle = FormBorderStyle.None;
            indicationItem.Dock = DockStyle.Top;
            indicationItem.BringToFront();
            panelMedicineList.Controls.Add(indicationItem);
            indicationItem.Show();
            btnAddMoreMedicine.Location = new Point(10, btnAddMoreMedicine.Location.Y + indicationItem.Height);
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

        private void btnAddNewPatient_Click(object sender, EventArgs e)
        {
            try
            {
                List<MedicineTestPrescription> medicineTestPrescriptions = new List<MedicineTestPrescription>();

                foreach (var item in panelMedicineList.Controls)
                {
                    if (item is IndicationItem indicationItem)
                    {
                        var data = indicationItem.GetData();
                        if (data ==  null)
                        {
                            MessageBox.Show("Vui lòng nhập đầy đủ thổng tin.");
                            return;
                        }
                        medicineTestPrescriptions.Add(data);
                    }
                }
                if (medicineTestPrescriptions.Count > 0)
                {
                    IndicationBL indicationBL = new IndicationBL();

                    if (indicationBL.AddTestsScription(indication, medicineTestPrescriptions) == 0)
                    {
                        Console.WriteLine("MedicalTestsScription Error");
                        return;
                    }
                    this.medicineTestPrescriptions = medicineTestPrescriptions;
                    ShowPrintPreview();
                }
                MessageBox.Show("Vui lòng thêm chỉ định.");
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Cancel;
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowPrintPreview()
        {
            panel1.Controls.Clear();
            printPreviewDialog.FormBorderStyle = FormBorderStyle.None;
            printPreviewDialog.TopLevel = false;
            printPreviewDialog.Dock = DockStyle.Fill;
            panel1.Controls.Add(printPreviewDialog);
            printPreviewDialog.Dock = DockStyle.Fill;
            printPreviewDialog.Show();

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
            SolidBrush brush = new SolidBrush(System.Drawing.Color.Black);
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Black, 1);
            // Tiêu đề
            string title = String.Format("PHIẾU CHỈ ĐỊNH {0}", indication.IndicationType);
            graphics.DrawString(title, titleFont, brush, e.PageBounds.Width / 2 - e.Graphics.MeasureString(title, titleFont).Width / 2, yPos);

            graphics.DrawString(String.Format("Họ tên: {0}", patient.name), regularFont, brush, leftMargin, yPos += 100);
            graphics.DrawString(String.Format("Gới tính: {0}", patient.gender.GetDescription()), regularFont, brush, rightMargin - 70, yPos);
            graphics.DrawString(String.Format("Tuổi: {0}", (DateTime.Now.Year - patient.dob.Year + 1)), regularFont, brush, rightMargin - 200, yPos);
            graphics.DrawString(String.Format("Địa chỉ: {0}", patient.address), regularFont, brush, leftMargin, yPos += spacing);
            graphics.DrawString(String.Format("SĐT: {0}", patient.phone), regularFont, brush, rightMargin - 200, yPos);
            graphics.DrawString(String.Format("Chuẩn đoán: {0}", indication.DiagnosisName), regularFont, brush, leftMargin, yPos += spacing);
            graphics.DrawString(String.Format("Tiền căn: {0}", patient.medicalHistory), regularFont, brush, leftMargin, yPos += spacing);
            graphics.DrawString(String.Format("BHYT: {0}", patient.healthInsuranceId == "" ? "Không" : patient.healthInsuranceId), regularFont, brush,
                rightMargin - 200, yPos);
            yPos += 120;

            string[] headers = { "Tên chỉ định", "Số lượng", "Ghi chú" };
            float tableWidth = rightMargin - leftMargin - 120;
            float[] columnWidths = { tableWidth*0.6f, 120 , tableWidth*0.4f};
            float rowHeight = regularFont.GetHeight() + 7;
            float xPos = leftMargin;

            for (int i = 0; i < headers.Length; i++)
            {
                graphics.DrawRectangle(pen, xPos, yPos, columnWidths[i], rowHeight);
                graphics.DrawString(headers[i], boldFont, brush, xPos + 5, yPos + 5);
                xPos += columnWidths[i];
            }
            yPos += 34;
            float y = yPos;
            foreach (MedicineTestPrescription m in medicineTestPrescriptions)
            {
                xPos = leftMargin;
                float yPos_ = yPos;
                // Column 2
                graphics.DrawString(m.quanlity.ToString(), regularFont, brush, leftMargin + columnWidths[0] + 5, yPos + 5);

                // Column 1
                string[] nameArr = (new PrescriptionBL().GetTechnicalName(m, technicalCatalogs) + " ").Split(' ');
                string name = "";
                for (int i = 0; i < nameArr.Length; i++)
                {
                    if (graphics.MeasureString(name, regularFont).Width < columnWidths[0] - 20 && i != nameArr.Length-1)
                    {
                        name += nameArr[i] + " ";
                    } else
                    {
                        Console.WriteLine(name);
                        graphics.DrawString(name, regularFont, brush, xPos + 5, yPos + 5);
                        yPos += 27;
                        name = nameArr[i] + " ";
                    }
                }

                // Column 3
                nameArr = m.note.Split(' ');
                name = "";
                for (int i = 0; i < nameArr.Length; i++)
                {
                    if (graphics.MeasureString(name, regularFont).Width < columnWidths[2] - 20 && i != nameArr.Length - 1)
                    {
                        name += nameArr[i] + " ";
                    }
                    else
                    {
                        Console.WriteLine(name);
                        graphics.DrawString(name, regularFont, brush, xPos + columnWidths[0] + columnWidths[1] + 5, yPos_ += 30);
                        name = nameArr[i] + " ";
                    }
                }


                graphics.DrawRectangle(pen, xPos, y, columnWidths[0], (yPos > yPos_?yPos:yPos_)+ 5 - y);
                graphics.DrawRectangle(pen, xPos, y, columnWidths[0] + columnWidths[1], (yPos > yPos_?yPos:yPos_)+ 5 - y);
                graphics.DrawRectangle(pen, xPos, y, columnWidths[0] + columnWidths[1] + columnWidths[2], (yPos > yPos_ ? yPos : yPos_) + 5 - y);

                yPos += 5;
            }

            DateTime dateTime = DateTime.Now;
            string date = String.Format("Ngày {0} tháng {1} năm {2}", dateTime.Day, dateTime.Month, dateTime.Year);
            graphics.DrawString(date, regularFont, brush, rightMargin - 200, yPos += 150);
            graphics.DrawString("Bác sĩ điều trị", regularFont, brush, rightMargin - 142, yPos += spacing);
            graphics.DrawString(doctor_name.Text, boldFont, brush,
                rightMargin - 200 + e.Graphics.MeasureString(date, regularFont).Width / 2 - e.Graphics.MeasureString(doctor_name.Text, boldFont).Width / 2,
                yPos += 50);
        }

        private void btnDeletePrescription_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn chắc muốn xóa phiếu chỉ định này chứ?", "Xóa phiếu chỉ định", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ExaminationBL examinationBL = new ExaminationBL();
                if (examinationBL.Delete(indication.Id) == 1)
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

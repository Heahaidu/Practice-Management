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

namespace UIUX.View
{
    public partial class MedicalTestsScriptionPage : Form
    {

        public EventHandler backEvent;
        private Patient patient;
        public MedicalTestsScriptionPage(Examination examination, Patient patient)
        {
            InitializeComponent();
            this.patient = patient;
        }

        public MedicalTestsScriptionPage()
        {
            InitializeComponent();
        }

        private void btnAddMoreMedicine_Click(object sender, EventArgs e)
        {
            IndicationItem indicationItem = new IndicationItem();
            indicationItem.deleteEvent += (item, event_) =>
            {
                panelMedicineList.Controls.Remove((MedicineItem)item);
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
                List<Indication> indications = new List<Indication>();
                StringBuilder summary = new StringBuilder("Các chỉ định đã chọn:\n");

                foreach (Control control in panelMedicineList.Controls)
                {
                    if (control is IndicationItem indicationItem)
                    {
                        int? technicalCatalogId = indicationItem.GetSelectedTechnicalCatalogId();
                        string technicalCatalogName = indicationItem.GetSelectedTechnicalCatalogName();
                        float? price = indicationItem.GetSelectedTechnicalCatalogPrice();

                        if (technicalCatalogId.HasValue && price.HasValue)
                        {
                            indications.Add(new Indication(
                                indicationDate: DateTime.Now,
                                indicationType: technicalCatalogName,
                                doctorName: "Doctor Name",
                                diagnosisName: "Diagnosis",
                                notes: $"Price: {price.Value}",
                                patientId: patient.id,
                                doctorId: UserSession.Instance.CurrentUser?.id ?? 1,
                                1
                            ));

                            summary.AppendLine($"ID: {technicalCatalogId.Value}, Tên: {technicalCatalogName}, Giá: {price.Value}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Cancel;
                MessageBox.Show(ex.Message);
            }
        }
    }
}

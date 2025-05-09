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

        public PrescriptionPage(Examination examination)
        {
            InitializeComponent();
        }

        public PrescriptionPage()
        {
            InitializeComponent();
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
    }
}

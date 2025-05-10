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
    public partial class MedicalTestsScriptionPage : Form
    {

        public EventHandler backEvent;

        public MedicalTestsScriptionPage(Examination examination)
        {
            InitializeComponent();
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
    }
}

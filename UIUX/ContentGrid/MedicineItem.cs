using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace UIUX.View
{
    public partial class MedicineItem: Form
    {
        public EventHandler deleteEvent;
        public MedicineItem()
        {
            InitializeComponent();
            LoadMedicine();
        }

        public TransferObject.Prescription GetData()
        {
            if (ddMedicine.SelectedIndex == -1) return null;
            try
            {
                return new TransferObject.Prescription(
                    (int)ddMedicine.SelectedValue,
                    int.Parse(tbDayuse.Text),
                    int.Parse(tbMorning.Text),
                    int.Parse(tbNoon.Text),
                    int.Parse(tbEvening.Text),
                    tbNote.Text
                );
            } catch { return null; }

        }

        private void MedicineMenu_Load(object sender, EventArgs e)
        {

        }

        public void LoadMedicine()
        {

            ddMedicine.DataSource = new MedicineBL().GetMedicines();
            ddMedicine.DisplayMember = "name";
            ddMedicine.ValueMember = "id";

            ddMedicine.SelectedIndex = -1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteEvent?.Invoke(this, e);
        }
        private void btnDelete_Enter(object sender, EventArgs e)
        {
            this.SelectNextControl(btnDelete, true, true, true, true);
        }
    }
}

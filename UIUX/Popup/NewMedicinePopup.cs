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
    public partial class NewMedicinePopup: Form
    {

        public EventHandler addMedicineEvent;
        public NewMedicinePopup()
        {
            InitializeComponent();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddNewMedicine_Click(object sender, EventArgs e)
        {
            Medicine medicine = new Medicine("Paracetamol", "A", "Tablet", "Take 1 tablet every 6 hours", 50000, 60000, 30, DateTime.Now, DateTime.Now.AddDays(30), DateTime.Now.AddDays(30), "", "500ml");
            addMedicineEvent?.Invoke(medicine, e);
            Close();
        }
    }
}

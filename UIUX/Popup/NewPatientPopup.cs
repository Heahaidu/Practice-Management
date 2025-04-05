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
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddNewPatient_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient("Nguyen Van A", DateTime.Now, Gender.MALE, "HCM", "", "", "", "", "");
            addPatientEvent?.Invoke(patient, e);
            Close();
        }
    }
}

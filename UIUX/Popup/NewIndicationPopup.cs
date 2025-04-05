using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIUX.Popup
{
    public partial class NewIndicationPopup: Form
    {

        public EventHandler addIndicationEvent;

        public NewIndicationPopup()
        {
            InitializeComponent();
            dateIndication.Value = DateTime.Now;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddNewIndication_Click(object sender, EventArgs e)
        {
            // Create a new indication object with dummy data
            TransferObject.Indication indication = new TransferObject.Indication(DateTime.Now, "X-ray", "Dr. Smith", "Normal", "No issues detected");
            addIndicationEvent?.Invoke(indication, e);
            Close();
        }
    }
}

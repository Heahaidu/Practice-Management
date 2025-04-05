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
    public partial class NewExaminationPopup: Form
    {

        public EventHandler addExaminationEvent;

        public NewExaminationPopup()
        {
            InitializeComponent();
            dateExamination.Value = DateTime.Now;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddNewExamination_Click(object sender, EventArgs e)
        {
            // Create a new examination object with dummy data
            TransferObject.Examination examination = new TransferObject.Examination(DateTime.Now, "Blood Test", "Dr. Smith", "Normal", "No issues detected");
            addExaminationEvent?.Invoke(examination, e);
            Console.WriteLine(examination.ToString());
            Close();
        }
    }
}

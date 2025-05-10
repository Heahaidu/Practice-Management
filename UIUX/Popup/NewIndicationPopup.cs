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

namespace UIUX.Popup
{
    public partial class NewIndicationPopup: Form
    {

        public EventHandler addIndicationEvent;
        private int patientId;
        public NewIndicationPopup()
        {
            InitializeComponent();
            dtIndication.Value = DateTime.Now;
        }

        public NewIndicationPopup(int patientId)
        {
            InitializeComponent();
            dtIndication.Value = DateTime.Now;
            this.patientId = patientId;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddNewIndication_Click(object sender, EventArgs e)
        {

            DateTime indicationDate = dtIndication.Value.Value;
            Indication indication = new Indication(indicationDate:  indicationDate,
                indicationType: tbIndicationType.Text, doctorName: tbDoctorName.Text,
                diagnosisName: tbDiagnosisName.Text, notes: tbNotes.Text, patientId: patientId, doctorId: UserSession.Instance.CurrentUser?.id ?? 1, 1);
            addIndicationEvent?.Invoke(indication, e);
            Close();
        }
    }
}

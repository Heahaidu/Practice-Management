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
using TransferObject;

namespace UIUX.View
{
    public partial class IndicationItem : Form
    {
        public EventHandler deleteEvent;
        private string indicationType;
        public IndicationItem(string indicationType)
        {
            InitializeComponent();
            this.indicationType = indicationType;
            LoadTechnicalCatalogs();
        }

        public MedicineTestPrescription GetData()
        {
            try
            {
                if (ddTeachnicalCatalog.SelectedValue == null) return null;
                return new MedicineTestPrescription(
                    (int)ddTeachnicalCatalog.SelectedValue,
                    int.Parse(tbQuantity.Text),
                    tbNote.Text); ;
            }
            catch { return null; }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteEvent?.Invoke(this, e);
        }
        private void btnDelete_Enter(object sender, EventArgs e)
        {
            this.SelectNextControl(btnDelete, true, true, true, true);
        }

        private void LoadTechnicalCatalogs()
        {
            ddTeachnicalCatalog.DataSource = new TechCatalogBL().GetTechnicalCatalogsOfType(indicationType);
            ddTeachnicalCatalog.DisplayMember = "name";
            ddTeachnicalCatalog.ValueMember = "id";

            ddTeachnicalCatalog.SelectedIndex = -1;
        }
    }
}

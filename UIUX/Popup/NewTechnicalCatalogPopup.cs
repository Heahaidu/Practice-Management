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
    public partial class NewTechnicalCatalogPopup : Form
    {

        public EventHandler addTechnicalCatalogEvent;

        public NewTechnicalCatalogPopup()
        {
            InitializeComponent();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddNewTechnical_Click(object sender, EventArgs e)
        {
            TechnicalCatalog technicalCatalog = new TechnicalCatalog("Blood Test", "Blood test", 120000, 100000, "");
            addTechnicalCatalogEvent?.Invoke(technicalCatalog, e);
            Close();
        }
    }
}

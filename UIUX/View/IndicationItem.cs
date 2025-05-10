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
        public IndicationItem()
        {
            InitializeComponent();
            LoadTechnicalCatalogs();
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
            ddTeachnicalCatalog.DataSource = new TechCatalogBL().GetTechnicalCatalogs();
            ddTeachnicalCatalog.DisplayMember = "Name";
            ddTeachnicalCatalog.ValueMember = "Id";
        }

        public int? GetSelectedTechnicalCatalogId()
        {
            if (ddTeachnicalCatalog.SelectedValue != null)
            {
                return Convert.ToInt32(ddTeachnicalCatalog.SelectedValue);
            }
            return null;
        }

        public string GetSelectedTechnicalCatalogName()
        {
            return ddTeachnicalCatalog.Text;
        }

        public float? GetSelectedTechnicalCatalogPrice()
        {
            if (ddTeachnicalCatalog.SelectedItem is TechnicalCatalog selectedItem)
            {
                return selectedItem.price;
            }
            return null;
        }
    }
}

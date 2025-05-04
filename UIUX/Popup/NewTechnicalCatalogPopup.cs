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

            try
            {
                float value1 = float.Parse(tbDiscountPrice.Text);
                float value2 = float.Parse(tbPrice.Text);

            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            TechnicalCatalog technicalCatalog = new TechnicalCatalog(
                name: tbNameTech.Text, type: ddTypeTech.Text,
                price: float.Parse(tbPrice.Text), discountPrice: float.Parse(tbDiscountPrice.Text),
                description: tbDescriptionTech.Text);


            addTechnicalCatalogEvent?.Invoke(technicalCatalog, e);
            Close();
        }
    }
}

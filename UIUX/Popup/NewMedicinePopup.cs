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

        protected void btnAddNewMedicine_Click(object sender, EventArgs e)
        {
            DateTime manufacturingDate = dtManufacturingDate.Value.Value;
            DateTime expiryDate = dtExpiryDate.Value.Value;
            DateTime importDate = dtImportDate.Value.Value;
            try
            {
                float value1 = float.Parse(tbDiscountPrice.Text);
                float value2 = float.Parse(tbPrice.Text);
                float value3 = int.Parse(tbQuantity.Text);

                Medicine medicine = new Medicine(name: tbNameMed.Text.Replace("-", ""), manufacturer: tbManafacture.Text,
                    type: tbTypeMed.Text, description: tbDescriptionMed.Text,
                    discountPrice: float.Parse(tbDiscountPrice.Text),
                    price: float.Parse(tbPrice.Text), quantity: int.Parse(tbQuantity.Text),
                    manufacturingDate: manufacturingDate, expiryDate: expiryDate,
                    importDate: importDate, usage: tbUsage.Text, dosage: tbDousage.Text);

                addMedicineEvent?.Invoke(medicine, e);

                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }


        }
    }
}

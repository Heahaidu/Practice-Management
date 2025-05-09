using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TransferObject;

namespace UIUX.Popup
{
    public class MedicineEditPopup : NewMedicinePopup
    {
        public EventHandler editMedicine;
        private Medicine medicine;
        public MedicineEditPopup(Medicine medicine)
        {
            this.medicine = medicine;
            title.Text = "Chỉnh sửa thông tin thuốc";
            btnAddNewMedicine.Text = "Cập nhật";

            btnDeleteMedicine.Visible = true;
            btnDeleteMedicine.Click += btnDeleteMedicine_Click;

            tbNameMed.Text = medicine.name;
            tbNameMed.Enabled = false;

            tbManafacture.Text = medicine.manufacturer;
            tbManafacture.Enabled = false;

            tbDousage.Text = medicine.dosage;
            tbDousage.Enabled = false;

            tbUsage.Text = medicine.usage;
            tbUsage.Enabled = false;

            tbTypeMed.Text = medicine.type;
            tbTypeMed.Enabled = false;

            tbDescriptionMed.Text = medicine.description;

            tbQuantity.Text = medicine.quantity.ToString();

            tbPrice.Text = medicine.price.ToString();

            tbDiscountPrice.Text = medicine.discountPrice.ToString();

            dtManufacturingDate.Value = medicine.manufacturingDate;
            dtManufacturingDate.Enabled = false;

            dtExpiryDate.Value = medicine.expiryDate;
            dtExpiryDate.Enabled = false;

            dtImportDate.Value = medicine.importDate;
            dtImportDate.Enabled = false;

            btnAddNewMedicine.Click -= btnAddNewMedicine_Click;
            btnAddNewMedicine.Click += btnEditMedicine_Click;

        }

        private void btnEditMedicine_Click(object sender, EventArgs e)
        {
            DateTime manufacturingDate = dtManufacturingDate.Value.Value;
            DateTime expiryDate = dtExpiryDate.Value.Value;
            DateTime importDate = dtImportDate.Value.Value;
            try
            {
                float value1 = float.Parse(tbDiscountPrice.Text);
                float value2 = float.Parse(tbPrice.Text);
                float value3 = int.Parse(tbQuantity.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            Medicine medicine = new Medicine(id: this.medicine.id, name: tbNameMed.Text, manufacturer: tbManafacture.Text,
            type: tbTypeMed.Text, description: tbDescriptionMed.Text,
            discountPrice: float.Parse(tbDiscountPrice.Text),
            price: float.Parse(tbPrice.Text), quantity: int.Parse(tbQuantity.Text),
            manufacturingDate: manufacturingDate, expiryDate: expiryDate,
            importDate: importDate, usage: tbUsage.Text, dosage: tbDousage.Text);
            editMedicine?.Invoke(medicine, e);


            Close();
        }

        public void btnDeleteMedicine_Click(object sender, EventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thuốc này không?", "Xóa thuốc", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                MedicineBL medicineBL = new MedicineBL();
                int success = medicineBL.Delete(medicine.id);

                if (success == 0)
                {
                    MessageBox.Show("Xóa thuốc không thành công");
                    return;
                }
                editMedicine?.Invoke(medicine, e);
                Close();
            }

        }
    }
}

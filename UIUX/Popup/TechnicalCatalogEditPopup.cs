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
    public class TechnicalCatalogEditPopup : NewTechnicalCatalogPopup
    {
        private TechnicalCatalog technicalCatalog;

        public TechnicalCatalogEditPopup(TechnicalCatalog technicalCatalog)
        {
            this.technicalCatalog = technicalCatalog;
            SetData();
            title.Text = "Cập nhật thông tin chỉ định";
            btnAddNewTechnical.Text = "Cập nhật";
            btnAddNewTechnical.Click -= btnAddNewTechnical_Click;
            btnAddNewTechnical.Click += btnSaveEdit_Click;

            ddTypeTech.Enabled = false;
            btnDeleteTech.Visible = true;
            btnDeleteTech.Click += btnDeleteTech_Click;
        }

        private void btnDeleteTech_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.No)
                {
                    return;
                }
                BusinessLayer.TechCatalogBL techCatalogBL = new BusinessLayer.TechCatalogBL();
                int success = techCatalogBL.Delete(technicalCatalog.id);
                if (success == 0)
                {
                    MessageBox.Show("Xóa không thành công");
                    return;
                }
                UpdateTechnicalCatalogEvent?.Invoke(technicalCatalog, e);
                Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SetData()
        {
            tbNameTech.Text = technicalCatalog.name;
            ddTypeTech.Text = technicalCatalog.type;
            tbPrice.Text = technicalCatalog.price.ToString();
            tbDiscountPrice.Text = technicalCatalog.discountPrice.ToString();
            tbDescriptionTech.Text = technicalCatalog.description;
        }
        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            TechnicalCatalog technicalCatalog = new TechnicalCatalog(
                id: this.technicalCatalog.id,
                name: tbNameTech.Text, type: ddTypeTech.Text,
                price: float.Parse(tbPrice.Text), discountPrice: float.Parse(tbDiscountPrice.Text),
                description: tbDescriptionTech.Text);

            TechCatalogBL techCatalogBL = new TechCatalogBL();
            if (techCatalogBL.Update(technicalCatalog) == 0)
            {
                MessageBox.Show("Cập nhập thông tin thất bại.");
                return;
            }

            UpdateTechnicalCatalogEvent?.Invoke(technicalCatalog, e);
            Close();
        }

       
    }
}

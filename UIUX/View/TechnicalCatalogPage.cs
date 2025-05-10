using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;
using UIUX.Popup;

namespace UIUX.View
{
    public partial class TechnicalCatalogPage: Form
    {
        private static ObservableCollection<TransferObject.TechnicalCatalog> technicalCatalogs;
        public TechnicalCatalogPage()
        {
            InitializeComponent();
            LoadTech();
            
            sfDataGrid.FilterRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top;
            sfDataGrid.Columns["id"].Visible = false;
            sfDataGrid.Columns["description"].MinimumWidth = 500;
        }

        private void LoadTech()
        {
           
            sfDataGrid.DataSource = new TechCatalogBL().GetTechnicalCatalogs();
        }

        private void addNewTechnicalCatalog_btn_Click(object sender, EventArgs e)
        {
            NewTechnicalCatalogPopup newTechnicalCatalogPopup = new NewTechnicalCatalogPopup();
            newTechnicalCatalogPopup.UpdateTechnicalCatalogEvent += UpdateTechnicalCatalog;
            newTechnicalCatalogPopup.ShowDialog();
        }

        protected void UpdateTechnicalCatalog(object technicalCatalog, EventArgs e)
        {
            try
            {
                LoadTech();
            }
            catch (Exception ex) {
                this.DialogResult = DialogResult.Cancel;
                MessageBox.Show(ex.Message);
            }
        }

        private void sfDataGrid_CellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            if (e.DataRow.RowIndex == 1) return;
            TechnicalCatalog technicalCatalog = (TechnicalCatalog)sfDataGrid.SelectedItem;
            TechnicalCatalogEditPopup technicalCatalogEditPopup = new TechnicalCatalogEditPopup(technicalCatalog);
            technicalCatalogEditPopup.Show();

        }
    }
}

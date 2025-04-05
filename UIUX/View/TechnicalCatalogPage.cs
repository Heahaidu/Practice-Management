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

            technicalCatalogs = new ObservableCollection<TransferObject.TechnicalCatalog>();

            sfDataGrid.DataSource = technicalCatalogs;
            sfDataGrid.FilterRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top;
        }

        private void addNewTechnicalCatalog_btn_Click(object sender, EventArgs e)
        {
            NewTechnicalCatalogPopup newTechnicalCatalogPopup = new NewTechnicalCatalogPopup();
            newTechnicalCatalogPopup.addTechnicalCatalogEvent += AddNewTechnicalCatalog;
            newTechnicalCatalogPopup.ShowDialog();
        }

        private void AddNewTechnicalCatalog(object technicalCatalog, EventArgs e)
        {
            technicalCatalogs.Add((TechnicalCatalog)technicalCatalog);
        }

    }
}

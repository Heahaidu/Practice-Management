using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIUX.Popup;

namespace UIUX.View
{
    public partial class TechnicalCatalogPage: Form
    {
        public TechnicalCatalogPage()
        {
            InitializeComponent();

            sfDataGrid.DataSource = new List<TransferObject.TechnicalCatalog>();    
            sfDataGrid.FilterRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top;
        }

        private void addNewTechnicalCatalog_btn_Click(object sender, EventArgs e)
        {
            NewTechnicalCatalogPopup newTechnicalCatalogPopup = new NewTechnicalCatalogPopup();
            newTechnicalCatalogPopup.ShowDialog();
        }
    }
}

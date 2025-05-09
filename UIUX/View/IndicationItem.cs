using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIUX.View
{
    public partial class IndicationItem : Form
    {
        public EventHandler deleteEvent;
        public IndicationItem()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteEvent?.Invoke(this, e);
        }
        private void btnDelete_Enter(object sender, EventArgs e)
        {
            this.SelectNextControl(btnDelete, true, true, true, true);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIUX.Popup
{
    public partial class AccountPopup: Form
    {

        public EventHandler Clicked;

        public AccountPopup()
        {
            InitializeComponent();
        }

        private void ShowAccountSettingPopup_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            Clicked?.Invoke(sender, e);
        }

        public void Refesh()
        {
            lbDisplayName.Text = BusinessLayer.UserSession.Instance.CurrentUser.displayName;
        }

    }
}

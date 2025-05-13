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
        public EventHandler LogoutEvent;
        public AccountPopup()
        {
            InitializeComponent();
        }

        private void ShowAccountSettingPopup_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            Clicked?.Invoke(null, null);
        }

        public void Refesh()
        {
            lbDisplayName.Text = BusinessLayer.UserSession.Instance.CurrentUser.displayName;
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            LogoutEvent?.Invoke(sender, e);
        }
    }
}

using BusinessLayer;
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
    public partial class AccountSettingPopup: Form
    {

        public EventHandler changeDisplayNameEvent;
        public AccountSettingPopup()
        {
            InitializeComponent();

            Refesh();

        }

        private void ChangeUsernameBtn_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void btnChangePreferredName_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if (tbDisplayName.Text != BusinessLayer.UserSession.Instance.CurrentUser.displayName)
            {
                BusinessLayer.UserSession.Instance.CurrentUser.displayName = tbDisplayName.Text;
                changeDisplayNameEvent?.Invoke(sender, e);
                Refesh();
            }

        }

        private void btnChangeEmail_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;

        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;

        }

        private void tbDisplayName_TextChange(object sender, EventArgs e)
        {
            if (tbDisplayName.Text != BusinessLayer.UserSession.Instance.CurrentUser.displayName)
            {
                btnChangePreferredName.Enabled = true;
            }
            else
            {
                btnChangePreferredName.Enabled = false;
            }
        }

        public void Refesh()
        {
            btnChangePreferredName.Enabled = false;

            tbDisplayName.Text = BusinessLayer.UserSession.Instance.CurrentUser.displayName;
            lbUsername.Text = BusinessLayer.UserSession.Instance.CurrentUser.username;
            lbEmail.Text = BusinessLayer.UserSession.Instance.CurrentUser.email;
        }
    }
}

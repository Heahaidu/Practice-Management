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
        public AccountSettingPopup()
        {
            InitializeComponent();
        }

        private void ChangeUsernameBtn_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void btnChangePreferredName_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;

        }

        private void btnChangeEmail_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;

        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;

        }
    }
}

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
using TransferObject;

namespace UIUX.DataView
{
    public partial class AccountItem: Form
    {
        private User user;
        public AccountItem(User user)
        {
            InitializeComponent();
            this.user = user;

            this.lbUsernameName.Text = user.username + "\\" + user.displayName;
            this.lbAuthority.Text = "";
            this.lbEmail.Text = user.email;

            if (UserSession.Instance.CurrentUser.username == user.username)
            {
                this.btnDeleteAccount.Visible = false;
            }
            else
            {
                this.btnDeleteAccount.Visible = true;
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteAccount_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn chắc muốn xóa tài khoản này chứ?", "Xóa tài khoản", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //UserBL userBL = new UserBL();
                //userBL.Delete(user.username);
                //this.Visible = false;
                //this.Dispose();
            }
        }
    }
}

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
        public EventHandler deleteAccountEvent;
        public AccountItem(User user)
        {
            InitializeComponent();
            this.user = user;

            this.lbUsernameName.Text = user.username + "\\" + user.displayName;
            this.lbAuthority.Text = user.level == 3? "Trưởng khoa": "Bác sĩ";
            this.lbEmail.Text = user.email;

            if(UserSession.Instance.CurrentUser.level == 3 && UserSession.Instance.CurrentUser.username != user.username)
            {
                this.btnDeleteAccount.Visible = true;
            }
            else
            {
                this.btnDeleteAccount.Visible = false;
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
                AccountBL accountBL = new AccountBL();
                if (accountBL.Delete(user.username) == 1)
                {
                    MessageBox.Show("Xóa tài khoản thành công!");
                    deleteAccountEvent?.Invoke(sender, e);
                    return;
                }
                MessageBox.Show("Xóa tài khoản thất bại!");
            }
        }
    }
}

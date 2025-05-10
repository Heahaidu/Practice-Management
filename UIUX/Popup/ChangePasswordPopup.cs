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
    public partial class ChangePasswordPopup: Form
    {
        public ChangePasswordPopup()
        {
            InitializeComponent();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            AccountBL accountBL = new AccountBL();
            
            if (accountBL.ChangePassword(tbOldPassword.Text, tbNewPassword.Text, tbConfirmNewPassword.Text))
            {
                MessageBox.Show("Thay đổi mật khẩu thành công.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Thay đổi mật khẩu thất bại.\n Vui lòng kiểm tra lại mật khẩu hiện tại và đảm bảo mật khẩu mới khớp.");
            }
        }
    }
}

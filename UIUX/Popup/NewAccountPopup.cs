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

namespace UIUX.Popup
{
    public partial class NewAccountPopup: Form
    {
        public EventHandler createAccountEvent;
        public NewAccountPopup()
        {
            InitializeComponent();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Level: " + ddLevel.SelectedItem);
            AccountBL accountBL = new AccountBL();
            int re = 0;
            if (tbDisplayName.Text == "" || tbEmail.Text == "" || tbPassword.Text == "" || tbUsername.Text == "" || ddLevel.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            re = accountBL.NewAccount(
                new User()
                {
                    displayName = tbDisplayName.Text,
                    email = tbEmail.Text,
                    password = tbPassword.Text,
                    level = int.Parse(ddLevel.SelectedItem.ToString()),
                    username = tbUsername.Text,
                }
            );


            if (re == 0)
            {
                MessageBox.Show("Tạo tài khoản thành công! Có thể tên đăng nhập đã tồn tại");
                return;
            }
            MessageBox.Show("Tạo tài khoản thành công!");
            createAccountEvent?.Invoke(sender, e);
            this.Close();
        }
    }
}

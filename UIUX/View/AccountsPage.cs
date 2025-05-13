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
using UIUX.DataView;
using UIUX.Popup;

namespace UIUX.View
{
    public partial class AccountsPage: Form
    {
        public AccountsPage()
        {
            InitializeComponent();
            if (UserSession.Instance.CurrentUser.level != 3)
            {
                addNewMedicine_btn.Visible = false;
            }
            else
            {
                addNewMedicine_btn.Visible = true;
            }
            LoadAccounts();
        }

        private void LoadAccounts()
        {
            AccountBL accountBL = new AccountBL();
            List<User> users = accountBL.GetUsers();

            foreach (User user in users)
            {
                AccountItem accountItem = new AccountItem(user);
                accountItem.deleteAccountEvent += (sender_, e_) =>
                {
                    panelAccount.Controls.Remove(accountItem);
                };
                accountItem.TopLevel = false;
                accountItem.FormBorderStyle = FormBorderStyle.None;
                accountItem.Dock = DockStyle.Top;
                accountItem.BringToFront();

                panelAccount.Controls.Add(accountItem);
                accountItem.Show();
            }

        }

        private void addNewMedicine_btn_Click(object sender, EventArgs e)
        {
            NewAccountPopup newAccountPopup = new NewAccountPopup();
            newAccountPopup.createAccountEvent += (sender_, e_) =>
            {
                panelAccount.Controls.Clear();
                LoadAccounts();
            };
            newAccountPopup.ShowDialog();
        }
    }

}

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

namespace UIUX.View
{
    public partial class AccountsPage: Form
    {
        public AccountsPage()
        {
            InitializeComponent();
            LoadAccounts();
        }

        private void LoadAccounts()
        {
            AccountBL accountBL = new AccountBL();
            List<User> users = accountBL.GetUsers();

            foreach (User user in users)
            {
                AccountItem accountItem = new AccountItem(user);
                accountItem.TopLevel = false;
                accountItem.FormBorderStyle = FormBorderStyle.None;
                accountItem.Dock = DockStyle.Top;
                accountItem.BringToFront();

                panelAccount.Controls.Add(accountItem);
                accountItem.Show();
            }

        }
    }

}

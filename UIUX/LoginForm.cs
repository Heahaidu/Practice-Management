using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIUX
{
    public partial class LoginForm: Form
    {
        public LoginForm()
        {
            InitializeComponent();
            //BusinessLayer.AuthenticationService authenticationService = new BusinessLayer.AuthenticationService();
            //(bool success, TransferObject.User user) = authenticationService.Login("admin", "password");
            //if (success)
            //{
            //    // Proceed to the next form or functionality
            //    Main main = new Main();
            //    this.Hide();

            //    main.Show();
            //}

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            BusinessLayer.AuthenticationService authenticationService = new BusinessLayer.AuthenticationService();
            bool success = authenticationService.Login(tbUsername.Text, tbPassword.Text);
            if (success)
            {
                // Proceed to the next form or functionality
                Main main = new Main();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}

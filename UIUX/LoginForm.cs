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
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            BusinessLayer.AuthenticationService authenticationService = new BusinessLayer.AuthenticationService();
            bool success = authenticationService.Login(tbUsername.Text, tbPassword.Text);
            if (success)
            {
                // Proceed to the next form or functionality
                Main main = new Main(this);
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        public void ResetTextBox()
        {
            tbPassword.Text = "";
            tbUsername.Text = "";
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Trigger the login button click event
                btnLogin.Focus();
                btnLogin.PerformClick();
            }
        }

        private void tbUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Trigger the password textbox focus
                tbPassword.Focus();
            }
        }
    }
}

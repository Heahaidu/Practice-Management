using Bunifu.UI.WinForms.BunifuButton;
using BusinessLayer;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using UIUX.Popup;
using UIUX.View;

namespace UIUX
{

    public interface CallBack
    {
        void ShowAccountSettingPopup();
    }

    public partial class Main : Form
    {

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDpiAwarenessContext(int dpiFlag);

        private Form statePage;
        private int navKey = 0;
        private BunifuButton disableButton;
        private AccountPopup accountPopup;
        private TransPanel overlayPanel;
        private AccountSettingPopup accountSettingPopup;
        private bool isRealClose = true;

        public Main(LoginForm LoginForm)
        {
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            InitializeComponent();
            SetProcessDpiAwarenessContext(-4);

            btnAccount.Text = UserSession.Instance.CurrentUser.displayName;

            changePage(new DashboardPage());
            disableButton = dashboard_btn;

            accountSettingPopup = new AccountSettingPopup
            {
                TopLevel = false,
                Visible = false
            };
            this.Controls.Add(accountSettingPopup);
            accountSettingPopup.changeDisplayNameEvent += (sender, e) =>
            {
                btnAccount.Text = UserSession.Instance.CurrentUser.displayName;
            };

            accountPopup = new AccountPopup
            {
                TopLevel = false,
                Visible = false
            };
            accountPopup.Clicked += AccountSettingShowup_Click;

            accountPopup.LogoutEvent += (sender_, e_) =>
            {
                if (!LoginForm.IsDisposed)
                {
                    LoginForm.ResetTextBox();
                    LoginForm.Show();
                }
                isRealClose = false;
                BeginInvoke(new Action(() => this.Close()));
            };

            this.Controls.Add(accountPopup);

            overlayPanel = new TransPanel
            {
                Size = Screen.PrimaryScreen.Bounds.Size,
                Location = new Point(0, 0),
                BackColor = Color.White,
                Opacity = 0,
            };
            this.Controls.Add(overlayPanel);

            overlayPanel.MouseDown += Main_MouseDown;
        }

        private void changePage(Form page)
        {
            if (statePage != null)
            {
                statePage.Close();
            }
            statePage = page;
            statePage.TopLevel = false;
            statePage.FormBorderStyle = FormBorderStyle.None;
            statePage.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(statePage);
            mainPanel.Tag = statePage;
            statePage.BringToFront();
            statePage.Show();
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            changePage(new DashboardPage());
            disableButton.BringToFront();
            dashboard_btn.SendToBack();
            dashboard_btn_2.BringToFront();
            disableButton = (BunifuButton)sender;
        }

        private void patient_btn_Click(object sender, EventArgs e)
        {
            changePage(new PatientPage());
            disableButton.BringToFront();
            patient_btn.SendToBack();
            patient_btn_2.BringToFront();
            disableButton = (BunifuButton)sender;

        }

        private void cabinet_btn_Click(object sender, EventArgs e)
        {
            changePage(new CabinetPage());
            disableButton.BringToFront();
            cabinet_btn.SendToBack();
            cabinet_btn_2.BringToFront();
            disableButton = (BunifuButton)sender;
        }

        private void tech_btn_Click(object sender, EventArgs e)
        {
            changePage(new TechnicalCatalogPage());
            disableButton.BringToFront();
            tech_btn.SendToBack();
            tech_btn_2.BringToFront();
            disableButton = (BunifuButton)sender;
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            changePage(new AccountsPage());
            disableButton.BringToFront();
            btnAccounts.SendToBack();
            btnAccounts2.BringToFront();
            disableButton = (BunifuButton)sender;
        }

        private void account_btn_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            int x = btnAccount.Location.X;
            int y = btnAccount.Location.Y + btnAccount.Height + 5;
            int x_ = panel2.Location.X;
            int y_ = panel2.Location.Y;
            Point popupLocation = new Point(x + x_, y + y_ + 5);
            accountPopup.Location = popupLocation;
            accountPopup.Refesh();
            overlayPanel.Visible = true;
            overlayPanel.BringToFront();

            accountPopup.Visible = true;
            accountPopup.BringToFront();

        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            Point mouseLocation = this.PointToClient(e.Location);
            if ((accountPopup != null && accountPopup.Visible && !accountPopup.Bounds.Contains(mouseLocation)) ||
                (accountSettingPopup != null && accountSettingPopup.Visible && !accountSettingPopup.Bounds.Contains(mouseLocation)))
            {
                accountPopup.Visible = false;
                accountSettingPopup.Visible = false;
                overlayPanel.Visible = false;
            }
        }

        private void AccountSettingShowup_Click(object sender, EventArgs e)
        {
            accountPopup.Visible = false;

            int x = btnAccount.Location.X;
            int y = btnAccount.Location.Y + btnAccount.Height + 5;
            int x_ = panel2.Location.X;
            int y_ = panel2.Location.Y;
            Point popupLocation = new Point(x + x_, y + y_ + 5);
            accountSettingPopup.Location = popupLocation;
            accountSettingPopup.Refesh();
            //overlayPanel.Visible = true;
            //overlayPanel.BringToFront();
            //overlayPanel.BackColor = Color.Black;
            //overlayPanel.Opacity = 50;
            accountSettingPopup.Visible = true;
            accountSettingPopup.BringToFront();

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isRealClose)
                Application.Exit();
        }
    }
}

using Bunifu.UI.WinForms.BunifuButton;
using System;
using System.Drawing;
using System.Windows.Forms;
using UIUX.Popup;
using UIUX.View;

namespace UIUX
{
    public partial class Main : Form
    {

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDpiAwarenessContext(int dpiFlag);



        private Form statePage;
        private int navKey = 0;
        private BunifuButton disableButton;
        private AccountPopup accountPopup;
        private TransPanel overlayPanel;

        public Main()
        {
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            InitializeComponent();
            SetProcessDpiAwarenessContext(-4);
            changePage(new DashboardPage());
            disableButton = dashboard_btn;

            accountPopup = new AccountPopup
            {
                TopLevel = false,
                Visible = false
            };
            this.Controls.Add(accountPopup);

            overlayPanel = new TransPanel
            {
                Size = Screen.PrimaryScreen.Bounds.Size,
                Location = new Point(0, 0),
                BackColor = Color.White,
                Opacity = 10,
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
        private void setting_btn_Click(object sender, EventArgs e)
        {
            disableButton.BringToFront();
            setting_btn.SendToBack();
            setting_btn_2.BringToFront();
            disableButton = (BunifuButton)sender;
        }

        private void account_btn_Click(object sender, EventArgs e)
        {
            int x = account_btn.Location.X;
            int y = account_btn.Location.Y + account_btn.Height + 5;
            int x_ = panel2.Location.X;
            int y_ = panel2.Location.Y;
            Point popupLocation = new Point(x + x_, y + y_ + 5);
            accountPopup.Location = popupLocation;

            overlayPanel.Visible = true;
            overlayPanel.BringToFront();

            accountPopup.Visible = true;
            accountPopup.BringToFront();

        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            Point mouseLocation = this.PointToClient(e.Location);
            if (accountPopup != null && accountPopup.Visible &&
                !accountPopup.Bounds.Contains(mouseLocation))
            {
                accountPopup.Visible = false;
                overlayPanel.Visible = false;
                account_btn.Invalidate();
            }
        }

    }
}

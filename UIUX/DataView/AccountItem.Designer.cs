namespace UIUX.DataView
{
    partial class AccountItem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountItem));
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuPictureBox1 = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbAuthority = new System.Windows.Forms.Label();
            this.lbUsernameName = new System.Windows.Forms.Label();
            this.btnDeleteAccount = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnDeleteAccount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 120);
            this.panel1.TabIndex = 12;
            // 
            // bunifuPictureBox1
            // 
            this.bunifuPictureBox1.AllowFocused = false;
            this.bunifuPictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bunifuPictureBox1.AutoSizeHeight = true;
            this.bunifuPictureBox1.BorderRadius = 46;
            this.bunifuPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuPictureBox1.Image")));
            this.bunifuPictureBox1.IsCircle = true;
            this.bunifuPictureBox1.Location = new System.Drawing.Point(12, 14);
            this.bunifuPictureBox1.Name = "bunifuPictureBox1";
            this.bunifuPictureBox1.Size = new System.Drawing.Size(92, 92);
            this.bunifuPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuPictureBox1.TabIndex = 17;
            this.bunifuPictureBox1.TabStop = false;
            this.bunifuPictureBox1.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.BackColor = System.Drawing.Color.White;
            this.lbEmail.Font = new System.Drawing.Font("Nunito Sans Normal SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.lbEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lbEmail.Location = new System.Drawing.Point(119, 83);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(49, 22);
            this.lbEmail.TabIndex = 16;
            this.lbEmail.Text = "Email";
            // 
            // lbAuthority
            // 
            this.lbAuthority.AutoSize = true;
            this.lbAuthority.BackColor = System.Drawing.Color.White;
            this.lbAuthority.Font = new System.Drawing.Font("Nunito Sans Normal SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.lbAuthority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lbAuthority.Location = new System.Drawing.Point(119, 52);
            this.lbAuthority.Name = "lbAuthority";
            this.lbAuthority.Size = new System.Drawing.Size(66, 22);
            this.lbAuthority.TabIndex = 15;
            this.lbAuthority.Text = "Chức vụ";
            // 
            // lbUsernameName
            // 
            this.lbUsernameName.AutoSize = true;
            this.lbUsernameName.BackColor = System.Drawing.Color.White;
            this.lbUsernameName.Font = new System.Drawing.Font("Nunito Sans Normal SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.lbUsernameName.Location = new System.Drawing.Point(118, 18);
            this.lbUsernameName.Name = "lbUsernameName";
            this.lbUsernameName.Size = new System.Drawing.Size(40, 25);
            this.lbUsernameName.TabIndex = 14;
            this.lbUsernameName.Text = "Tên";
            // 
            // btnDeleteAccount
            // 
            this.btnDeleteAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteAccount.AutoSize = true;
            this.btnDeleteAccount.BackColor = System.Drawing.Color.White;
            this.btnDeleteAccount.Font = new System.Drawing.Font("Century Gothic Variable SemiBol", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnDeleteAccount.ForeColor = System.Drawing.Color.Red;
            this.btnDeleteAccount.Location = new System.Drawing.Point(765, 14);
            this.btnDeleteAccount.Name = "btnDeleteAccount";
            this.btnDeleteAccount.Size = new System.Drawing.Size(123, 24);
            this.btnDeleteAccount.TabIndex = 13;
            this.btnDeleteAccount.Text = "Xóa tài khoản";
            this.btnDeleteAccount.Click += new System.EventHandler(this.btnDeleteAccount_Click_1);
            // 
            // AccountItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(900, 133);
            this.Controls.Add(this.bunifuPictureBox1);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.lbAuthority);
            this.Controls.Add(this.lbUsernameName);
            this.Controls.Add(this.panel1);
            this.Name = "AccountItem";
            this.Text = "AccountView";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label btnDeleteAccount;
        private Bunifu.UI.WinForms.BunifuPictureBox bunifuPictureBox1;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbAuthority;
        private System.Windows.Forms.Label lbUsernameName;
    }
}
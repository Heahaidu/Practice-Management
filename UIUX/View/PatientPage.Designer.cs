namespace UIUX.View
{
    partial class PatientPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientPage));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.sfDataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.addNewPatient_btn = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.panel1.SuspendLayout();
            this.bunifuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.addNewPatient_btn);
            this.panel1.Controls.Add(this.bunifuLabel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 55);
            this.panel1.TabIndex = 10;
            // 
            // bunifuLabel3
            // 
            this.bunifuLabel3.AllowParentOverrides = false;
            this.bunifuLabel3.AutoEllipsis = false;
            this.bunifuLabel3.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel3.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel3.Font = new System.Drawing.Font("Century Gothic Variable SemiBol", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel3.Location = new System.Drawing.Point(20, 10);
            this.bunifuLabel3.Name = "bunifuLabel3";
            this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel3.Size = new System.Drawing.Size(119, 33);
            this.bunifuLabel3.TabIndex = 5;
            this.bunifuLabel3.Text = "Bệnh nhân";
            this.bunifuLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BorderRadius = 0;
            this.bunifuPanel1.BorderThickness = 0;
            this.bunifuPanel1.Controls.Add(this.sfDataGrid);
            this.bunifuPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuPanel1.Location = new System.Drawing.Point(0, 55);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.Padding = new System.Windows.Forms.Padding(20, 0, 20, 20);
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(800, 395);
            this.bunifuPanel1.TabIndex = 11;
            // 
            // sfDataGrid
            // 
            this.sfDataGrid.AccessibleName = "Table";
            this.sfDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sfDataGrid.Location = new System.Drawing.Point(20, 0);
            this.sfDataGrid.Name = "sfDataGrid";
            this.sfDataGrid.PreviewRowHeight = 35;
            this.sfDataGrid.Size = new System.Drawing.Size(760, 375);
            this.sfDataGrid.TabIndex = 6;
            this.sfDataGrid.Text = "sfDataGrid1";
            // 
            // addNewPatient_btn
            // 
            this.addNewPatient_btn.AllowAnimations = true;
            this.addNewPatient_btn.AllowMouseEffects = true;
            this.addNewPatient_btn.AllowToggling = false;
            this.addNewPatient_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addNewPatient_btn.AnimationSpeed = 200;
            this.addNewPatient_btn.AutoGenerateColors = false;
            this.addNewPatient_btn.AutoRoundBorders = false;
            this.addNewPatient_btn.AutoSizeLeftIcon = true;
            this.addNewPatient_btn.AutoSizeRightIcon = true;
            this.addNewPatient_btn.BackColor = System.Drawing.Color.Transparent;
            this.addNewPatient_btn.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.addNewPatient_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addNewPatient_btn.BackgroundImage")));
            this.addNewPatient_btn.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.addNewPatient_btn.ButtonText = "Thêm bệnh nhân mới";
            this.addNewPatient_btn.ButtonTextMarginLeft = 0;
            this.addNewPatient_btn.ColorContrastOnClick = 45;
            this.addNewPatient_btn.ColorContrastOnHover = 45;
            this.addNewPatient_btn.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.addNewPatient_btn.CustomizableEdges = borderEdges1;
            this.addNewPatient_btn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.addNewPatient_btn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.addNewPatient_btn.DisabledFillColor = System.Drawing.Color.Empty;
            this.addNewPatient_btn.DisabledForecolor = System.Drawing.Color.Empty;
            this.addNewPatient_btn.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.addNewPatient_btn.Font = new System.Drawing.Font("Century Gothic Variable SemiBol", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewPatient_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.addNewPatient_btn.IconLeft = ((System.Drawing.Image)(resources.GetObject("addNewPatient_btn.IconLeft")));
            this.addNewPatient_btn.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addNewPatient_btn.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.addNewPatient_btn.IconLeftPadding = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.addNewPatient_btn.IconMarginLeft = 11;
            this.addNewPatient_btn.IconPadding = 10;
            this.addNewPatient_btn.IconRight = null;
            this.addNewPatient_btn.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addNewPatient_btn.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.addNewPatient_btn.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.addNewPatient_btn.IconSize = 25;
            this.addNewPatient_btn.IdleBorderColor = System.Drawing.Color.Empty;
            this.addNewPatient_btn.IdleBorderRadius = 0;
            this.addNewPatient_btn.IdleBorderThickness = 0;
            this.addNewPatient_btn.IdleFillColor = System.Drawing.Color.Empty;
            this.addNewPatient_btn.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("addNewPatient_btn.IdleIconLeftImage")));
            this.addNewPatient_btn.IdleIconRightImage = null;
            this.addNewPatient_btn.IndicateFocus = false;
            this.addNewPatient_btn.Location = new System.Drawing.Point(583, 7);
            this.addNewPatient_btn.Name = "addNewPatient_btn";
            this.addNewPatient_btn.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.addNewPatient_btn.OnDisabledState.BorderRadius = 15;
            this.addNewPatient_btn.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.addNewPatient_btn.OnDisabledState.BorderThickness = 0;
            this.addNewPatient_btn.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.addNewPatient_btn.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.addNewPatient_btn.OnDisabledState.IconLeftImage = null;
            this.addNewPatient_btn.OnDisabledState.IconRightImage = null;
            this.addNewPatient_btn.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(234)))));
            this.addNewPatient_btn.onHoverState.BorderRadius = 15;
            this.addNewPatient_btn.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.addNewPatient_btn.onHoverState.BorderThickness = 0;
            this.addNewPatient_btn.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(128)))), ((int)(((byte)(234)))));
            this.addNewPatient_btn.onHoverState.ForeColor = System.Drawing.Color.White;
            this.addNewPatient_btn.onHoverState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton1.onHoverState.IconLeftImage")));
            this.addNewPatient_btn.onHoverState.IconRightImage = null;
            this.addNewPatient_btn.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.addNewPatient_btn.OnIdleState.BorderRadius = 15;
            this.addNewPatient_btn.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.addNewPatient_btn.OnIdleState.BorderThickness = 0;
            this.addNewPatient_btn.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.addNewPatient_btn.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.addNewPatient_btn.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton1.OnIdleState.IconLeftImage")));
            this.addNewPatient_btn.OnIdleState.IconRightImage = null;
            this.addNewPatient_btn.OnPressedState.BorderColor = System.Drawing.Color.Transparent;
            this.addNewPatient_btn.OnPressedState.BorderRadius = 15;
            this.addNewPatient_btn.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.addNewPatient_btn.OnPressedState.BorderThickness = 0;
            this.addNewPatient_btn.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.addNewPatient_btn.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.addNewPatient_btn.OnPressedState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton1.OnPressedState.IconLeftImage")));
            this.addNewPatient_btn.OnPressedState.IconRightImage = null;
            this.addNewPatient_btn.Size = new System.Drawing.Size(197, 40);
            this.addNewPatient_btn.TabIndex = 12;
            this.addNewPatient_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addNewPatient_btn.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.addNewPatient_btn.TextMarginLeft = 0;
            this.addNewPatient_btn.TextPadding = new System.Windows.Forms.Padding(35, 0, 0, 10);
            this.addNewPatient_btn.UseDefaultRadiusAndThickness = true;
            this.addNewPatient_btn.Click += new System.EventHandler(this.addNewPatient_btn_Click);
            // 
            // PatientPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bunifuPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "PatientPage";
            this.Text = "PatientPage";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.bunifuPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel3;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton addNewPatient_btn;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
    }
}
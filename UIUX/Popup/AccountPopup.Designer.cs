namespace UIUX.Popup
{
    partial class AccountPopup
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
            this.components = new System.ComponentModel.Container();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountPopup));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuPictureBox1 = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.lbDisplayName = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuButton3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuFormDock1 = new Bunifu.UI.WinForms.BunifuFormDock();
            this.ShowAccountSettingPopup = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuShadowPanel1 = new Bunifu.UI.WinForms.BunifuShadowPanel();
            this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).BeginInit();
            this.bunifuShadowPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bunifuPictureBox1);
            this.panel1.Controls.Add(this.lbDisplayName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 69);
            this.panel1.TabIndex = 10;
            // 
            // bunifuPictureBox1
            // 
            this.bunifuPictureBox1.AllowFocused = false;
            this.bunifuPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuPictureBox1.AutoSizeHeight = true;
            this.bunifuPictureBox1.BorderRadius = 25;
            this.bunifuPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuPictureBox1.Image")));
            this.bunifuPictureBox1.IsCircle = false;
            this.bunifuPictureBox1.Location = new System.Drawing.Point(12, 12);
            this.bunifuPictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.bunifuPictureBox1.Name = "bunifuPictureBox1";
            this.bunifuPictureBox1.Size = new System.Drawing.Size(50, 50);
            this.bunifuPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuPictureBox1.TabIndex = 0;
            this.bunifuPictureBox1.TabStop = false;
            this.bunifuPictureBox1.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Custom;
            // 
            // lbDisplayName
            // 
            this.lbDisplayName.AllowAnimations = true;
            this.lbDisplayName.AllowMouseEffects = true;
            this.lbDisplayName.AllowToggling = false;
            this.lbDisplayName.AnimationSpeed = 200;
            this.lbDisplayName.AutoGenerateColors = false;
            this.lbDisplayName.AutoRoundBorders = false;
            this.lbDisplayName.AutoSizeLeftIcon = true;
            this.lbDisplayName.AutoSizeRightIcon = true;
            this.lbDisplayName.BackColor = System.Drawing.Color.Transparent;
            this.lbDisplayName.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.lbDisplayName.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lbDisplayName.BackgroundImage")));
            this.lbDisplayName.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.lbDisplayName.ButtonText = "Nguyễn Hải Dương";
            this.lbDisplayName.ButtonTextMarginLeft = 0;
            this.lbDisplayName.ColorContrastOnClick = 45;
            this.lbDisplayName.ColorContrastOnHover = 45;
            this.lbDisplayName.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.lbDisplayName.CustomizableEdges = borderEdges2;
            this.lbDisplayName.DialogResult = System.Windows.Forms.DialogResult.None;
            this.lbDisplayName.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.lbDisplayName.DisabledFillColor = System.Drawing.Color.Empty;
            this.lbDisplayName.DisabledForecolor = System.Drawing.Color.Empty;
            this.lbDisplayName.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.lbDisplayName.Font = new System.Drawing.Font("Nunito Sans Normal", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDisplayName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.lbDisplayName.IconLeft = null;
            this.lbDisplayName.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbDisplayName.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.lbDisplayName.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.lbDisplayName.IconMarginLeft = 11;
            this.lbDisplayName.IconPadding = 0;
            this.lbDisplayName.IconRight = null;
            this.lbDisplayName.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbDisplayName.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.lbDisplayName.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.lbDisplayName.IconSize = 25;
            this.lbDisplayName.IdleBorderColor = System.Drawing.Color.Empty;
            this.lbDisplayName.IdleBorderRadius = 0;
            this.lbDisplayName.IdleBorderThickness = 0;
            this.lbDisplayName.IdleFillColor = System.Drawing.Color.Empty;
            this.lbDisplayName.IdleIconLeftImage = null;
            this.lbDisplayName.IdleIconRightImage = null;
            this.lbDisplayName.IndicateFocus = false;
            this.lbDisplayName.Location = new System.Drawing.Point(67, 11);
            this.lbDisplayName.Margin = new System.Windows.Forms.Padding(2);
            this.lbDisplayName.Name = "lbDisplayName";
            this.lbDisplayName.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.lbDisplayName.OnDisabledState.BorderRadius = 5;
            this.lbDisplayName.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.lbDisplayName.OnDisabledState.BorderThickness = 0;
            this.lbDisplayName.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.lbDisplayName.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.lbDisplayName.OnDisabledState.IconLeftImage = null;
            this.lbDisplayName.OnDisabledState.IconRightImage = null;
            this.lbDisplayName.onHoverState.BorderColor = System.Drawing.Color.Transparent;
            this.lbDisplayName.onHoverState.BorderRadius = 5;
            this.lbDisplayName.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.lbDisplayName.onHoverState.BorderThickness = 0;
            this.lbDisplayName.onHoverState.FillColor = System.Drawing.Color.Transparent;
            this.lbDisplayName.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.lbDisplayName.onHoverState.IconLeftImage = null;
            this.lbDisplayName.onHoverState.IconRightImage = null;
            this.lbDisplayName.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.lbDisplayName.OnIdleState.BorderRadius = 5;
            this.lbDisplayName.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.lbDisplayName.OnIdleState.BorderThickness = 0;
            this.lbDisplayName.OnIdleState.FillColor = System.Drawing.Color.Transparent;
            this.lbDisplayName.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.lbDisplayName.OnIdleState.IconLeftImage = null;
            this.lbDisplayName.OnIdleState.IconRightImage = null;
            this.lbDisplayName.OnPressedState.BorderColor = System.Drawing.Color.Transparent;
            this.lbDisplayName.OnPressedState.BorderRadius = 5;
            this.lbDisplayName.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.lbDisplayName.OnPressedState.BorderThickness = 0;
            this.lbDisplayName.OnPressedState.FillColor = System.Drawing.Color.Transparent;
            this.lbDisplayName.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(53)))), ((int)(((byte)(47)))));
            this.lbDisplayName.OnPressedState.IconLeftImage = null;
            this.lbDisplayName.OnPressedState.IconRightImage = null;
            this.lbDisplayName.Size = new System.Drawing.Size(164, 32);
            this.lbDisplayName.TabIndex = 8;
            this.lbDisplayName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbDisplayName.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.lbDisplayName.TextMarginLeft = 0;
            this.lbDisplayName.TextPadding = new System.Windows.Forms.Padding(0);
            this.lbDisplayName.UseDefaultRadiusAndThickness = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(68, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Trưởng khoa";
            // 
            // bunifuButton3
            // 
            this.bunifuButton3.AllowAnimations = true;
            this.bunifuButton3.AllowMouseEffects = true;
            this.bunifuButton3.AllowToggling = false;
            this.bunifuButton3.AnimationSpeed = 200;
            this.bunifuButton3.AutoGenerateColors = false;
            this.bunifuButton3.AutoRoundBorders = false;
            this.bunifuButton3.AutoSizeLeftIcon = true;
            this.bunifuButton3.AutoSizeRightIcon = true;
            this.bunifuButton3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton3.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.bunifuButton3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton3.BackgroundImage")));
            this.bunifuButton3.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton3.ButtonText = "Đăng xuất";
            this.bunifuButton3.ButtonTextMarginLeft = 0;
            this.bunifuButton3.ColorContrastOnClick = 45;
            this.bunifuButton3.ColorContrastOnHover = 45;
            this.bunifuButton3.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.bunifuButton3.CustomizableEdges = borderEdges1;
            this.bunifuButton3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuButton3.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bunifuButton3.DisabledFillColor = System.Drawing.Color.Empty;
            this.bunifuButton3.DisabledForecolor = System.Drawing.Color.Empty;
            this.bunifuButton3.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuButton3.Font = new System.Drawing.Font("Century Gothic Variable SemiBol", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.bunifuButton3.IconLeft = null;
            this.bunifuButton3.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuButton3.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.bunifuButton3.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.bunifuButton3.IconMarginLeft = 11;
            this.bunifuButton3.IconPadding = 10;
            this.bunifuButton3.IconRight = null;
            this.bunifuButton3.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bunifuButton3.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.bunifuButton3.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.bunifuButton3.IconSize = 25;
            this.bunifuButton3.IdleBorderColor = System.Drawing.Color.Empty;
            this.bunifuButton3.IdleBorderRadius = 0;
            this.bunifuButton3.IdleBorderThickness = 0;
            this.bunifuButton3.IdleFillColor = System.Drawing.Color.Empty;
            this.bunifuButton3.IdleIconLeftImage = null;
            this.bunifuButton3.IdleIconRightImage = null;
            this.bunifuButton3.IndicateFocus = false;
            this.bunifuButton3.Location = new System.Drawing.Point(12, 118);
            this.bunifuButton3.Name = "bunifuButton3";
            this.bunifuButton3.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bunifuButton3.OnDisabledState.BorderRadius = 5;
            this.bunifuButton3.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton3.OnDisabledState.BorderThickness = 1;
            this.bunifuButton3.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuButton3.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuButton3.OnDisabledState.IconLeftImage = null;
            this.bunifuButton3.OnDisabledState.IconRightImage = null;
            this.bunifuButton3.onHoverState.BorderColor = System.Drawing.Color.Red;
            this.bunifuButton3.onHoverState.BorderRadius = 5;
            this.bunifuButton3.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton3.onHoverState.BorderThickness = 1;
            this.bunifuButton3.onHoverState.FillColor = System.Drawing.Color.Red;
            this.bunifuButton3.onHoverState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton3.onHoverState.IconLeftImage = null;
            this.bunifuButton3.onHoverState.IconRightImage = null;
            this.bunifuButton3.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuButton3.OnIdleState.BorderRadius = 5;
            this.bunifuButton3.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton3.OnIdleState.BorderThickness = 1;
            this.bunifuButton3.OnIdleState.FillColor = System.Drawing.Color.Transparent;
            this.bunifuButton3.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.bunifuButton3.OnIdleState.IconLeftImage = null;
            this.bunifuButton3.OnIdleState.IconRightImage = null;
            this.bunifuButton3.OnPressedState.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuButton3.OnPressedState.BorderRadius = 5;
            this.bunifuButton3.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton3.OnPressedState.BorderThickness = 1;
            this.bunifuButton3.OnPressedState.FillColor = System.Drawing.Color.Transparent;
            this.bunifuButton3.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.bunifuButton3.OnPressedState.IconLeftImage = null;
            this.bunifuButton3.OnPressedState.IconRightImage = null;
            this.bunifuButton3.Size = new System.Drawing.Size(288, 25);
            this.bunifuButton3.TabIndex = 13;
            this.bunifuButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuButton3.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.bunifuButton3.TextMarginLeft = 0;
            this.bunifuButton3.TextPadding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.bunifuButton3.UseDefaultRadiusAndThickness = true;
            // 
            // bunifuFormDock1
            // 
            this.bunifuFormDock1.AllowFormDragging = false;
            this.bunifuFormDock1.AllowFormDropShadow = true;
            this.bunifuFormDock1.AllowFormResizing = false;
            this.bunifuFormDock1.AllowHidingBottomRegion = true;
            this.bunifuFormDock1.AllowOpacityChangesWhileDragging = false;
            this.bunifuFormDock1.BorderOptions.BottomBorder.BorderColor = System.Drawing.Color.Silver;
            this.bunifuFormDock1.BorderOptions.BottomBorder.BorderThickness = 1;
            this.bunifuFormDock1.BorderOptions.BottomBorder.ShowBorder = true;
            this.bunifuFormDock1.BorderOptions.LeftBorder.BorderColor = System.Drawing.Color.Silver;
            this.bunifuFormDock1.BorderOptions.LeftBorder.BorderThickness = 1;
            this.bunifuFormDock1.BorderOptions.LeftBorder.ShowBorder = true;
            this.bunifuFormDock1.BorderOptions.RightBorder.BorderColor = System.Drawing.Color.Silver;
            this.bunifuFormDock1.BorderOptions.RightBorder.BorderThickness = 1;
            this.bunifuFormDock1.BorderOptions.RightBorder.ShowBorder = true;
            this.bunifuFormDock1.BorderOptions.TopBorder.BorderColor = System.Drawing.Color.Silver;
            this.bunifuFormDock1.BorderOptions.TopBorder.BorderThickness = 1;
            this.bunifuFormDock1.BorderOptions.TopBorder.ShowBorder = true;
            this.bunifuFormDock1.ContainerControl = this;
            this.bunifuFormDock1.DockingIndicatorsColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(215)))), ((int)(((byte)(233)))));
            this.bunifuFormDock1.DockingIndicatorsOpacity = 0D;
            this.bunifuFormDock1.DockingOptions.DockAll = true;
            this.bunifuFormDock1.DockingOptions.DockBottomLeft = true;
            this.bunifuFormDock1.DockingOptions.DockBottomRight = true;
            this.bunifuFormDock1.DockingOptions.DockFullScreen = true;
            this.bunifuFormDock1.DockingOptions.DockLeft = true;
            this.bunifuFormDock1.DockingOptions.DockRight = true;
            this.bunifuFormDock1.DockingOptions.DockTopLeft = true;
            this.bunifuFormDock1.DockingOptions.DockTopRight = true;
            this.bunifuFormDock1.FormDraggingOpacity = 0.9D;
            this.bunifuFormDock1.ParentForm = this;
            this.bunifuFormDock1.ShowCursorChanges = true;
            this.bunifuFormDock1.ShowDockingIndicators = true;
            this.bunifuFormDock1.TitleBarOptions.AllowFormDragging = true;
            this.bunifuFormDock1.TitleBarOptions.BunifuFormDock = this.bunifuFormDock1;
            this.bunifuFormDock1.TitleBarOptions.DoubleClickToExpandWindow = true;
            this.bunifuFormDock1.TitleBarOptions.TitleBarControl = null;
            this.bunifuFormDock1.TitleBarOptions.UseBackColorOnDockingIndicators = false;
            // 
            // ShowAccountSettingPopup
            // 
            this.ShowAccountSettingPopup.AllowAnimations = true;
            this.ShowAccountSettingPopup.AllowMouseEffects = true;
            this.ShowAccountSettingPopup.AllowToggling = false;
            this.ShowAccountSettingPopup.AnimationSpeed = 200;
            this.ShowAccountSettingPopup.AutoGenerateColors = false;
            this.ShowAccountSettingPopup.AutoRoundBorders = false;
            this.ShowAccountSettingPopup.AutoSizeLeftIcon = true;
            this.ShowAccountSettingPopup.AutoSizeRightIcon = true;
            this.ShowAccountSettingPopup.BackColor = System.Drawing.Color.Transparent;
            this.ShowAccountSettingPopup.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.ShowAccountSettingPopup.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ShowAccountSettingPopup.BackgroundImage")));
            this.ShowAccountSettingPopup.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.ShowAccountSettingPopup.ButtonText = "Cài đặt";
            this.ShowAccountSettingPopup.ButtonTextMarginLeft = 0;
            this.ShowAccountSettingPopup.ColorContrastOnClick = 45;
            this.ShowAccountSettingPopup.ColorContrastOnHover = 45;
            this.ShowAccountSettingPopup.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.ShowAccountSettingPopup.CustomizableEdges = borderEdges3;
            this.ShowAccountSettingPopup.DialogResult = System.Windows.Forms.DialogResult.None;
            this.ShowAccountSettingPopup.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.ShowAccountSettingPopup.DisabledFillColor = System.Drawing.Color.Empty;
            this.ShowAccountSettingPopup.DisabledForecolor = System.Drawing.Color.Empty;
            this.ShowAccountSettingPopup.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.ShowAccountSettingPopup.Font = new System.Drawing.Font("Century Gothic Variable SemiBol", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowAccountSettingPopup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.ShowAccountSettingPopup.IconLeft = null;
            this.ShowAccountSettingPopup.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ShowAccountSettingPopup.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.ShowAccountSettingPopup.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.ShowAccountSettingPopup.IconMarginLeft = 11;
            this.ShowAccountSettingPopup.IconPadding = 10;
            this.ShowAccountSettingPopup.IconRight = null;
            this.ShowAccountSettingPopup.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ShowAccountSettingPopup.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.ShowAccountSettingPopup.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.ShowAccountSettingPopup.IconSize = 25;
            this.ShowAccountSettingPopup.IdleBorderColor = System.Drawing.Color.Empty;
            this.ShowAccountSettingPopup.IdleBorderRadius = 0;
            this.ShowAccountSettingPopup.IdleBorderThickness = 0;
            this.ShowAccountSettingPopup.IdleFillColor = System.Drawing.Color.Empty;
            this.ShowAccountSettingPopup.IdleIconLeftImage = null;
            this.ShowAccountSettingPopup.IdleIconRightImage = null;
            this.ShowAccountSettingPopup.IndicateFocus = false;
            this.ShowAccountSettingPopup.Location = new System.Drawing.Point(12, 87);
            this.ShowAccountSettingPopup.Name = "ShowAccountSettingPopup";
            this.ShowAccountSettingPopup.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.ShowAccountSettingPopup.OnDisabledState.BorderRadius = 5;
            this.ShowAccountSettingPopup.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.ShowAccountSettingPopup.OnDisabledState.BorderThickness = 1;
            this.ShowAccountSettingPopup.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.ShowAccountSettingPopup.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.ShowAccountSettingPopup.OnDisabledState.IconLeftImage = null;
            this.ShowAccountSettingPopup.OnDisabledState.IconRightImage = null;
            this.ShowAccountSettingPopup.onHoverState.BorderColor = System.Drawing.Color.Gainsboro;
            this.ShowAccountSettingPopup.onHoverState.BorderRadius = 5;
            this.ShowAccountSettingPopup.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.ShowAccountSettingPopup.onHoverState.BorderThickness = 1;
            this.ShowAccountSettingPopup.onHoverState.FillColor = System.Drawing.Color.Gainsboro;
            this.ShowAccountSettingPopup.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.ShowAccountSettingPopup.onHoverState.IconLeftImage = null;
            this.ShowAccountSettingPopup.onHoverState.IconRightImage = null;
            this.ShowAccountSettingPopup.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.ShowAccountSettingPopup.OnIdleState.BorderRadius = 5;
            this.ShowAccountSettingPopup.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.ShowAccountSettingPopup.OnIdleState.BorderThickness = 1;
            this.ShowAccountSettingPopup.OnIdleState.FillColor = System.Drawing.Color.Transparent;
            this.ShowAccountSettingPopup.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.ShowAccountSettingPopup.OnIdleState.IconLeftImage = null;
            this.ShowAccountSettingPopup.OnIdleState.IconRightImage = null;
            this.ShowAccountSettingPopup.OnPressedState.BorderColor = System.Drawing.Color.Transparent;
            this.ShowAccountSettingPopup.OnPressedState.BorderRadius = 5;
            this.ShowAccountSettingPopup.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.ShowAccountSettingPopup.OnPressedState.BorderThickness = 1;
            this.ShowAccountSettingPopup.OnPressedState.FillColor = System.Drawing.Color.Transparent;
            this.ShowAccountSettingPopup.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.ShowAccountSettingPopup.OnPressedState.IconLeftImage = null;
            this.ShowAccountSettingPopup.OnPressedState.IconRightImage = null;
            this.ShowAccountSettingPopup.Size = new System.Drawing.Size(288, 25);
            this.ShowAccountSettingPopup.TabIndex = 12;
            this.ShowAccountSettingPopup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ShowAccountSettingPopup.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.ShowAccountSettingPopup.TextMarginLeft = 0;
            this.ShowAccountSettingPopup.TextPadding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ShowAccountSettingPopup.UseDefaultRadiusAndThickness = true;
            this.ShowAccountSettingPopup.Click += new System.EventHandler(this.ShowAccountSettingPopup_Click);
            // 
            // bunifuShadowPanel1
            // 
            this.bunifuShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuShadowPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuShadowPanel1.BorderRadius = 10;
            this.bunifuShadowPanel1.BorderThickness = 0;
            this.bunifuShadowPanel1.Controls.Add(this.bunifuSeparator1);
            this.bunifuShadowPanel1.Controls.Add(this.bunifuButton3);
            this.bunifuShadowPanel1.Controls.Add(this.panel1);
            this.bunifuShadowPanel1.Controls.Add(this.ShowAccountSettingPopup);
            this.bunifuShadowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuShadowPanel1.FillStyle = Bunifu.UI.WinForms.BunifuShadowPanel.FillStyles.Solid;
            this.bunifuShadowPanel1.GradientMode = Bunifu.UI.WinForms.BunifuShadowPanel.GradientModes.Vertical;
            this.bunifuShadowPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuShadowPanel1.Name = "bunifuShadowPanel1";
            this.bunifuShadowPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.bunifuShadowPanel1.PanelColor = System.Drawing.Color.White;
            this.bunifuShadowPanel1.PanelColor2 = System.Drawing.Color.White;
            this.bunifuShadowPanel1.ShadowColor = System.Drawing.Color.DarkGray;
            this.bunifuShadowPanel1.ShadowDept = 2;
            this.bunifuShadowPanel1.ShadowDepth = 2;
            this.bunifuShadowPanel1.ShadowStyle = Bunifu.UI.WinForms.BunifuShadowPanel.ShadowStyles.Surrounded;
            this.bunifuShadowPanel1.ShadowTopLeftVisible = false;
            this.bunifuShadowPanel1.Size = new System.Drawing.Size(312, 156);
            this.bunifuShadowPanel1.Style = Bunifu.UI.WinForms.BunifuShadowPanel.BevelStyles.Flat;
            this.bunifuShadowPanel1.TabIndex = 14;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSeparator1.BackgroundImage")));
            this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
            this.bunifuSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.LightGray;
            this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(2, 71);
            this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.bunifuSeparator1.Size = new System.Drawing.Size(308, 11);
            this.bunifuSeparator1.TabIndex = 12;
            // 
            // AccountPopup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(312, 156);
            this.Controls.Add(this.bunifuShadowPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AccountPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AccountPopup";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).EndInit();
            this.bunifuShadowPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton3;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton ShowAccountSettingPopup;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton lbDisplayName;
        private Bunifu.UI.WinForms.BunifuPictureBox bunifuPictureBox1;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.UI.WinForms.BunifuFormDock bunifuFormDock1;
        private Bunifu.UI.WinForms.BunifuShadowPanel bunifuShadowPanel1;
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator1;
    }
}
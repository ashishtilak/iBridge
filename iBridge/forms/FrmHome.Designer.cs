namespace iBridge
{
    partial class FrmHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHome));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.mnuAddUser = new DevExpress.XtraBars.BarButtonItem();
            this.mnuBackup = new DevExpress.XtraBars.BarButtonItem();
            this.mnuRestore = new DevExpress.XtraBars.BarButtonItem();
            this.mnuSysParam = new DevExpress.XtraBars.BarButtonItem();
            this.mnuCustTicket = new DevExpress.XtraBars.BarButtonItem();
            this.mnuDisplay = new DevExpress.XtraBars.BarButtonItem();
            this.mnuExit = new DevExpress.XtraBars.BarButtonItem();
            this.mnuResetPwd = new DevExpress.XtraBars.BarButtonItem();
            this.txtStatusBar = new DevExpress.XtraBars.BarStaticItem();
            this.txtStatusTime = new DevExpress.XtraBars.BarStaticItem();
            this.btnResetPwd = new DevExpress.XtraBars.BarButtonItem();
            this.btnMain = new DevExpress.XtraBars.BarButtonItem();
            this.mnuMain = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnAdmin = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnSetup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnExit = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuWeigh = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnWB = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.mnuAddUser,
            this.mnuBackup,
            this.mnuRestore,
            this.mnuSysParam,
            this.mnuCustTicket,
            this.mnuDisplay,
            this.mnuExit,
            this.mnuResetPwd,
            this.txtStatusBar,
            this.txtStatusTime,
            this.btnResetPwd,
            this.btnMain});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 3;
            this.ribbon.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Never;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mnuMain,
            this.mnuWeigh});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbon.Size = new System.Drawing.Size(762, 144);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ItemLinks.Add(this.mnuExit);
            // 
            // mnuAddUser
            // 
            this.mnuAddUser.Caption = "Manage Users";
            this.mnuAddUser.Glyph = ((System.Drawing.Image)(resources.GetObject("mnuAddUser.Glyph")));
            this.mnuAddUser.Id = 1;
            this.mnuAddUser.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("mnuAddUser.LargeGlyph")));
            this.mnuAddUser.Name = "mnuAddUser";
            this.mnuAddUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnuAddUser_ItemClick);
            // 
            // mnuBackup
            // 
            this.mnuBackup.Caption = "Backup";
            this.mnuBackup.Glyph = ((System.Drawing.Image)(resources.GetObject("mnuBackup.Glyph")));
            this.mnuBackup.Id = 3;
            this.mnuBackup.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("mnuBackup.LargeGlyph")));
            this.mnuBackup.Name = "mnuBackup";
            // 
            // mnuRestore
            // 
            this.mnuRestore.Caption = "Restore";
            this.mnuRestore.Glyph = ((System.Drawing.Image)(resources.GetObject("mnuRestore.Glyph")));
            this.mnuRestore.Id = 4;
            this.mnuRestore.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("mnuRestore.LargeGlyph")));
            this.mnuRestore.Name = "mnuRestore";
            // 
            // mnuSysParam
            // 
            this.mnuSysParam.Caption = "Connectivity";
            this.mnuSysParam.Glyph = ((System.Drawing.Image)(resources.GetObject("mnuSysParam.Glyph")));
            this.mnuSysParam.Id = 5;
            this.mnuSysParam.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("mnuSysParam.LargeGlyph")));
            this.mnuSysParam.Name = "mnuSysParam";
            this.mnuSysParam.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnuSysParam_ItemClick);
            // 
            // mnuCustTicket
            // 
            this.mnuCustTicket.Caption = "Customize Ticket";
            this.mnuCustTicket.Glyph = ((System.Drawing.Image)(resources.GetObject("mnuCustTicket.Glyph")));
            this.mnuCustTicket.Id = 6;
            this.mnuCustTicket.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("mnuCustTicket.LargeGlyph")));
            this.mnuCustTicket.Name = "mnuCustTicket";
            // 
            // mnuDisplay
            // 
            this.mnuDisplay.Caption = "Display Settings";
            this.mnuDisplay.Glyph = ((System.Drawing.Image)(resources.GetObject("mnuDisplay.Glyph")));
            this.mnuDisplay.Id = 7;
            this.mnuDisplay.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("mnuDisplay.LargeGlyph")));
            this.mnuDisplay.Name = "mnuDisplay";
            // 
            // mnuExit
            // 
            this.mnuExit.Caption = "Exit";
            this.mnuExit.Glyph = ((System.Drawing.Image)(resources.GetObject("mnuExit.Glyph")));
            this.mnuExit.Id = 8;
            this.mnuExit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("mnuExit.LargeGlyph")));
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnuExit_ItemClick);
            // 
            // mnuResetPwd
            // 
            this.mnuResetPwd.Caption = "Change Password";
            this.mnuResetPwd.Glyph = ((System.Drawing.Image)(resources.GetObject("mnuResetPwd.Glyph")));
            this.mnuResetPwd.Id = 9;
            this.mnuResetPwd.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("mnuResetPwd.LargeGlyph")));
            this.mnuResetPwd.Name = "mnuResetPwd";
            this.mnuResetPwd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnuResetPwd_ItemClick);
            // 
            // txtStatusBar
            // 
            this.txtStatusBar.Caption = "User:";
            this.txtStatusBar.Id = 10;
            this.txtStatusBar.Name = "txtStatusBar";
            this.txtStatusBar.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // txtStatusTime
            // 
            this.txtStatusTime.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.txtStatusTime.Caption = "TimeDate";
            this.txtStatusTime.Id = 11;
            this.txtStatusTime.Name = "txtStatusTime";
            this.txtStatusTime.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnResetPwd
            // 
            this.btnResetPwd.Caption = "Reset Password";
            this.btnResetPwd.Glyph = ((System.Drawing.Image)(resources.GetObject("btnResetPwd.Glyph")));
            this.btnResetPwd.Id = 1;
            this.btnResetPwd.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnResetPwd.LargeGlyph")));
            this.btnResetPwd.Name = "btnResetPwd";
            this.btnResetPwd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResetPwd_ItemClick);
            // 
            // btnMain
            // 
            this.btnMain.Caption = "Weighment";
            this.btnMain.Glyph = ((System.Drawing.Image)(resources.GetObject("btnMain.Glyph")));
            this.btnMain.Id = 2;
            this.btnMain.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnMain.LargeGlyph")));
            this.btnMain.Name = "btnMain";
            this.btnMain.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMain_ItemClick);
            // 
            // mnuMain
            // 
            this.mnuMain.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnAdmin,
            this.rbnSetup,
            this.rbnExit});
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Text = "Admin";
            // 
            // rbnAdmin
            // 
            this.rbnAdmin.ItemLinks.Add(this.mnuAddUser);
            this.rbnAdmin.ItemLinks.Add(this.mnuResetPwd);
            this.rbnAdmin.ItemLinks.Add(this.btnResetPwd);
            this.rbnAdmin.ItemLinks.Add(this.mnuBackup);
            this.rbnAdmin.ItemLinks.Add(this.mnuRestore);
            this.rbnAdmin.Name = "rbnAdmin";
            this.rbnAdmin.Text = "Admin";
            // 
            // rbnSetup
            // 
            this.rbnSetup.ItemLinks.Add(this.mnuSysParam);
            this.rbnSetup.ItemLinks.Add(this.mnuCustTicket);
            this.rbnSetup.ItemLinks.Add(this.mnuDisplay);
            this.rbnSetup.Name = "rbnSetup";
            this.rbnSetup.Text = "Setup";
            // 
            // rbnExit
            // 
            this.rbnExit.ItemLinks.Add(this.mnuExit);
            this.rbnExit.Name = "rbnExit";
            this.rbnExit.Text = "Exit";
            // 
            // mnuWeigh
            // 
            this.mnuWeigh.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnWB});
            this.mnuWeigh.Name = "mnuWeigh";
            this.mnuWeigh.Text = "Weigh Bridge";
            // 
            // rbnWB
            // 
            this.rbnWB.ItemLinks.Add(this.btnMain);
            this.rbnWB.Name = "rbnWB";
            this.rbnWB.Text = "Menu";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.txtStatusBar);
            this.ribbonStatusBar.ItemLinks.Add(this.txtStatusTime);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 486);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(762, 31);
            // 
            // FrmHome
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 517);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "FrmHome";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "iBridge";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage mnuMain;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnAdmin;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem mnuAddUser;
        private DevExpress.XtraBars.BarButtonItem mnuBackup;
        private DevExpress.XtraBars.BarButtonItem mnuRestore;
        private DevExpress.XtraBars.BarButtonItem mnuSysParam;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnSetup;
        private DevExpress.XtraBars.BarButtonItem mnuCustTicket;
        private DevExpress.XtraBars.BarButtonItem mnuDisplay;
        private DevExpress.XtraBars.BarButtonItem mnuExit;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnExit;
        private DevExpress.XtraBars.BarButtonItem mnuResetPwd;
        private DevExpress.XtraBars.BarStaticItem txtStatusBar;
        private DevExpress.XtraBars.BarStaticItem txtStatusTime;
        private DevExpress.XtraBars.BarButtonItem btnResetPwd;
        private DevExpress.XtraBars.Ribbon.RibbonPage mnuWeigh;
        private DevExpress.XtraBars.BarButtonItem btnMain;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnWB;
    }
}
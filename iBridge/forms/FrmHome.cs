using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraTabbedMdi;

namespace iBridge
{
    public partial class FrmHome : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void mnuAddUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new FrmUsers {MdiParent = this};
            f.Show();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            XtraTabbedMdiManager mdiManager = new XtraTabbedMdiManager {MdiParent = this};
            txtStatusTime.Caption = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            txtStatusBar.Caption = Globals.GUserName;
        }


        private void mnuExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult ans = MessageBox.Show("Exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(ans == DialogResult.Yes)
                Application.Exit();
        }

        private void mnuResetPwd_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new FrmChangePwd {MdiParent = this};
            f.Show();
        }

        private void btnResetPwd_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new FrmResetPwd {MdiParent = this};
            f.Show();
        }

        private void mnuSysParam_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new FrmConnection {MdiParent = this};
            f.Show();

        }

        private void btnMain_ItemClick(object sender, ItemClickEventArgs e)
        {
            Boolean found = false;
            foreach (
                        Form openForm in Application.OpenForms.Cast<Form>().Where(openForm => openForm.GetType() == typeof(FrmWeight))
                    )
            {
                found = true;
            }

            if (found) return;
            FrmWeight f = new FrmWeight {MdiParent = this};
            f.Show();
        }
    }
}
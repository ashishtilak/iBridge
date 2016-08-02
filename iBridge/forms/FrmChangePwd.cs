using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;

namespace iBridge
{
    public partial class FrmChangePwd : DevExpress.XtraEditors.XtraForm
    {
        public FrmChangePwd()
        {
            InitializeComponent();
        }

        private void FrmChangePwd_Load(object sender, EventArgs e)
        {
            txtUserID.Text = Globals.GUserId;
            txtUserName.Text = Globals.GUserName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter new password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string str = "update users set password = '" + iKoot.KootRoop.Encrypt(txtPassword.Text) +
                         "' where userid = '" + txtUserID.Text + "' ";
            try
            {
                using (MySqlConnection cn = new MySqlConnection(Globals.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(str, cn);
                    cn.Open();
                    var result = cmd.ExecuteNonQuery();
                    MessageBox.Show("Password updated.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
             }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
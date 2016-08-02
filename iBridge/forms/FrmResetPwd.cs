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
    public partial class FrmResetPwd : DevExpress.XtraEditors.XtraForm
    {
        public FrmResetPwd()
        {
            InitializeComponent();
        }

        private void txtUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2))
            {
                return;
            }

            Help_F1F2.ClsHelp hlp = new Help_F1F2.ClsHelp();
            string sql = "";

            List<string> obj = new List<string>();

            if (e.KeyCode == Keys.F1)
            {
                sql = "Select UserID, UserName from Users where 1 = 1";
                obj =
                    (List<string>)
                        hlp.Show(sql, "userid", "userid", typeof (string), Globals.ConnectionString.ToString(),
                            "MySql.Data.MySqlClient", 50, 100, 400, 600, 100, 100);
            }

            if (e.KeyCode == Keys.F2)
            {
                sql = "Select UserID, UserName from Users where 1 = 1";
                obj =(List<string>)
                        hlp.Show(sql, "userid", "username", typeof(string), Globals.ConnectionString.ToString(),
                            "MySql.Data.MySqlClient", 50, 100, 400, 600, 100, 100);
            }


            if (obj.Count != 0)
            {
                txtUserID.Text = obj.ElementAt(0).ToString();
                txtUserName.Text = obj.ElementAt(1).ToString();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please select userid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult ans = MessageBox.Show("Are you sure you want to reset password?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ans != DialogResult.Yes) 
                return;
            try
            {
                using (MySqlConnection cn = new MySqlConnection(Globals.ConnectionString))
                {
                    string str = "update users set password = '" + iKoot.KootRoop.Encrypt("init123") + "' " +
                                 "where userid = '" + txtUserID.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(str, cn);
                    cn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Password reset to init123", "Info", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
    }
}
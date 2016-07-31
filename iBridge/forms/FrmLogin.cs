using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace iBridge
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        public Boolean LoginStatus;

        public FrmLogin()
        {
            InitializeComponent();
            LoginStatus = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string err = DataValidate();
            if (!string.IsNullOrEmpty(err))
            {MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            /*
             *  Default userlogin is master/master123 to reset password
             *  check if this is the case...
             */

            if (txtUserID.Text.Trim() == "master")
                if (txtPassword.Text.Trim() == "master123")
                {
                    LoginStatus = true;
                    Close();
                    return;
                }
                else
                    LoginStatus = false;
            // normal login, check in database... first see if connection string exists in config file

            try
            {
                string conn = iBridge.Helper.GetConnectionString();

                try
                {
                    using (MySqlConnection cn = new MySqlConnection(Globals.ConnectionString))
                    {
                        MySqlCommand cmd = new MySqlCommand("Select password, username from users where active = 1 and userid= '" + txtUserID.Text + "' limit 1", cn );
                        cn.Open();
                        MySqlDataReader dr = cmd.ExecuteReader();

                        if(!dr.HasRows)
                        { 
                            MessageBox.Show("Invalid user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LoginStatus = false;
                            return;
                        }

                        while (dr.Read())
                        {
                            string result = dr["Password"].ToString();
                            if (iKoot.KootRoop.Decrypt(result) == txtPassword.Text)
                            {
                                LoginStatus = true;
                                Globals.GUserId = txtUserID.Text;
                                Globals.GUserName = dr["UserName"].ToString();
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Invalid password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        } // end while
                    } // end using
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show("Configuration file is missing, contact support team.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                LoginStatus = false;
                Close();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("Critical error:" + ex1.ToString(), "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                LoginStatus = false;
                Close();                
            }
        }

        private string DataValidate()
        {
            string err = string.Empty;

            if (string.IsNullOrEmpty(txtUserID.Text.Trim()))
                err += "Login ID cannot be blank." + Environment.NewLine;

            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                err += "Password cannot be blank." + Environment.NewLine;

            return err;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoginStatus = false;
            Close();}
    }
}
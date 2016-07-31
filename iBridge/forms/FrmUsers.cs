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
    public partial class FrmUsers : DevExpress.XtraEditors.XtraForm
    {
        private Boolean _isEditing;
        public FrmUsers()
        {
            InitializeComponent();
        }

        private void SetControls()
        {
            txtUserID.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            chkIsAdmin.Checked = false;
            _isEditing = false;
            txtUserID.Enabled = true;
            btnSave.Text = "Save";
            LoadGrid();
        }

        private void LoadGrid()
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(Globals.ConnectionString))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter("select UserID from users where active = 1", cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    dgvMain.DataSource = ds.Tables[0];
                    dgvMain.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string DataValidate()
        {
            string err = "";

            if (string.IsNullOrEmpty(txtUserID.Text))
                err += "Please enter userid" + Environment.NewLine;

            if (string.IsNullOrEmpty(txtPassword.Text))
                err += "Please enter password" + Environment.NewLine;

            if (string.IsNullOrEmpty(txtUserName.Text))
                err += "Please enter username" + Environment.NewLine;

            return err;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_isEditing)
                SetControls();
            else
                Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //check if all fields are filled
            string err = DataValidate();

            //show error and exit if any field left blank
            if (!string.IsNullOrEmpty(err))
            {
                MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetControls(); return;
            }


            try
            {
                using (MySqlConnection cn = new MySqlConnection(Globals.ConnectionString))
                {
                    cn.Open();
                    string str = "";

                    //see if user already exist and need update
                    MySqlCommand cmd =
                        new MySqlCommand("select userid from users where userid = '" + txtUserID.Text + "' limit 1",
                            cn);
                    object strUserId = cmd.ExecuteScalar();

                    if (strUserId != null)
                    {
                        //record exist.
                        str = "update users " +
                              "set username = '" + txtUserName.Text + "', " +
                              "Password = '" + iKoot.KootRoop.Encrypt(txtPassword.Text) + "', " +
                              "IsAdmin = " + (chkIsAdmin.Checked ? "1" : "0") + ", Active = 1 " +
                              "where userid = '" + txtUserID.Text + "'";

                    }
                    else
                    {
                        //record does not exist.
                        str = "insert into users (userid, username, password, isadmin, active) " +
                              "values " +
                              "( '" + txtUserID.Text + "', " +
                              "'" + txtUserName.Text + "', " +
                              "'" + iKoot.KootRoop.Encrypt(txtPassword.Text) + "', " +
                              "" + (chkIsAdmin.Checked ? "1" : "0") + ", 1 " +
                              ")";
                    }
                    cmd = new MySqlCommand(str, cn); int i = cmd.ExecuteNonQuery();

                    SetControls();
                    MessageBox.Show("Updated.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetControls();
            }
        }

        private void dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if user double clicks on grid, get the user details for selected user
            string userId = dgvMain.SelectedRows[0].Cells["UserID"].Value.ToString();

            try
            {
                using (MySqlConnection cn = new MySqlConnection(Globals.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand("select * from Users where userid = '" + userId + "' limit 1", cn);
                    cn.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txtUserID.Text = dr["UserID"].ToString();
                        txtUserID.Enabled = false;
                        txtUserName.Text = dr["UserName"].ToString();
                        txtPassword.Text = iKoot.KootRoop.Decrypt(dr["Password"].ToString());
                        chkIsAdmin.Checked = Convert.ToInt32(dr["IsAdmin"]) == 1 ? true : false;
                        btnSave.Text = "Update";
                        _isEditing = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmUsers_Load(object sender, EventArgs e)
        {
            LoadGrid();
            _isEditing = false;
        }


        private void txtUserID_Validating(object sender, CancelEventArgs e)
        {
            if (txtUserID.Text.Trim() == string.Empty)
                return;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_isEditing)
            {
                MessageBox.Show("Select user first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //so, user has selected a user from grid...
            //set it's active status to false..

            DialogResult ans = MessageBox.Show("Are you sure you want to delete this user?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                string str = "update users set Active = 0 where userid  ='" + txtUserID.Text + "'";
                try
                {
                    using (MySqlConnection cn = new MySqlConnection(Globals.ConnectionString))
                    {
                        MySqlCommand cmd = new MySqlCommand(str, cn);
                        cn.Open();
                        object i = cmd.ExecuteNonQuery();
                        MessageBox.Show("User deleted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetControls();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
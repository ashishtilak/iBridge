using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;
using System.IO;
using MySql.Data.MySqlClient;

namespace iBridge
{
    public partial class FrmConnection : DevExpress.XtraEditors.XtraForm
    {
        public FrmConnection()
        {
            InitializeComponent();
        }

        private Boolean TestConnection()
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection())
                {
                    cn.ConnectionString = "server= " + txtServer.Text + ";" +
                                          "userid= " + txtUserID.Text + ";" +
                                          "password= " + txtPassword.Text + ";" +
                                          "persistsecurityinfo=True;database=iBridge;allowuservariables=True";
                    cn.Open();
                    if (cn.State == ConnectionState.Open)
                    {
                        MessageBox.Show("Connection successful", "Info", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return true;
                    }

                    //else
                    MessageBox.Show("Connection failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException myEx)
            {
                MessageBox.Show("Connection failed! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void FrmConnection_Load(object sender, EventArgs e)
        {
            //try loading the current connection settings from config file..
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load(Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile) +
                            "\\iBridge.config");
                // search for following structure:
                // <configuration>
                //   <userSettings>
                //     <iBridge.Properties.Settings>
                //        <setting name = 'cnStr'>
                //          <value>    <----
                // 
                XmlNode node =
                    xmlDoc.SelectSingleNode(
                        "configuration/userSettings/iBridge.Properties.Settings/setting[@name='cnStr']/value");
                if (node != null)
                {
                    string str = node.InnerText;

                    //string will be of following format
                    //server= localhost;port= 3306;userid= root;password= root;persistsecurityinfo=True;database=iscada;allowuservariables=True
                    //break all individual part and store in textbox

                    if (str != string.Empty)
                    {
                        string[] conn = str.Split(';');

                        // remove first 7 characters from server= localhost;
                        txtServer.Text = conn[0].Substring(7, conn[0].Length - 7).Trim();
                        
                        // remove first 5 characters from port= 3306;
                        txtPort.Text = conn[1].Substring(5, conn[1].Length - 5).Trim();

                        // remove first 7 characters from userid= root;
                        txtUserID.Text = conn[2].Substring(7, conn[2].Length - 7).Trim();

                        // remove first 9 characters from password= andupandu;
                        txtPassword.Text = conn[3].Substring(9, conn[3].Length - 9).Trim();
                        // need to decrypt password...
                        txtPassword.Text = iKoot.KootRoop.Decrypt(txtPassword.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Critical error in configuration file.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Critical error in configuration file. " + ex.ToString(), "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (txtServer.Text == string.Empty || txtPort.Text == string.Empty || txtUserID.Text == string.Empty ||
                txtPassword.Text == string.Empty)
                MessageBox.Show("Enter all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            TestConnection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Boolean res = TestConnection();
            if (res)
            {
                //Load config file

                try
                {

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile) +
                                "\\iBridge.config");

                    XmlNode node =
                        xmlDoc.SelectSingleNode(
                            "configuration/userSettings/iBridge.Properties.Settings/setting[@name='cnStr']/value");

                    if (node == null)
                    {
                        MessageBox.Show("Cannot save setting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string str = "server= " + txtServer.Text + ";" +
                                 "port= " + txtPort.Text + ";" +
                                 "userid= " + txtUserID.Text + ";" +
                                 "password= " + iKoot.KootRoop.Encrypt(txtPassword.Text) + ";" +
                                 "persistsecurityinfo=True;database=iBridge;allowuservariables=True";

                    //write setting in the xmlnode
                    node.InnerText = str;

                    xmlDoc.Save(Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile) +
                                "\\iBridge.config");

                    //store this new string in the global connection string
                    Globals.ConnectionString = str;

                    MessageBox.Show("Connection settings saved.", "Info", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    Close();}
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
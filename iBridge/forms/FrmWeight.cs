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
    public partial class FrmWeight : DevExpress.XtraEditors.XtraForm
    {
        private enum GMode
        {
            Single,
            Double,
            Multiple,
            Container,
        }

        private enum GLoaded
        {
            Loaded,
            Empty,
        }

        private GMode _gMode;
        private GLoaded _gLoaded;
        private int _gScale;

        public FrmWeight()
        {
            InitializeComponent();
        }

        private void SetMode()
        {
            // depending upon pressed button, set the modes
            btnAdd.Enabled = false;

            // for weighment type buttons
            btnSingle.ForeColor = btnDouble.ForeColor = btnMultiple.ForeColor = btnContainer.ForeColor = Color.Black;

            if (btnSingle.Checked)
            {
                _gMode = GMode.Single;
                btnSingle.ForeColor = Color.Red;
            }

            if (btnDouble.Checked)
            {
                _gMode = GMode.Double;
                btnDouble.ForeColor = Color.Red;
            }

            if (btnMultiple.Checked)
            {
                _gMode = GMode.Multiple;
                btnMultiple.ForeColor = Color.Red;
                btnAdd.Enabled = true;}

            if (btnContainer.Checked)
            {
                _gMode = GMode.Container;
                btnContainer.ForeColor = Color.Red;
            }
            

            // for loaded button
            btnLoaded.ForeColor = btnEmpty.ForeColor = Color.Black;
            if (btnLoaded.Checked)
            {
                _gLoaded = GLoaded.Loaded;
                btnLoaded.ForeColor = Color.Red;
            }

            if (btnEmpty.Checked)
            {
                _gLoaded = GLoaded.Empty;
                btnEmpty.ForeColor = Color.Red;
            }

        }

        private void LoadVehicles()
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(Globals.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand("select VehicleNo from vehicles order by vehicleno", cn);
                    cn.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();

                    AutoCompleteStringCollection comboData = new AutoCompleteStringCollection();
                    while (dr.Read())
                    {
                        comboData.Add(dr["VehicleNo"].ToString());
                    }

                    txtVehicle.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtVehicle.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtVehicle.AutoCompleteCustomSource = comboData;txtVehicle.DataSource = comboData;
                    txtVehicle.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAccounts()
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(Globals.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand("select account from accounts order by account", cn);
                    cn.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();

                    AutoCompleteStringCollection comboData = new AutoCompleteStringCollection();
                    while (dr.Read())
                    {
                        comboData.Add(dr["account"].ToString());}

                    txtAccount.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtAccount.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtAccount.AutoCompleteCustomSource = comboData;
                    txtAccount.DataSource = comboData;
                    txtAccount.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts()
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(Globals.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand("select product from products order by product", cn);
                    cn.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();

                    AutoCompleteStringCollection comboData = new AutoCompleteStringCollection();
                    while (dr.Read())
                    {
                        comboData.Add(dr["product"].ToString());
                    }

                    txtProduct.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtProduct.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtProduct.AutoCompleteCustomSource = comboData;
                    txtProduct.DataSource = comboData;
                    txtProduct.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTransporters()
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(Globals.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand("select transporter from transporters order by transporter", cn);
                    cn.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();

                    AutoCompleteStringCollection comboData = new AutoCompleteStringCollection();
                    while (dr.Read())
                    {
                        comboData.Add(dr["transporter"].ToString());
                    }

                    txtTransporter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtTransporter.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtTransporter.AutoCompleteCustomSource = comboData;
                    txtTransporter.DataSource = comboData;
                    txtTransporter.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void LoadVehicleTypes()
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(Globals.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand("select vehicletype from vehicletypes order by vehicletype", cn);
                    cn.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();

                    AutoCompleteStringCollection comboData = new AutoCompleteStringCollection();
                    while (dr.Read())
                    {
                        comboData.Add(dr["vehicletype"].ToString());
                    }

                    txtVehicleType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtVehicleType.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtVehicleType.AutoCompleteCustomSource = comboData;
                    txtVehicleType.DataSource = comboData;
                    txtVehicleType.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                        
        }

        private void SetControls()
        {
            LoadVehicles();
            LoadAccounts();
            LoadProducts();
            LoadTransporters();
            LoadVehicleTypes();
            
        }

        private void FrmWeight_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            // default buttons
            btnDouble.Checked = true;
            btnLoaded.Checked = true;
            btnScale1.Checked = true;

            SetControls();
        }


        private void btnSingle_CheckedChanged(object sender, EventArgs e)
        {
            SetMode();
        }

        private void btnDouble_CheckedChanged(object sender, EventArgs e)
        {
            SetMode();
        }

        private void btnMultiple_CheckedChanged(object sender, EventArgs e)
        {
            SetMode();
        }

        private void btnContainer_CheckedChanged(object sender, EventArgs e)
        {
            SetMode();
        }

        private void btnLoaded_CheckedChanged(object sender, EventArgs e)
        {
            SetMode();
        }

        private void btnEmpty_CheckedChanged(object sender, EventArgs e)
        {
            SetMode();
        }

        private void FrmWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control) return;
            switch (e.KeyCode)
            {
                // short cut keys for mode selection
                case Keys.D1:
                    btnSingle.Checked = true;
                    break;
                case Keys.D2:
                    btnDouble.Checked = true;
                    break;
                case Keys.D3:
                    btnMultiple.Checked = true;
                    break;
                case Keys.D4:
                    btnContainer.Checked = true;
                    break;
                case Keys.L:
                    btnLoaded.Checked = true;
                    break;
                case Keys.E:
                    btnEmpty.Checked = true;
                    break;

                // short cut key for save button
                case Keys.S:
                    btnSave_Click(sender, e);
                    break;
                case Keys.P:
                    btnPrint_Click(sender, e);
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //stub
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //stub
        }
    }
}
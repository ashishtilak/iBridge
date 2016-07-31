using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iBridge
{
    public partial class FrmSecurityKey : Form
    {
        public string SystemId { get; set; }
        public Boolean Result;

        public FrmSecurityKey(string systemId)
        {
            InitializeComponent();
            SystemId = systemId;
            Result = false;
        }

        private void FrmSecurityKey_Load(object sender, EventArgs e)
        {
            if (SystemId != string.Empty)
                txtSystemID.Text = SystemId;
            else
                txtSystemID.Text = "ERROR! Contact developers...";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Result = false;
            this.Close();
        }



    }
}

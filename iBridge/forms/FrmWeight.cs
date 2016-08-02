using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

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

        private void FrmWeight_Load(object sender, EventArgs e)
        {
            btnDouble.Checked = true;
            btnLoaded.Checked = true;
            btnScale1.Checked = true;
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
    }
}
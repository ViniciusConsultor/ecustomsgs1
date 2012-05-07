using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECustoms.BOL;
using ECustoms.DAL;
using ECustoms.Utilities;

namespace ECustoms
{
    public partial class FrmVehicleFeeReport : Form
    {
        private UserInfo _userInfo;
        public FrmVehicleFeeReport()
        {
            InitializeComponent();
        }

        public FrmVehicleFeeReport(UserInfo userInfo)
        {
            InitializeComponent();
            _userInfo = userInfo;
        }

        private void cbFeeImport_CheckedChanged(object sender, EventArgs e)
        {
            dtpImportFrom.Enabled = cbFeeImport.Checked;
            dtpImportTo.Enabled = cbFeeImport.Checked;
        }

        private void cbFeeExport_CheckedChanged(object sender, EventArgs e)
        {
            dtpExportFrom.Enabled = cbFeeExport.Checked;
            dtpExportTo.Enabled = cbFeeExport.Checked;
        }

        private void FrmVehicleFeeReport_Load(object sender, EventArgs e)
        {
            cbFeeExport.Checked = true;
            cbFeeImport.Checked = true;
        }
    }
}

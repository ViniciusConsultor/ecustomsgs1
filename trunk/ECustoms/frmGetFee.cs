using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECustoms.DAL;
using ECustoms.Utilities;
using log4net;
using ECustoms.BOL;

namespace ECustoms
{
    public partial class frmGetFee : Form
    {
        private static ILog logger = LogManager.GetLogger("ECustoms.frmListVehicleType");
        private UserInfo _userinfo;

        public frmGetFee()
        {
            InitializeComponent();
        }

        public frmGetFee(UserInfo userInfo)
        {
            InitializeComponent();
            _userinfo = userInfo;

        }

        private void frmGetFee_Load(object sender, EventArgs e)
        {
            this.Text = "Thu phí" + ConstantInfo.MESSAGE_TITLE;
            //Init data
            Search();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Search();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
           
        }

        
        /// <summary>
        /// Tìm kiếm phương tiện thu phí
        /// </summary>        
        private void Search()
        {
            var packFrom = new DateTime(dtpParkingDateFrom.Value.Year, dtpParkingDateFrom.Value.Month, dtpParkingDateFrom.Value.Day, 0, 0, 0);
            var packTo = new DateTime(dtpParkingDateTo.Value.Year, dtpParkingDateTo.Value.Month, dtpParkingDateTo.Value.Day, 23, 59, 59);
            var createdFrom = new DateTime(dtpCreatedDateFrom.Value.Year, dtpCreatedDateFrom.Value.Month, dtpCreatedDateFrom.Value.Day, 0, 0, 0);
            var createdTo = new DateTime(dtpCreatedDateTo.Value.Year, dtpCreatedDateTo.Value.Month, dtpCreatedDateTo.Value.Day, 23, 59, 59);
            var listVehicle =  VehicleFactory.SeachFee(txtPlateNumber.Text.Trim(), txtReceiptNumber.Text.Trim(),cbCreatedVehicle.Checked, createdFrom, createdTo, cbIsParking.Checked, packFrom, packTo, cbHasFeeExport.Checked, cbHasFeeImport.Checked);
            // Bind data to the gridview
            grdVehicle.AutoGenerateColumns = false;

            listVehicle = listVehicle.Distinct(new ViewAllVehicleHasGoodComparer()).ToList();

            grdVehicle.DataSource = listVehicle;
            txtPlateNumber.Focus();
        }

        private void btnFeeExport_Click(object sender, EventArgs e)
        {

        }

        #region Private Class
        /// <summary>
        /// Class to compare ViewAllVehicleHasGood
        /// </summary>
        private class ViewAllVehicleHasGoodComparer : IEqualityComparer<ViewAllVehicleHasGood>
        {
            public bool Equals(ViewAllVehicleHasGood x, ViewAllVehicleHasGood y)
            {
                if (Object.ReferenceEquals(x, y)) return true;
                if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;
                return x.VehicleID == y.VehicleID;
            }
            public int GetHashCode(ViewAllVehicleHasGood vehicle)
            {
                if (Object.ReferenceEquals(vehicle, null)) return 0;
                var hashVehicleId = vehicle.VehicleID.GetHashCode();
                return hashVehicleId;
            }
        }
        #endregion

        private void txtPlateNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Enter key
            {
                Search();
            }
        }

        private void txtReceiptNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Enter key
            {
                Search();
            }
        }

        private void cbCreatedVehicle_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCreatedVehicle.Checked)
            {
                dtpCreatedDateFrom.Enabled = dtpCreatedDateTo.Enabled = true;
            }
            else
            {
                dtpCreatedDateFrom.Enabled = dtpCreatedDateTo.Enabled = false;    
            }
        }

        private void cbIsParking_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsParking.Checked)
            {
                dtpParkingDateFrom.Enabled = dtpParkingDateTo.Enabled = true;
            }
            else
            {
                dtpParkingDateFrom.Enabled = dtpParkingDateTo.Enabled = false;
            }
        }
    }
}

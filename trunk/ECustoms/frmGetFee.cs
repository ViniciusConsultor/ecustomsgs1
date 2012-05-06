using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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

        }

        private void Init()
        {
            // Lần đầu tiên mở form: lấy tất cảc các phương tiện chưa nộp phí.
            //Search(string.Empty, string.Empty, dtpParkingDateFrom.Value, dtpParkingDateTo.Value, cbHasFee.Checked);
            // First time load: Load all vehicle that have not 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        
        /// <summary>
        /// Tìm kiếm phương tiện thu phí
        /// </summary>        
        private void Search()
        {
            var packFrom = new DateTime(dtpParkingDateFrom.Value.Year, dtpParkingDateFrom.Value.Month, dtpParkingDateFrom.Value.Day, 0, 0, 0);
            var packTo = new DateTime(dtpParkingDateTo.Value.Year, dtpParkingDateTo.Value.Month, dtpParkingDateTo.Value.Day, 23, 59, 59);
            var listVehicle =  VehicleFactory.SeachFee(txtPlateNumber.Text.Trim(), txtReceiptNumber.Text.Trim(), packFrom, packTo);
            // Bind data to the gridview

        }
    }
}

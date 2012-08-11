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
using log4net;
using ECustoms.Utilities;
using ECustoms.Utilities.Enums;

namespace ECustoms
{
    public partial class frmVehicleOverdue : Form
    {
        private static ILog logger = LogManager.GetLogger("ECustoms.frmVehicleOverdue");
        private UserInfo _userInfo;
        private int overdueDate;
        public frmVehicleOverdue()
        {
            InitializeComponent();
        }
        public frmVehicleOverdue(UserInfo userInfo)
        {
            InitializeComponent();
            _userInfo = userInfo;

            // get user info
            var profileConfig = UserFactory.GetProfileConfigByUserId(_userInfo.UserID);
            foreach (var config in profileConfig)
            {
                if (config.Type == (int)ProfileConfig.OverdueDate)
                {
                    int.TryParse(config.Value, out overdueDate);
                    continue;
                }
            }
        }

        private void frmVehicleOverdue_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            grdVehicleOverdue.AutoGenerateColumns = false;
            grdVehicleOverdue.DataSource = VehicleOvedueFactory.GetVehicleOverdue(overdueDate);
        }

        private void Search()
        {
            List<ViewVehicleOverdue> list = VehicleOvedueFactory.GetAllVehicleNotCompleted();
            if (txtPlateNumber.Text.Trim().Length > 0)
            {
 //               list = list.Where(g => g.PlateNumber.Contains(txtPlateNumber.Text.Trim())).ToList();
            }
            if (txtDriverName.Text.Trim().Length > 0)
            {
                list = list.Where(g => g.DriverName.Contains(txtDriverName.Text.Trim())).ToList();
            }
            grdVehicleOverdue.AutoGenerateColumns = false;
            grdVehicleOverdue.DataSource = list;
            foreach (var item in list) { 
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

    }

}

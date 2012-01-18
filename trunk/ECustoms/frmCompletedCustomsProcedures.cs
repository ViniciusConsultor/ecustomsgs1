using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECustoms.Utilities;
using ECustoms.BOL;
using ECustoms.DAL;
using log4net;

namespace ECustoms
{
    public partial class frmCompletedCustomsProcedures : Form
    {
        private static ILog logger = LogManager.GetLogger("Ecustoms.frmVehicleSearch");
        private UserInfo _userInfo;
        private Form _mainForm;

        public frmCompletedCustomsProcedures()
        {
            InitializeComponent();
        }

        public frmCompletedCustomsProcedures(UserInfo userInfo, Form mainForm)
        {
            InitializeComponent();
            _userInfo = userInfo;
            //InitialPermission();
            _mainForm = mainForm;
        }

        private void frmCompletedCustomsProcedures_Load(object sender, EventArgs e)
        {
            this.Text = "Đã hoàn thành thủ tục hải quan" + ConstantInfo.MESSAGE_TITLE;

            BindData();
        }

        private void BindData()
        {
            grdVehicleCompleted.AutoGenerateColumns = false;
            List<ViewAllVehicleHasGood> result = VehicleFactory.GetAllAllVehicleCompleted();
            grdVehicleCompleted.DataSource = result;
        }
    }
}

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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ECustoms
{
    public partial class frmListVehicleType : Form
    {
        private UserInfo userinfo;
        public frmListVehicleType()
        {
            InitializeComponent();
        }

        public frmListVehicleType(UserInfo _userInfo)
        {
            InitializeComponent();
            userinfo = _userInfo;

        }

        private void frmListVehicleType_Load(object sender, EventArgs e)
        {
            this.Text = "Danh sách loại phương tiện và biểu phí" + ConstantInfo.MESSAGE_TITLE;
        }
    }
}

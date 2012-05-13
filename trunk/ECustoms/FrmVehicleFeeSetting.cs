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
    public partial class FrmVehicleFeeSetting : Form
    {
        private UserInfo _userInfo;
        public FrmVehicleFeeSetting()
        {
            InitializeComponent();
        }

        public FrmVehicleFeeSetting(UserInfo userInfo)
        {
            InitializeComponent();
            _userInfo = userInfo; 
        }

        private void FrmVehicleFeeSetting_Load(object sender, EventArgs e)
        {
            this.Text = "Cấu hình tính phí phương tiện " + ConstantInfo.MESSAGE_TITLE;
            
        }
    }
}

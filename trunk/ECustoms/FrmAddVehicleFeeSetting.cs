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
    public partial class FrmAddVehicleFeeSetting : Form
    {
        private UserInfo _userInfo;
        private int _type;
        private FrmVehicleFeeSetting _mainForm;
        public FrmAddVehicleFeeSetting()
        {
            InitializeComponent();
        }

        public FrmAddVehicleFeeSetting(UserInfo userInfo, int type, FrmVehicleFeeSetting mainForm)
        {
            //type =0: them moi
            //type=1: cap nhat
            InitializeComponent();
            _userInfo = userInfo;
            _type = type;
            _mainForm = mainForm;

            if (_type == 0)
            {
                this.Text = "Thêm mới cấu hình tính phí phương tiện " + ConstantInfo.MESSAGE_TITLE;
            }
            else if (_type == 1)
            {
                this.Text = "Cập nhật cấu hình tính phí phương tiện " + ConstantInfo.MESSAGE_TITLE;
            }
        }

        private void FrmAddVehicleFeeSetting_Load(object sender, EventArgs e)
        {
            this.Location = new Point((_mainForm.Width - this.Width) / 2, (_mainForm.Height - this.Height) / 2);
        }
    }
}

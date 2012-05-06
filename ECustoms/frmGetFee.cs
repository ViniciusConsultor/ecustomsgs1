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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

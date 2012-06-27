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

namespace ECustoms
{
    public partial class FrmAddType : Form
    {
        private int _mode;  //_mode=0 : add new; _mode=1 : edit
        private string _typeCode;
        private UserInfo _userInfo;
        private FrmListType _frmListType;
        public FrmAddType()
        {
            InitializeComponent();
        }

        public FrmAddType(String typeCode, int mode, UserInfo userInfo, FrmListType frmListType)
        {
            _userInfo = userInfo;
            _typeCode = typeCode;
            _mode = mode;
            _frmListType = frmListType;

            InitializeComponent();
        }

        private void FrmAddType_Load(object sender, EventArgs e)
        {
            if (_mode == 0) //add new
            {
                this.Text = "Them moi loai hinh" + ConstantInfo.MESSAGE_TITLE;
            }

            if (_mode == 0) //update
            {
                this.Text = "Cap nhat loai hinh" + ConstantInfo.MESSAGE_TITLE;
            }
        }
    }
}

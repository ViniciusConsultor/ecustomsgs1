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
    public partial class FrmListType : Form
    {
        private UserInfo _userInfo;
        public FrmListType()
        {
            InitializeComponent();
        }

        public FrmListType(UserInfo userInfo)
        {
            _userInfo = userInfo;
            InitializeComponent();
        }

        private void FrmListType_Load(object sender, EventArgs e)
        {
            this.Text = "Danh sach loai hinh" + ConstantInfo.MESSAGE_TITLE;
            init();
        }

        public void init()
        {
            List<tblType> listType = TypeFactory.getAllType();
            grvType.AutoGenerateColumns = false;
            grvType.DataSource = listType;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddType frmAddType = new FrmAddType(null, 0, _userInfo, this);
            frmAddType.MdiParent = this.MdiParent;
            frmAddType.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

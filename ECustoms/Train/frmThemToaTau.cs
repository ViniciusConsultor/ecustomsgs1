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
using ECustoms.Utilities;
using ECustoms.Utilities.Enums;

namespace ECustoms.Train
{
    public partial class frmThemToaTau : Form
    {
        private UserInfo _userInfo;
        private short _mode; //0: addnew, 1: edit
        private long _TrainId;

        public frmThemToaTau()
        {
            InitializeComponent();
        }

        public frmThemToaTau(UserInfo userInfo)
        {
            InitializeComponent();
            _userInfo = userInfo;
            //_TrainId = trainId;
        }

        private void frmPartTrainExport_Load(object sender, EventArgs e)
        {
            this.Text = "Khai bao toa tau " + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            Init();
        }

        private void Init()
        {
            //mode
            if (_mode == 0)
            {
                btnUpdate.Enabled = btnDelete.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Validate()
        {
            return techlinkErrorProvider1.Validate(this);
        }

        private void Reset()
        {
            txtNumber.Text = txtSoVanDon.Text = txtTenHang.Text = txtTrongLuong.Text = txtSealVT.Text = txtSealHQ.Text = string.Empty;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate()) return;
                //var train = new tblTrain();
                //train.Number = txtNumber.Text.Trim();
                //train.Type = (short)((ComboBoxItem)ddlTypeName.SelectedItem).Value;
                //if (train.Type == (short)TrainType.TypeExport)
                //{
                //    train.IsExport = true;
                //    train.DateExport = dtpRegisterDate.Value;
                //}
                //else if (train.Type == (short)TrainType.TypeImport)
                //{
                //    train.IsImport = true;
                //    train.DateImport = dtpRegisterDate.Value;
                //}
                //train.NumberPartTrain = txtSoVanDon.Text.Trim();

                //train.CreatedBy = _userInfo.UserID;
                //if (TrainFactory.Insert(train) > 0)
                //{
                //    MessageBox.Show("Thêm mới thành công!");
                //    Reset();
                //}
                //else MessageBox.Show("Thêm mới không thành công!");

            }
            catch (Exception ex)
            {
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}

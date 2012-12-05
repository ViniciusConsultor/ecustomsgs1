using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ECustoms.BOL;
using ECustoms.DAL;
using ECustoms.Utilities;
using ECustoms.Utilities.Enums;

namespace ECustoms.Train
{
    public partial class frmTrainImport : Form
    {
        private short _type; //0: xuat canh, 1 nhap canh
        private short _mode; //0: addnew, 1: edit
        private UserInfo _userInfo;

        public frmTrainImport()
        {
            InitializeComponent();
        }
        public frmTrainImport(UserInfo userInfo, short type)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _type = type;
        }

        private void frmTrainImport_Load(object sender, EventArgs e)
        {
            this.Text = "Tau hang Trung Quoc" + (_type == 0 ? "xuat canh" : "nhap canh") + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            Init();
        }

        private void Init()
        {
            //init data for Type
            var listType = new List<ComboBoxItem>();
            if (_type == 0)
            {
                listType.Add(new ComboBoxItem((short)TrainType.TypeExportNormal, "Xuất cảnh thông thường"));
                listType.Add(new ComboBoxItem((short)TrainType.TypeExportChange, "Xuất cảnh chuyển cảng"));

                lblHeader.Text = "Khai báo tàu hàng Trung Quốc xuất cảnh";
            }
            else if (_type == 1)
            {
                listType.Add(new ComboBoxItem((short)TrainType.TypeImportNormal, "Nhập cảnh thông thường"));
                listType.Add(new ComboBoxItem((short)TrainType.TypeImportChange, "Nhập cảnh chuyển cảng"));

                lblHeader.Text = "Khai báo tàu hàng Trung Quốc nhập cảnh";
            }
            ddlTypeName.Items.AddRange(listType.ToArray());
            ddlTypeName.SelectedIndex = 1;

            //mode
            if (_mode == 0)
            {
                btnUpdate.Enabled = btnDelete.Enabled = false;
            }
        }

        private void ddlTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var type = (short)((ComboBoxItem)ddlTypeName.SelectedItem).Value;
            if (type == (short)TrainType.TypeExportChange || type == (short)TrainType.TypeImportChange)
            {
                pnChangeStation.Visible = true;
                pnNormally.Visible = false;
            }
            else
            {
                pnChangeStation.Visible = false;
                pnNormally.Visible = true;
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
            txtNumberTrain.Text = string.Empty;
            ddlTypeName.SelectedIndex = 1;
            dtpRegisterDate.Value = DateTime.Now;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate()) return;
                var train = new tblTrain();
                train.Number = txtNumberTrain.Text.Trim();
                var type = (short)((ComboBoxItem)ddlTypeName.SelectedItem).Value;
                train.Type = type;
                if (type == (short)TrainType.TypeExportChange || type == (short)TrainType.TypeImportChange)
                {
                    train.NumberHandover = txtNumberHandover.Text.Trim();
                    train.DateHandover = dtpHandover.Value;
                    train.StationStart = txtStart.Text.Trim();
                    train.StationEnd = txtEnd.Text.Trim();
                    train.CompanyCode = txtCompanyCode.Text.Trim();
                    train.Partner = txtPartner.Text.Trim();
                    train.StatusVehicle = txtStatusVehicle.Text.Trim();
                    train.StatusGoods = txtStatusGood.Text.Trim();
                }
                else
                {
                    
                }

                train.CreatedBy = _userInfo.UserID;
                if (TrainFactory.Insert(train) > 0)
                {
                    MessageBox.Show("Thêm mới thành công!");
                    Reset();
                }
                else MessageBox.Show("Thêm mới không thành công!");
            }
            catch (Exception ex)
            {
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }
    }
}

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
        private List<tblToaTau> _listToaTau;


        public frmThemToaTau()
        {
            InitializeComponent();
        }

        public frmThemToaTau(short mode, UserInfo userInfo, ref List<tblToaTau> listToaTau)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _mode = mode;
            _listToaTau = listToaTau;
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
            txtNumber.Text = txtSoVanDon.Text = txtTenHang.Text = txtTrongLuong.Text = txtSealVT.Text = txtSealHQ.Text = txtDVT.Text = txtPartner.Text = txtCompanyCode.Text = txtCompanyName.Text = txtNote.Text = string.Empty;
            dtpVanDon.Value = DateTime.Now;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate()) return;
                var toaTau = new tblToaTau()
                                 {
                                     Ma_ToaTau = txtNumber.Text.Trim(),
                                     So_VanTai_Don = txtSoVanDon.Text.Trim(),
                                     Ngay_VanTai_Don = dtpVanDon.Value,
                                     Ten_DoiTac = txtPartner.Text.Trim(),
                                     Ma_DoanhNghiep = txtCompanyCode.Text.Trim(),
                                     Ten_Hang = txtTenHang.Text.Trim(),
                                     Trong_Luong = txtTrongLuong.Text.Trim(),
                                     Don_Vi_Tinh = txtDVT.Text.Trim(),
                                     Seal_VanTai = txtSealVT.Text.Trim(),
                                     Seal_HaiQuan = txtSealHQ.Text.Trim(),
                                     Ghi_Chu = txtNote.Text.Trim()
                                 };

                _listToaTau.Add(toaTau);
                ((frmTrainImport)this.Owner.ActiveMdiChild).BindToaTau();
                MessageBox.Show("Thêm mới toa tàu thành công!");
                Reset();

            }
            catch (Exception ex)
            {
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void txtCompanyCode_Leave(object sender, EventArgs e)
        {
            var companyCode = txtCompanyCode.Text.Trim();
            var company = CompanyFactory.FindByCode(companyCode);
            txtCompanyName.Text = company != null ? Converter.TCVN3ToUnicode(company.CompanyName) : "";
        }
    }
}

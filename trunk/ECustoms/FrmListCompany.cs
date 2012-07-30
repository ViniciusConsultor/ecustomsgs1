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
    public partial class FrmListCompany : SubFormBase
    {
        private static ILog logger = LogManager.GetLogger("ECustoms.FrmListCompany");
        private UserInfo _userInfo;

        public FrmListCompany()
        {
            InitializeComponent();
        }

        public FrmListCompany(UserInfo userInfo)
        {
            _userInfo = userInfo;
            InitializeComponent();
           
        }

        private void FrmListCompany_Load(object sender, EventArgs e)
        {
            this.Text = "Danh sach doanh nghiep" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            init();
        }

        public void init()
        {
            List<tblCompany> list = CompanyFactory.getAllCompany();
            grvCompany.AutoGenerateColumns = false;
            grvCompany.DataSource = list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddCompany frmAddCompany = new FrmAddCompany(null, 0, _userInfo, this);
            frmAddCompany.MdiParent = this.MdiParent;
            frmAddCompany.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        public void search()
        {
            List<tblCompany> list = CompanyFactory.getAllCompany();
            if (txtCompanyCode.Text.Trim().Length > 0)
            {
                list = list.Where(g => g.CompanyCode.Contains(txtCompanyCode.Text.Trim())).ToList();
            }
            if (txtCompanyName.Text.Trim().Length > 0)
            {
                list = list.Where(g => g.CompanyName.Contains(txtCompanyName.Text.Trim())).ToList();
            }

            grvCompany.AutoGenerateColumns = false;
            grvCompany.DataSource = list;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grvCompany.SelectedRows.Count > 0)
                {
                    int selectedIndex = grvCompany.SelectedRows[0].Index;

                    // gets the RowID from the first column in the grid
                    var companyCode = grvCompany[0, selectedIndex].Value.ToString();

                    tblCompany company = CompanyFactory.FindByCode(companyCode);
                    if (company == null)
                    {
                        MessageBox.Show("Doanh nghiệp này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    FrmAddCompany frmAddCompany = new FrmAddCompany(companyCode, 1, _userInfo, this);
                    frmAddCompany.MdiParent = this.MdiParent;
                    frmAddCompany.Show();
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn một bản ghi để cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            } 
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grvCompany.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Bạn thự sự muốn xóa loại hình đã chọn?", "Cảnh báo!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        int selectedIndex = grvCompany.SelectedRows[0].Index;

                        // gets the RowID from the first column in the grid
                        var companyCode = grvCompany[0, selectedIndex].Value.ToString();

                        tblCompany company = CompanyFactory.FindByCode(companyCode);
                        if (company == null)
                        {
                            MessageBox.Show("Loại hình này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        List<tblDeclaration> listDeclaration = DeclarationFactory.getByCompany(companyCode);
                        if (null != listDeclaration && listDeclaration.Count > 0)
                        {
                            MessageBox.Show("Tồn tại tờ khai của doanh nghiệp này, bạn không thể xóa được. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (CompanyFactory.Delete(companyCode) > 0)
                        {
                            search();
                            MessageBox.Show("Xóa doanh nghiệp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           
                        }
                        else
                        {
                            search();
                            MessageBox.Show("Xóa doanh nghiệp không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            
                        }
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Bạn cần chọn một bản ghi để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            } 
        }

        private void grvCompany_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.grvCompany.SelectedRows.Count > 0)
                {
                    int selectedIndex = grvCompany.SelectedRows[0].Index;

                    // gets the RowID from the first column in the grid
                    var companyCode = grvCompany[0, selectedIndex].Value.ToString();

                    tblCompany company = CompanyFactory.FindByCode(companyCode);
                    if (company == null)
                    {
                        MessageBox.Show("Doanh nghiệp này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    FrmAddCompany frmAddCompany = new FrmAddCompany(companyCode, 1, _userInfo, this);
                    frmAddCompany.MdiParent = this.MdiParent;
                    frmAddCompany.Show();
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn một bản ghi để cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            } 
        }
    }
}

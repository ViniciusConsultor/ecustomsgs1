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
        private static ILog logger = LogManager.GetLogger("ECustoms.FrmListType");
        private UserInfo _userinfo;
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

        private void grbConditionSearch_Enter(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }
        public void search()
        {
            List<tblType> list = TypeFactory.getAllType();
            if (txtTypeCode.Text.Trim().Length > 0)
            {
                list = list.Where(g => g.TypeCode.Contains(txtTypeCode.Text.Trim())).ToList();
            }
            if (txtTypeName.Text.Trim().Length > 0)
            {
                list = list.Where(g => g.TypeName.Contains(txtTypeName.Text.Trim())).ToList();
            }

            grvType.AutoGenerateColumns = false;
            grvType.DataSource = list;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grvType.SelectedRows.Count > 0)
                {
                    int selectedIndex = grvType.SelectedRows[0].Index;

                    // gets the RowID from the first column in the grid
                    var typeCode = grvType[0, selectedIndex].Value.ToString();

                    tblType type = TypeFactory.FindByCode(typeCode);
                    if (type == null)
                    {
                        MessageBox.Show("Loại hình này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    FrmAddType frmAddType = new FrmAddType(typeCode, 1, _userInfo, this);
                    frmAddType.MdiParent = this.MdiParent;
                    frmAddType.Show();
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
                if (this.grvType.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Bạn thự sự muốn xóa loại hình đã chọn?", "Cảnh báo!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        int selectedIndex = grvType.SelectedRows[0].Index;

                        // gets the RowID from the first column in the grid
                        var typeCode = grvType[0, selectedIndex].Value.ToString();

                        tblType type = TypeFactory.FindByCode(typeCode);
                        if (type == null)
                        {
                            MessageBox.Show("Loại hình này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        List<tblDeclaration> listDeclaration = DeclarationFactory.getByType(typeCode);
                        if (null != listDeclaration && listDeclaration.Count > 0)
                        {
                            MessageBox.Show("Tồn tại tờ khai thuộc loại hình này, bạn không thể xóa được. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (TypeFactory.DeleteType(typeCode) > 0)
                        {

                            MessageBox.Show("Xóa loại hình thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            search();
                        }
                        else
                        {
                            MessageBox.Show("Xóa loại hình không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            search();
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
    }
}

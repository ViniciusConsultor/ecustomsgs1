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
    public partial class FrmListCustoms : Form
    {
        private static ILog logger = LogManager.GetLogger("ECustoms.FrmListCustoms");
        private UserInfo _userInfo;

        public FrmListCustoms()
        {
            InitializeComponent();
        }

        public FrmListCustoms(UserInfo userInfo)
        {
            _userInfo = userInfo;
            InitializeComponent();
           
        }

        private void FrmListCustoms_Load(object sender, EventArgs e)
        {
            this.Text = "Danh sach don vi hai quan" + ConstantInfo.MESSAGE_TITLE;
            init();
        }

        public void init()
        {
            List<tblCustom> list = CustomsFacory.getAll();
            grvCustoms.AutoGenerateColumns = false;
            grvCustoms.DataSource = list;
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
            List<tblCustom> list = CustomsFacory.getAll();
            if (txtCustomsCode.Text.Trim().Length > 0)
            {
                list = list.Where(g => g.CustomsCode.Contains(txtCustomsCode.Text.Trim())).ToList();
            }
            if (txtCustomsName.Text.Trim().Length > 0)
            {
                list = list.Where(g => g.CustomsName.Contains(txtCustomsName.Text.Trim())).ToList();
            }

            grvCustoms.AutoGenerateColumns = false;
            grvCustoms.DataSource = list;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grvCustoms.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Bạn thự sự muốn xóa đơn vị hải quan đã chọn?", "Cảnh báo!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        int selectedIndex = grvCustoms.SelectedRows[0].Index;

                        // gets the RowID from the first column in the grid
                        var customsCode = grvCustoms[0, selectedIndex].Value.ToString();

                        tblCustom customs = CustomsFacory.FindByCode(customsCode);
                        if (customs == null)
                        {
                            MessageBox.Show("Đơn vị hải quan này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (CustomsFacory.Delete(customsCode) > 0)
                        {
                            search();
                            MessageBox.Show("Xóa đơn vị hải quan thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            search();
                            MessageBox.Show("Xóa đơn vị hải quan không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grvCustoms.SelectedRows.Count > 0)
                {
                    int selectedIndex = grvCustoms.SelectedRows[0].Index;

                    // gets the RowID from the first column in the grid
                    var customsCode = grvCustoms[0, selectedIndex].Value.ToString();

                    tblCustom customs = CustomsFacory.FindByCode(customsCode);
                    if (customs == null)
                    {
                        MessageBox.Show("Đơn vị hải quan này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    FrmAddCustoms frmAddCustoms = new FrmAddCustoms(customsCode, 1, _userInfo, this);
                    frmAddCustoms.MdiParent = this.MdiParent;
                    frmAddCustoms.Show();
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

        private void grvCustoms_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.grvCustoms.SelectedRows.Count > 0)
                {
                    int selectedIndex = grvCustoms.SelectedRows[0].Index;

                    // gets the RowID from the first column in the grid
                    var customsCode = grvCustoms[0, selectedIndex].Value.ToString();

                    tblCustom customs = CustomsFacory.FindByCode(customsCode);
                    if (customs == null)
                    {
                        MessageBox.Show("Đơn vị hải quan này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    FrmAddCustoms frmAddCustoms = new FrmAddCustoms(customsCode, 1, _userInfo, this);
                    frmAddCustoms.MdiParent = this.MdiParent;
                    frmAddCustoms.Show();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddCustoms frmAdd = new FrmAddCustoms(null, 0, _userInfo, this);
            frmAdd.MdiParent = this.MdiParent;
            frmAdd.Show();
        }
    }
}

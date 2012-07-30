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
    public partial class FrmListGate : SubFormBase
    {
        private static ILog logger = LogManager.GetLogger("ECustoms.FrmListGate");
        private UserInfo _userInfo;
        public FrmListGate()
        {
            InitializeComponent();
        }

        public FrmListGate(UserInfo userInfo)
        {
            InitializeComponent();
            _userInfo = userInfo;

            dataSet2.tblGateType.Rows.Add(-1, "Tất cả");
            dataSet2.tblGateType.Rows.Add(0, "CK xuất");
            dataSet2.tblGateType.Rows.Add(1, "CK nhập");
            cbGateType.DataSource = dataSet2.tblGateType;
        }

        private void FrmListGate_Load(object sender, EventArgs e)
        {
            this.Text = "Danh sach cua khau" + ConstantInfo.MESSAGE_TITLE;
            init();
        }

        public void init()
        {
            List<tblGate> listGate = GateFactory.getAll();
            grvGate.AutoGenerateColumns = false;
            grvGate.DataSource = listGate;
        }

        public void search()
        {
            List<tblGate> list = GateFactory.getAll();
            if (txtGateCode.Text.Trim().Length > 0)
            {
                list = list.Where(g => g.GateCode.Contains(txtGateCode.Text.Trim())).ToList();
            }

            if (txtGateName.Text.Trim().Length > 0)
            {
                list = list.Where(g => g.GateName.Contains(txtGateName.Text.Trim())).ToList();
            }
            if (cbGateType.SelectedValue.ToString() != "-1")
            {
                int gateType = int.Parse(cbGateType.SelectedValue.ToString());
                list = list.Where(g => g.GateType.Equals(gateType)).ToList();
            }
            grvGate.AutoGenerateColumns = false;
            grvGate.DataSource = list;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddGate frmAddGate = new FrmAddGate(null, 0, _userInfo, this);
            frmAddGate.MdiParent = this.MdiParent;
            frmAddGate.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grvGate.SelectedRows.Count > 0)
                {
                    int selectedIndex = grvGate.SelectedRows[0].Index;

                    // gets the RowID from the first column in the grid
                    var gateCode = grvGate[0, selectedIndex].Value.ToString();

                    tblGate gate = GateFactory.FindByCode(gateCode);
                    if (gate == null)
                    {
                        MessageBox.Show("Cửa khẩu này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    FrmAddGate frmAddGate = new FrmAddGate(gateCode, 1, _userInfo, this);
                    frmAddGate.MdiParent = this.MdiParent;
                    frmAddGate.Show();
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

        private void grvGate_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.grvGate.SelectedRows.Count > 0)
                {
                    int selectedIndex = grvGate.SelectedRows[0].Index;

                    // gets the RowID from the first column in the grid
                    var gateCode = grvGate[0, selectedIndex].Value.ToString();

                    tblGate gate = GateFactory.FindByCode(gateCode);
                    if (gate == null)
                    {
                        MessageBox.Show("Cửa khẩu này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    FrmAddGate frmAddGate = new FrmAddGate(gateCode, 1, _userInfo, this);
                    frmAddGate.MdiParent = this.MdiParent;
                    frmAddGate.Show();
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
                if (this.grvGate.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Bạn thự sự muốn xóa cửa khẩu đã chọn?", "Cảnh báo!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        int selectedIndex = grvGate.SelectedRows[0].Index;

                        // gets the RowID from the first column in the grid
                        var gateCode = grvGate[0, selectedIndex].Value.ToString();

                        tblGate gate = GateFactory.FindByCode(gateCode);
                        if (gate == null)
                        {
                            MessageBox.Show("Cửa khẩu này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (GateFactory.Delete(gateCode) > 0)
                        {

                            MessageBox.Show("Xóa loại cửa khẩu công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            search();
                        }
                        else
                        {
                            MessageBox.Show("Xóa loại cửa khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

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
    public partial class frmDeclarationFilesManagement : Form
    {
        private static log4net.ILog logger = LogManager.GetLogger("Ecustoms.frmDeclarationFilesManagement");
        UserInfo _userInfo;

        public frmDeclarationFilesManagement()
        {
            InitializeComponent();
        }

        public frmDeclarationFilesManagement(UserInfo userInfo)
        {
            _userInfo = userInfo;
            InitializeComponent();
        }

        private void frmDeclarationFilesManagement_Load(object sender, EventArgs e)
        {
            dataSet2.tblLoanStatus.Rows.Add(false, "Chưa cho mượn");
            dataSet2.tblLoanStatus.Rows.Add(true, "Đã cho mượn");
            this.Text = "Quan ly ho so luu tru" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            init();

        }
        private void init()
        {
            search();
        }
        public void search()
        {
            string number = txtNumber.Text.Trim();
            string type = txtType.Text.Trim();
            string registeredYear = txtRegisteredYear.Text.Trim();
            string customsCode = cbxCustomsCode.Text.Trim();

            DateTime DateReturnFrom = new DateTime(dateTimePickerReturn.Value.Year, dateTimePickerReturn.Value.Month, dateTimePickerReturn.Value.Day, 0, 0, 0);
            DateTime DateReturnTo = new DateTime(dateTimePickerReturn.Value.Year, dateTimePickerReturn.Value.Month, dateTimePickerReturn.Value.Day, 23, 59, 59);

            DateTime DateHandoverFrom = new DateTime(dateTimePickerHandover.Value.Year, dateTimePickerHandover.Value.Month, dateTimePickerHandover.Value.Day, 0, 0, 0);
            DateTime DateHandoverTo = new DateTime(dateTimePickerHandover.Value.Year, dateTimePickerHandover.Value.Month, dateTimePickerHandover.Value.Day, 23, 59, 59);

            string companyName = txtCompanyName.Text.Trim();

            List<ViewDeclarationManagement> listDeclaration = new List<ViewDeclarationManagement>();
            listDeclaration = DeclarationManagementFactory.GetDeclarationSaved();

            //search
            if (string.IsNullOrEmpty(number) == false)
            {
                listDeclaration = listDeclaration.Where(g => g.Number.ToString().Contains(number)).ToList();
            }

            if (string.IsNullOrEmpty(type) == false)
            {
                listDeclaration = listDeclaration.Where(g => g.Type != null && g.Type.ToString().Contains(type)).ToList();
            }

            if (string.IsNullOrEmpty(registeredYear) == false)
            {
                listDeclaration = listDeclaration.Where(g => g.CreatedDate.GetValueOrDefault().Year.ToString() == registeredYear).ToList();
            }

            if (string.IsNullOrEmpty(customsCode) == false)
            {
                listDeclaration = listDeclaration.Where(g => g.CustomsCode != null && g.CustomsCode.ToString().Contains(customsCode)).ToList();
            }
            if (dateTimePickerReturn.Checked == true)
            {
                listDeclaration = listDeclaration.Where(g => g.DateReturn != null && g.DateReturn >= DateReturnFrom && g.DateReturn <= DateReturnTo).ToList();
            }

            if (dateTimePickerHandover.Checked == true)
            {
                listDeclaration = listDeclaration.Where(g => g.DateHandover != null && g.DateHandover >= DateHandoverFrom && g.DateHandover <= DateHandoverTo).ToList();
            }

            if (string.IsNullOrEmpty(companyName) == false)
            {
                listDeclaration = listDeclaration.Where(g => g.CompanyName != null && g.CompanyName.ToString().Contains(companyName)).ToList();
            }

            grvDeclarationList.AutoGenerateColumns = false;
            grvDeclarationList.DataSource = listDeclaration;

            checkLoanStatus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvDeclarationList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.grvDeclarationList.SelectedRows.Count > 0)
                {
                    int selectedIndex = grvDeclarationList.SelectedRows[0].Index;

                    // gets the RowID from the first column in the grid
                    long ID =  long.Parse(grvDeclarationList[0, selectedIndex].Value.ToString());

                    tblDeclaration declaration = DeclarationFactory.GetByID(ID);
                    if (declaration == null)
                    {
                        MessageBox.Show("Tờ khai này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    frmUpdateDeclarationFiles frm = new frmUpdateDeclarationFiles(_userInfo, this, ID);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grvDeclarationList.SelectedRows.Count > 0)
                {
                    int selectedIndex = grvDeclarationList.SelectedRows[0].Index;

                    // gets the RowID from the first column in the grid
                    long ID = long.Parse(grvDeclarationList[0, selectedIndex].Value.ToString());

                    tblDeclaration declaration = DeclarationFactory.GetByID(ID);
                    if (declaration == null)
                    {
                        MessageBox.Show("Tờ khai này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    frmUpdateDeclarationFiles frm = new frmUpdateDeclarationFiles(_userInfo, this, ID);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
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

        private void grvDeclarationList_SelectionChanged(object sender, EventArgs e)
        {
            checkLoanStatus();
        }

        private void checkLoanStatus()
        {
            try
            {
                if (this.grvDeclarationList.SelectedRows.Count > 0)
                {
                    int selectedIndex = grvDeclarationList.SelectedRows[0].Index;

                    // gets the RowID from the first column in the grid
                    long ID = long.Parse(grvDeclarationList[0, selectedIndex].Value.ToString());

                    tblDeclaration declaration = DeclarationFactory.GetByID(ID);
                    if (declaration != null && declaration.LoanStatus == false)
                    {
                        btnGetFiles.Enabled = true;
                        btnReturnFiles.Enabled = false;
                    }
                    if (declaration != null && declaration.LoanStatus == true)
                    {
                        btnGetFiles.Enabled = false;
                        btnReturnFiles.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void btnGetFiles_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grvDeclarationList.SelectedRows.Count > 0)
                {
                    int selectedIndex = grvDeclarationList.SelectedRows[0].Index;

                    // gets the RowID from the first column in the grid
                    long declarationID = long.Parse(grvDeclarationList[0, selectedIndex].Value.ToString());

                    tblDeclaration declaration = DeclarationFactory.GetByID(declarationID);
                    if (declaration == null)
                    {
                        MessageBox.Show("Tờ khai này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (declaration != null && declaration.LoanStatus == true)
                    {
                        MessageBox.Show("Hồ sơ của tờ khai này đã được cho mượn rồi. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    FrmDeclarationFilesGetLoan frm = new FrmDeclarationFilesGetLoan(_userInfo, this, declarationID, declaration);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
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

        private void btnReturnFiles_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grvDeclarationList.SelectedRows.Count > 0)
                {
                    int selectedIndex = grvDeclarationList.SelectedRows[0].Index;

                    // gets the RowID from the first column in the grid
                    long declarationID = long.Parse(grvDeclarationList[0, selectedIndex].Value.ToString());

                    tblDeclaration declaration = DeclarationFactory.GetByID(declarationID);
                    if (declaration == null)
                    {
                        MessageBox.Show("Tờ khai này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (declaration != null && declaration.LoanStatus == false)
                    {
                        MessageBox.Show("Hồ sơ của tờ khai này đã được trả rồi. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    frmDeclarationFilesReturn frm = new frmDeclarationFilesReturn(_userInfo, this, declarationID, declaration);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
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

        private void btnViewLoanStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grvDeclarationList.SelectedRows.Count > 0)
                {
                    int selectedIndex = grvDeclarationList.SelectedRows[0].Index;

                    // gets the RowID from the first column in the grid
                    long declarationID = long.Parse(grvDeclarationList[0, selectedIndex].Value.ToString());

                    tblDeclaration declaration = DeclarationFactory.GetByID(declarationID);
                    if (declaration == null)
                    {
                        MessageBox.Show("Tờ khai này không còn tồn tại trong Cơ Sở Dữ Liệu. Bạn hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    frmDeclarationLoanDetail frm = new frmDeclarationLoanDetail( declarationID, declaration);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
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

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
    public partial class FrmDeclarationFilesGetLoan : Form
    {
        private static log4net.ILog logger = LogManager.GetLogger("Ecustoms.FrmDeclarationFilesGetLoan");
        UserInfo _userInfo;
        frmDeclarationFilesManagement _frmParent;
        long _declarationID;
        tblDeclaration _declration;

        public FrmDeclarationFilesGetLoan()
        {
            InitializeComponent();
        }

        public FrmDeclarationFilesGetLoan(UserInfo userInfo, frmDeclarationFilesManagement frmParent, long declarationID, tblDeclaration declration)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _frmParent = frmParent;
            _declarationID = declarationID;
            _declration = declration;
        }

        private void FrmDeclarationFilesGetLoan_Load(object sender, EventArgs e)
        {
            this.Text = "Cho muon ho so" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;

            lblNumber.Text = _declration.Number.ToString();
            lblPageNumber.Text = _declration.PageNumbers.ToString();
            txtBorrower.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtBorrower.Text.Trim().Length == 0)
            {
                MessageBox.Show("Tên người mượn không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tblDeclaration declaration = DeclarationFactory.GetByID(_declarationID);
            if (declaration == null)
            {
                MessageBox.Show("Tờ khai không còn tồn tại, xin kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (declaration != null && declaration.LoanStatus==true)
            {
                MessageBox.Show("Hồ sơ về tờ khai đã được cho mượn rồi, xin kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tblDeclarationLoan loan = new tblDeclarationLoan();
            loan.CreatedUserID = _userInfo.UserID;
            loan.ModifiedUserID = _userInfo.UserID;
            loan.LoanDate = pkLoanDate.Value;
            loan.LoanReason = txtLoanReason.Text.Trim();
            loan.GetLoanDescription = txtDescription.Text.Trim();
            loan.BorrowerName = txtBorrower.Text.Trim();
            loan.LenderUserID = _userInfo.UserID;
            loan.DeclarationID = declaration.DeclarationID;
            int updateLoan = 0;
            try
            {

                declaration.LoanStatus = true;
                declaration.ModifiedByID = _userInfo.UserID;
                int updateDeclaration = DeclarationFactory.Update(declaration);
                if (updateDeclaration > 0)
                {
                    updateLoan = DeclarationLoanFactory.Insert(loan);
                }

                if (updateLoan > 0)
                {
                    MessageBox.Show("Thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (_frmParent != null)
                    {
                        _frmParent.search();
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm mới không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm mới không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

                
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

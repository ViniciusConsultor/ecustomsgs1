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
    public partial class frmDeclarationFilesReturn : Form
    {
        private static log4net.ILog logger = LogManager.GetLogger("Ecustoms.frmDeclarationFilesReturn");
        UserInfo _userInfo;
        frmDeclarationFilesManagement _frmParent;
        long _declarationID;
        tblDeclaration _declration;

        public frmDeclarationFilesReturn()
        {
            InitializeComponent();
        }

        public frmDeclarationFilesReturn(UserInfo userInfo, frmDeclarationFilesManagement frmParent, long declarationID, tblDeclaration declration)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _frmParent = frmParent;
            _declarationID = declarationID;
            _declration = declration;
        }


        private void frmDeclarationFilesReturn_Load(object sender, EventArgs e)
        {
            this.Text = "Tra ho so" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;

            lblNumber.Text = _declration.Number.ToString();
            lblPageNumber.Text = _declration.PageNumbers.ToString();
            txtReturnLoanDescription.Focus();

            tblDeclarationLoan loan = DeclarationLoanFactory.getLastLoanByDeclarationID(_declarationID);
            txtBorrower.Text = loan.BorrowerName;
            txtDescription.Text = loan.GetLoanDescription;
            txtLoanReason.Text = loan.LoanReason;
            pkLoanDate.Value = loan.LoanDate.GetValueOrDefault();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (pkReturnDate.Value < pkLoanDate.Value)
            {
                MessageBox.Show("Ngày trả hồ sơ không được nhỏ hơn ngày mượn hồ sơ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pkReturnDate.Focus();
                return;
            }

            tblDeclaration declaration = DeclarationFactory.GetByID(_declarationID);
            if (declaration == null)
            {
                MessageBox.Show("Tờ khai không còn tồn tại, xin kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (declaration != null && declaration.LoanStatus == false)
            {
                MessageBox.Show("Hồ sơ về tờ khai đã được trả rồi, xin kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int updateLoan = 0;
                declaration.LoanStatus = false;
                declaration.ModifiedByID = _userInfo.UserID;
                int updateDeclaration = DeclarationFactory.Update(declaration);

                if (updateDeclaration > 0)
                {
                    tblDeclarationLoan loan = DeclarationLoanFactory.getLastLoanByDeclarationID(_declarationID);
                    loan.ModifiedUserID = _userInfo.UserID;
                    loan.ReturnLoanDescription = txtReturnLoanDescription.Text.Trim();
                    loan.ReturnDate = pkReturnDate.Value;
                    updateLoan = DeclarationLoanFactory.Update(loan);
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
    }
}

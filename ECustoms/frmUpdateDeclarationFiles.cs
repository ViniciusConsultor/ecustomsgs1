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
    public partial class frmUpdateDeclarationFiles : Form
    {
        private static log4net.ILog logger = LogManager.GetLogger("Ecustoms.frmUpdateDeclarationFiles");
        UserInfo _userInfo;
        frmDeclarationFilesManagement _frmParent;
        long _declarationID;

        public frmUpdateDeclarationFiles()
        {
            InitializeComponent();
        }

        public frmUpdateDeclarationFiles(UserInfo userInfo, frmDeclarationFilesManagement frmParent, long declarationID)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _frmParent = frmParent;
            _declarationID = declarationID;
        }

        private void frmUpdateDeclarationFiles_Load(object sender, EventArgs e)
        {
            init();
            this.Text = "Cap nhat thong tin ho so" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
        }

        private void init()
        {
            tblDeclaration declaration = DeclarationFactory.GetByID(_declarationID);
            if (declaration != null)
            {
                lblNumber.Text = declaration.Number.ToString();
                txtPageNumber.Text = declaration.PageNumbers.ToString();
                txtFilesLocation.Text = declaration.FilesLocation;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int pageNumber=0;
            try{
                 pageNumber= Int32.Parse(txtPageNumber.Text.Trim());
            }
            catch(Exception ex)
            {
                MessageBox.Show("Số lượng (tờ) trong hồ sơ không hợp lệ, hãy nhập một số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (pageNumber <= 0)
            {
                MessageBox.Show("Số lượng (tờ) trong hồ sơ không hợp lệ, hãy nhập một số lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tblDeclaration declaration = DeclarationFactory.GetByID(_declarationID);
            if (declaration == null)
            {
                MessageBox.Show("Tờ khai không còn tồn tại, hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                declaration.ModifiedByID = _userInfo.UserID;
                declaration.PageNumbers = pageNumber;
                declaration.FilesLocation = txtFilesLocation.Text.Trim();
                int re = DeclarationFactory.Update(declaration);
                if (re > 0)
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (_frmParent != null)
                    {
                        _frmParent.search();
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }
    }
}

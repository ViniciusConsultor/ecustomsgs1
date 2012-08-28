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
    public partial class frmPageNumber : Form
    {
        private static log4net.ILog logger = LogManager.GetLogger("Ecustoms.frmPageNumber");
        tblDeclaration declaration;
        bool _isSecondHandover;
        UserInfo _userInfo;

        public frmPageNumber(UserInfo userInfo, long declarationId, bool isSecondHandover = false)
        {
            declaration = DeclarationFactory.GetByID(declarationId);
            _isSecondHandover = isSecondHandover;
            _userInfo = userInfo;
            InitializeComponent();
            if (_isSecondHandover)
            {
                txtPageNumber.ReadOnly = _isSecondHandover;
                txtPageNumber.Text = declaration.PageNumbers.Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_isSecondHandover) //ban giao tu nhan vien len phuc tap
                {
                    declaration.PageNumbers = Int32.Parse(txtPageNumber.Text.Trim());
                    declaration.DateHandover = dateTimePickerHandover.Value;
                    declaration.PersonReceive = txtRecipient.Text.Trim();
                    declaration.PersonHandoverID = _userInfo.UserID;
                    DeclarationFactory.Update(declaration);
                    MessageBox.Show("Hồ sơ đã được bàn giao cho phúc tập!");
                }
                else
                {
                    declaration.DateHandoverSecond = dateTimePickerHandover.Value;
                    declaration.PersonReceiveSecond = txtRecipient.Text.Trim();
                    declaration.PersonHandoverSecondID = _userInfo.UserID;
                    DeclarationFactory.Update(declaration);
                    MessageBox.Show("Hồ sơ đã được bàn giao cho lưu trữ!");
                }
                this.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

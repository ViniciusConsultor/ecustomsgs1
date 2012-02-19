using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using ECustoms.BOL;
using ECustoms.Utilities;
using Microsoft.Office.Interop.Excel;
using Point = System.Drawing.Point;
using log4net;
using ECustoms.DAL;
using System.Configuration;

namespace ECustoms
{
    public partial class frmDeclerationOptionInfo : Form
    {
        private readonly ILog logger = LogManager.GetLogger("Ecustoms.frmDeclerationOptionInfo");

        private UserInfo _userInfo;
        private readonly Form _mainForm;
        private List<ViewAllDeclaration> _listDeclarationinfo;
        private Common.DeclerationOptionType _declerationOptionType;
        public frmDeclerationOptionInfo()
        {
            InitializeComponent();
        }

        public frmDeclerationOptionInfo(UserInfo userInfo, Form mainForm, Common.DeclerationOptionType declerationOptionType)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _mainForm = mainForm;
            _declerationOptionType = declerationOptionType;
        }

        private void frmDeclerationOptionInfo_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Danh sách tờ khai" + ConstantInfo.MESSAGE_TITLE;
                switch (_declerationOptionType)
                {
                  case Common.DeclerationOptionType.XKCK:
                    lblHeader.Text = "Quản lý hàng xuất khẩu chuyển cửa khẩu";
                    break;
                  case Common.DeclerationOptionType.NKCK:
                    lblHeader.Text = "Quản lý hàng nhập khẩu chuyển cửa khẩu";
                    break;
                  case Common.DeclerationOptionType.TNTX:
                    lblHeader.Text = "Quản lý hàng tạm nhập tái xuất";
                    break;
                  default:
                    break;
                }
                // Show form to the center
                this.Location = new Point((_mainForm.Width - this.Width) / 2, (_mainForm.Height - this.Height) / 2);

                this._listDeclarationinfo = DeclarationFactory.SelectAllFromView();
                //BindData();
                txtDeclaraceNumber.Focus();
                //InitialPermission();

                //check user permission
                btnUpdate.Enabled = _userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_TO_KHAI);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private delegate void MonitorContacIdCallback();

        /// <summary>
        /// Bind data by search codition
        /// This methold will be called after refresh time ( from web.config)
        /// </summary>
        public void BindData()
        {
            try
            {
                // Get declaration from database
                _listDeclarationinfo = DeclarationFactory.SelectAllFromView();
                var declarationNumber = txtDeclaraceNumber.Text.Trim();
                var companyName = txtCompanyName.Text.Trim();
                List<ViewAllDeclaration> result = null;

                result = _listDeclarationinfo;
                //filter by declarationNumber
                if (!string.IsNullOrEmpty(txtDeclaraceNumber.Text))
                { //has nunber, not has copany name
                    result = result.Where(d => d.Number.ToString().Contains(declarationNumber)).ToList();
                }

                //filter by CompanyName
                if (string.IsNullOrEmpty(txtCompanyName.Text) == false)
                { // has company name, has not number
                    result = result.Where(d => (d.CompanyName != null) && (d.CompanyName.Contains(companyName))).OrderByDescending(p => p.ModifiedDate).ToList();
                }

                // Filter by Type
                FilterByType(ref result);
                result = result.OrderByDescending(p => p.ModifiedDate).ToList();
                grvDecleration.AutoGenerateColumns = false;
                grvDecleration.DataSource = result;

                for (int i = 0; i < grvDecleration.Rows.Count; i++)
                {
                    var declarationType = grvDecleration.Rows[i].Cells["DeclarationType"].Value;
                    if (declarationType.Equals((short)Common.DeclerationType.Export)) // tờ khai xuất
                    {
                        System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#ffc0c0");
                        grvDecleration.Rows[i].DefaultCellStyle.BackColor = col;
                    }
                    else
                    {
                        System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#c1ffc0");
                        grvDecleration.Rows[i].DefaultCellStyle.BackColor = col;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        #region Private methods

        /// <summary>
        /// Filter data by Decleration type
        /// </summary>
        /// <param name="declarations"></param>
        private void FilterByType(ref List<ViewAllDeclaration> declarations)
        {
            switch (_declerationOptionType)
            {
                case Common.DeclerationOptionType.XKCK:
                    declarations = declarations.Where(g => g.DeclarationType == (short)Common.DeclerationType.Export && (g.TypeOption == (short) Common.DeclerationOptionType.XKCK)).ToList();
                    break;
                case Common.DeclerationOptionType.NKCK:
                    declarations = declarations.Where(g => g.DeclarationType == (short)Common.DeclerationType.Import && (g.TypeOption == (short) Common.DeclerationOptionType.NKCK)).ToList();
                    break;
              case Common.DeclerationOptionType.TNTX:
                    declarations = declarations.Where(g => g.DeclarationType == (short)Common.DeclerationType.Import && g.TypeOption == (short)Common.DeclerationOptionType.TNTX).ToList();
                    break;
            }
        }

        #endregion

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvDecleration.SelectedRows.Count != 0)
                {
                    var declarationType = grvDecleration.SelectedRows[0].Cells["DeclarationType"].Value;
                    if (declarationType.Equals((short)Common.DeclerationType.Export)) // tờ khai xuất
                    {
                        var frmExport = new FrmDecleExport(_mainForm, _userInfo, 1, Convert.ToInt32(grvDecleration.SelectedRows[0].Cells[0].Value), Common.DeclerationType.Export);
                        frmExport.Show(this);
                    }
                    else
                    {
                        var frmExport = new FrmDecleExport(_mainForm, _userInfo, 1, Convert.ToInt32(grvDecleration.SelectedRows[0].Cells[0].Value), Common.DeclerationType.Import);
                        frmExport.Show(this);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần chọn 1 tờ khai cần cập nhật.");
                }
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
        
        private void grvDecleration_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                logger.Info("grvDecleration_RowLeave");
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

        private void grvDecleration_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_userInfo.UserPermission.Contains(ConstantInfo.PERMISSON_CAP_NHAT_TO_KHAI))
            {
                try
                {
                    if (e.RowIndex >= 0 && grvDecleration.SelectedRows.Count == 1) // Only select one row
                    {
                        //var declarationType = grvDecleration.SelectedRows[0].Cells["DeclarationType"].Value;
                        //if (declarationType.Equals((short)Common.DeclerationType.Export)) // tờ khai xuất
                        //{
                        //    var frmExport = new FrmDecleExportOption(_mainForm, _userInfo, Convert.ToInt64(grvDecleration.SelectedRows[0].Cells[0].Value), Common.DeclerationOptionType.NKCK);
                        //    frmExport.Show(this);
                        //}
                        //else
                        //{
                        //  var frmExport = new FrmDecleExportOption(_mainForm, _userInfo, Convert.ToInt64(grvDecleration.SelectedRows[0].Cells[0].Value), Common.DeclerationOptionType.NKCK);
                        //    frmExport.Show(this);
                        //}

                        var frmExport = new FrmDecleExportOption(_mainForm, _userInfo, Convert.ToInt64(grvDecleration.SelectedRows[0].Cells[0].Value), _declerationOptionType);
                        frmExport.Show(this);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex.ToString());
                    if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
                }
            }
        }

        private void grvDecleration_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                logger.Info("grvDecleration_RowLeave");
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }

    }
}

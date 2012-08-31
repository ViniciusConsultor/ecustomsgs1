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
    public partial class frmDeclarationLoanDetail : Form
    {
        private long _declarationID;
        private tblDeclaration _declaration;

        public frmDeclarationLoanDetail()
        {
            InitializeComponent();
        }

        public frmDeclarationLoanDetail(long declarationID, tblDeclaration declaration)
        {
            InitializeComponent();
            _declarationID = declarationID;
            _declaration = declaration;

        }

        private void frmDeclarationLoanDetail_Load(object sender, EventArgs e)
        {
            this.Text = "Lich su muon tra ho so" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            lblNumber.Text = _declaration.Number.ToString();
            search();

        }

        private void search()
        {
             DateTime loandDateFrom = new DateTime(pkLoanDateFrom.Value.Year, pkLoanDateFrom.Value.Month, pkLoanDateFrom.Value.Day, 0, 0, 0);
            DateTime loandDateTo = new DateTime(pkLoanDateTo.Value.Year, pkLoanDateTo.Value.Month, pkLoanDateTo.Value.Day, 23, 59, 59);

            DateTime returnDateFrom = new DateTime(pkReturnDateFrom.Value.Year, pkReturnDateFrom.Value.Month, pkReturnDateFrom.Value.Day, 0, 0, 0);
            DateTime returnDateTo = new DateTime(pkReturnDateTo.Value.Year, pkReturnDateTo.Value.Month, pkReturnDateTo.Value.Day, 23, 59, 59);


            List<viewDeclarationLoan> list = DeclarationLoanFactory.getViewByDeclarationID(_declarationID);
            if (pkLoanDateFrom.Checked)
            {
                list = list.Where(g => g.LoanDate != null && g.LoanDate >= loandDateFrom).OrderByDescending(g => g.ModifiedDate).ToList();
            }

            if (pkLoanDateTo.Checked)
            {
                list = list.Where(g => g.LoanDate != null && g.LoanDate <= loandDateTo).OrderByDescending(g => g.ModifiedDate).ToList();
            }

            if (pkReturnDateFrom.Checked)
            {
                list = list.Where(g => g.ReturnDate != null && g.ReturnDate >= returnDateFrom).OrderByDescending(g => g.ModifiedDate).ToList();
            }

            if (pkReturnDateTo.Checked)
            {
                list = list.Where(g => g.ReturnDate != null && g.ReturnDate <= returnDateTo).OrderByDescending(g => g.ModifiedDate).ToList();
            }

            grvList.DataSource = list;
            grvList.AutoGenerateColumns = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

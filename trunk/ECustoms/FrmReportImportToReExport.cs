using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECustoms.Utilities;
using ECustoms.Utilities.Enums;
using log4net;
using System.Collections.Generic;
using ECustoms.BOL;
using ECustoms.DAL;

namespace ECustoms
{
    public partial class FrmReportImportToReExport : Form
    {
        private static log4net.ILog logger = LogManager.GetLogger("Ecustoms.FrmReportImportToReExport");
        private Form _mainForm;
        private UserInfo _userInfo;
        private int _type;

        public FrmReportImportToReExport()
        {
            InitializeComponent();
        }

        public FrmReportImportToReExport(Form mainFrom, UserInfo userInfo, int type)
        {
            _userInfo = userInfo;
            _type = type;
            InitializeComponent();
            _mainForm = mainFrom;

        }

        private void FrmReportImportToReExport_Load(object sender, EventArgs e)
        {
            this.Text = "Bao cao xuat/nhap chuyen cua khau" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;

            //init cbCustoms
            List<tblCustom> listCustom = CustomsFacory.getAll();
            foreach (tblCustom cb in listCustom)
            {
                cb.CustomsName = cb.CustomsCode + " - " + cb.CustomsName;
            }
            listCustom = listCustom.OrderBy(g => g.CustomsCode).ToList();
            tblCustom allObj = new tblCustom();
            allObj.CustomsCode = "0";
            allObj.CustomsName = "Tất cả";
            listCustom.Insert(0, allObj);
            cbCustoms.DataSource = listCustom;
            cbCustoms.ValueMember = "CustomsCode";
            cbCustoms.DisplayMember = "CustomsName";

            //init cbCompany
            List<tblCompany> listCompany = CompanyFactory.getAllCompany();
            foreach (tblCompany cp in listCompany)
            {
                cp.CompanyName = cp.CompanyCode + " - " + cp.CompanyName;
            }
            listCompany = listCompany.OrderBy(g => g.CompanyCode).ToList();
            tblCompany allCompanyObj = new tblCompany();
            allCompanyObj.CompanyCode = "0";
            allCompanyObj.CompanyName = "Tất cả";
            listCompany.Insert(0, allCompanyObj);
            cbCompany.DataSource = listCompany;
            cbCompany.ValueMember = "CompanyCode";
            cbCompany.DisplayMember = "CompanyName";
        }
    }
}

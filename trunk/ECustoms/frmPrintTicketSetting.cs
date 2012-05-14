using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml;
using log4net;
using ECustoms.Utilities;

namespace ECustoms
{
  public partial class frmPrintTicketSetting : Form
  {
    private UserInfo _userInfo;
    private static ILog logger = LogManager.GetLogger("Ecustoms.frmPrintTicketSetting");

    public frmPrintTicketSetting(UserInfo userInfo)
    {
      InitializeComponent();
      _userInfo = userInfo;
    }

    private void frmPrintTicketSetting_Load(object sender, EventArgs e)
    {
      this.Text = "Thiet lap cau hinh in ticket" + ConstantInfo.MESSAGE_TITLE;
      this.Location = new Point((this.Owner.Width - this.Width) / 2, (this.Owner.Height - this.Height) / 2);
      InitData();
    }

    public void InitData()
    { 
      var filePath = Application.StartupPath + @"\conf\print_ticket.xml";
      PrintTicketSetting printSetting = ObjectToXml.GetTicketSetting(filePath);
      if(printSetting != null)
      {
        cbPrintImportHasGood.Checked = printSetting.PrintImportHasGood;
        cbPrintParking.Checked = printSetting.PrintParking;
        cbPrintExportPark.Checked = printSetting.PrintInputExportPark;
      }
      BindPrints();
    }

    private void BindPrints()
    {
      try
      {
        // Read list print from app.config
        var filePath = Application.StartupPath + @"\ListPrint.xml";
        // Return if the file is not existing
        if (!System.IO.File.Exists(filePath)) return;

        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(filePath);

        // bind data to the listbox
        foreach (XmlNode xmlNode in xmlDocument.ChildNodes[1].ChildNodes)
        {
          ListItem listItem = new ListItem();
          listItem.Text = xmlNode.Attributes["name"].Value;
          listItem.Value = xmlNode.Attributes["ip"].Value;
          listBoxPrint.Items.Add(listItem);
        }
      }
      catch (Exception)
      {
         //TODO: Need to handle 
        throw;
      }
      
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      PrintTicketSetting printSetting = new PrintTicketSetting();

      List<string> listPrinter = new List<string>();
      foreach (ListItem item in listBoxPrint.SelectedItems)
      {
        listPrinter.Add(item.Text);
      }

      printSetting.ListPrinter = listPrinter;
      printSetting.PrintImportHasGood = cbPrintImportHasGood.Checked;
      printSetting.PrintParking = cbPrintParking.Checked;
      printSetting.PrintInputExportPark = cbPrintExportPark.Checked;

      var filePath = Application.StartupPath + @"\conf\print_ticket.xml";
      ObjectToXml.ConvertObjectToXml(printSetting, filePath);
      MessageBox.Show("Cấu hình thành công. Bạn cần đăng nhập lại để cấu hình này có tác dụng");
    }
  }
}

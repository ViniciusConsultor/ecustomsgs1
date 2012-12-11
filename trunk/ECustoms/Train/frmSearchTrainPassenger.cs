using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECustoms.BOL;
using ECustoms.Utilities;
using ECustoms.Utilities.Enums;

namespace ECustoms.Train
{
    public partial class frmSearchTrainPassenger : Form
    {
        public frmSearchTrainPassenger()
        {
            InitializeComponent();
        }

        private void frmSearchTrainPassenger_Load(object sender, EventArgs e)
        {
            this.Text = "Quan ly Tau khach XNC" + ConstantInfo.MESSAGE_TITLE + GlobalInfo.CompanyName;
            Init();
        }

        private void Init()
        {
            //init data for Type
            var listType = new List<ComboBoxItem>();
            listType.Add(new ComboBoxItem(-1, "Tất cả"));
            listType.Add(new ComboBoxItem((short)TrainType.TypeExport, "Xuất cảnh"));
            listType.Add(new ComboBoxItem((short)TrainType.TypeImport, "Nhập cảnh"));

            ddlTypeName.Items.AddRange(listType.ToArray());
            ddlTypeName.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var listTrain = TrainFactory.SearchPassenger(txtNumberTrain.Text.Trim(),
                                                             (int) ((ComboBoxItem) ddlTypeName.SelectedItem).Value,
                                                             dtpDateXNC.Value);
                grdTrain.DataSource = listTrain;
            }
            catch (Exception ex)
            {
                if (GlobalInfo.IsDebug) MessageBox.Show(ex.ToString());
            }
        }
    }
}

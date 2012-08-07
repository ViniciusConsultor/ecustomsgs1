using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.RCM;
using System.Windows.Forms.ResourcesManager;

namespace ECustoms
{
    public partial class SubFormBase : Form
    {

        private RCMFormStyles _FormStyle = RCMFormStyles.VistaForm;
        [Description("Set or get RCM Style of form."), DefaultValue(RCMFormStyles.VistaForm), Category("FormatStyle")]
        public RCMFormStyles FormStyle
        {
            get { return _FormStyle; }
            set { _FormStyle = value; }
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                base.OnLoad(e);

                cRCM _cRCM = new cRCM(this.Handle);
                LoadRes.LoadFrameImages(_cRCM, (int)FormStyle);
                LoadRes.LoadControlImages(_cRCM, (int)FormStyle);
                this.Width = this.Width + 10;
                _cRCM.Start();
                this.Refresh();
            }
            catch (Exception ex)
            {
                //do nothing
            }
        }

        public SubFormBase()
        {
            InitializeComponent();
        }
    }
}

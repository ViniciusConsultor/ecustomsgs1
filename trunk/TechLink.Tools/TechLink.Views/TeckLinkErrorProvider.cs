using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;

namespace TechLink.Views
{
    public class TeckLinkErrorProvider : ErrorProvider //DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider
    {
        public TeckLinkErrorProvider()
        {

        }
        public TeckLinkErrorProvider(IContainer container): base(container)
        {

        }

        public TeckLinkErrorProvider(ContainerControl controlContainer)
            : base(controlContainer)
    {
        
    }

        public  bool ValidateControls()
        {
            
            var hasError = false;
            ValidateRequiredFields(this.ContainerControl,ref hasError);

            return !hasError;
        }

        private void ValidateRequiredFields(Control ctl, ref bool hasError)
        {
            //bool hasError = false;

            if (ctl.Controls.Count > 0)
            {
                foreach (var control in ctl.Controls)
                {
                    if (control is Control)
                    {
                        if ((control as Control).Tag != null && (control as Control).Tag.Equals("required"))
                        {
                            if (control is TextBox)
                            {
                                if ((control as TextBox).Text.Trim().Length == 0)
                                {
                                    this.Icon = Properties.Resources.bullet_error;
                                    this.SetIconAlignment(control as Control, ErrorIconAlignment.MiddleLeft);
                                    this.SetError(control as Control, "Trường cần phải nhập thông tin!");
                                    
                                    hasError = true;
                                }
                            }
                        }
                        else
                        {
                            ValidateRequiredFields(control as Control, ref hasError);
                        }
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ECustoms.Utilities
{
    public class TechlinkErrorProvider : ErrorProvider
    {
        public void ValidateRequiredFields(Control ctl, ref bool hasError)
        {
            //bool hasError = false;

            if (ctl.Controls.Count>0)
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

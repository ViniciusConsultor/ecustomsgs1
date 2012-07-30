using System.Linq;
using System.Windows.Forms;
using ECustoms.BOL;

namespace ECustoms
{
    public class Validation: ErrorProvider
    {
        private Form _owner;
        private string[] _listTagName;

        public Validation(Form owner)
        {
            _owner = owner;
            _listTagName = ValidateFactory.GetAllTag();
        }
        public bool Validate()
        {
            var hasError = false;
            _validate(_owner, ref hasError);
            return !hasError;
        }

        private void _validate(Control ctl, ref bool hasError)
        {
            if (ctl.Controls.Count <= 0) return;
            foreach (var control in ctl.Controls)
            {
                if (control is Control)
                {
                    if ((control as Control).Tag != null && _listTagName.Any((control as Control).Tag.Equals))
                    {
                        if (control is TextBox)
                        {
                            if ((control as TextBox).Text.Trim().Length == 0)
                            {
                                this.SetError(control as Control, "Trường cần phải nhập thông tin!");
                                (control as Control).BackColor = System.Drawing.Color.Yellow;
                                hasError = true;
                            }
                            else
                            {
                                this.SetError(control as Control, string.Empty);
                                (control as Control).BackColor = System.Drawing.Color.White;
                            }
                        }
                    }
                    else
                    {
                        _validate(control as Control, ref hasError);
                    }
                }
            }
        }
    }
}

using System.Linq;
using System.Windows.Forms;
using ECustoms.BOL;

namespace ECustoms
{
    public class Validation
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
            var isValid = true;
            foreach (Control c in _owner.Controls)
            {
                if (c is GroupBox)
                {
                    foreach (Control c1 in c.Controls)
                    {
                        if (!(c1 is TextBox) || c1.Tag == null) continue;
                        var tbxTag1 = c1.Tag.ToString();
                        if (!_listTagName.Any(tbxTag1.Equals)) continue;
                        if (string.IsNullOrEmpty(c1.Text))
                        {
                            c1.BackColor = System.Drawing.Color.Yellow;
                            isValid = false;
                        }
                        else
                            c1.BackColor = System.Drawing.Color.White;                    
                    }
                    continue;
                }
                if (!(c is TextBox) || c.Tag == null) continue;
                var tbxTag = c.Tag.ToString();
                if (!_listTagName.Any(tbxTag.Equals)) continue;
                if (string.IsNullOrEmpty(c.Text))
                {
                    c.BackColor = System.Drawing.Color.Yellow;
                    isValid = false;
                }
                else
                    c.BackColor = System.Drawing.Color.White;
            }
            return isValid;
        }
    }
}

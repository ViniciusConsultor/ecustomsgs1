using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ApplicationUtils.Utils;

namespace ApplicationUtils.MessageCenter
{
    public class ShowMessage
    {
        private static string _systemTitle = "TechLink";
#if PIS15
        private static string _systemTitle = "PIS 1.5";
        public static string Application_Title = "PIS Client 1.0 :: ";
#elif KC2011
        private static string _systemTitle = "Sông Lam 1.0";
        public static string Application_Title = "Sông Lam Client 1.0";
#endif
        public static void Show(string message)
        {
            ShowMessage.Show(message, MessageType.Ok);
        }

        public static string Show(string message, string messageType)
        {
            DialogResult result = DialogResult.Cancel;
            if (messageType == MessageType.OkCancel)
            {
                result = MessageBox.Show(message, _systemTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                return (result == DialogResult.OK ? MessageResult.ResultOk : MessageResult.ResultCancel);
            }
            else if (messageType == MessageType.YesNo)
            {
                result = MessageBox.Show(message, _systemTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return (result == DialogResult.Yes ? MessageResult.ResultYes : MessageResult.ResultNo);
            }
            else if (messageType == MessageType.YesNoCancel)
            {
                result = MessageBox.Show(message, _systemTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                return (result == DialogResult.Yes
                            ? MessageResult.ResultYes
                            : (result == DialogResult.No ? MessageResult.ResultNo : MessageResult.ResultCancel));
            }
            else if (messageType == MessageType.Ok)
            {
                result = MessageBox.Show(message, _systemTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return (result == DialogResult.OK ? MessageResult.ResultOk : MessageResult.ResultCancel);
            }
            return MessageResult.ResultNone;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationUtils.MessageCenter
{
    public class MessageResult
    {
        public const string ResultOk = "OK";
        public const string ResultCancel = "Cancel";
        public const string ResultYes = "Yes";
        public const string ResultNo = "No";
        public const string ResultNone = "None";
    }

    public class MessageType
    {
        public const string Ok = "OK_Message";
        public const string OkCancel = "OK_Cancel";
        public const string YesNo = "Yes_No";
				public const string YesNoCancel = "Yes_No_Cancel";
        public const string Yes = "Yes";
        public const string No = "No";
        public const string ApplyCancel = "Apply_Cancel";
    }
}

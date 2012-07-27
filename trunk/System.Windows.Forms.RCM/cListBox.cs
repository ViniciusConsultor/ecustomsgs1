namespace System.Windows.Forms.RCM
{
    #region Directives
    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Drawing;
    #endregion

    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class cListBox : IDisposable
    {
        #region Fields
        private IntPtr _hListboxWnd = IntPtr.Zero;
        private cInternalScrollBar _cInternalScroll;
        #endregion

        #region Constructor
        public cListBox(IntPtr handle, Bitmap hztrack, Bitmap hzarrow, Bitmap hzthumb, Bitmap vttrack, Bitmap vtarrow, Bitmap vtthumb, Bitmap fader)
        {
            if (handle == IntPtr.Zero)
                throw new Exception("The listview handle is invalid.");
            _hListboxWnd = handle;
            if (hztrack != null && hzarrow != null && hzthumb != null && vttrack != null && vtarrow != null && vtthumb != null)
                _cInternalScroll = new cInternalScrollBar(_hListboxWnd, hztrack, hzarrow, hzthumb, vttrack, vtarrow, vtthumb, fader);
            else
                throw new Exception("The listbox image(s) are invalid");
        }

        public void Dispose()
        {
            try
            {
                if (_cInternalScroll != null) _cInternalScroll.Dispose();
            }
            catch { }
        }
        #endregion
    }
}

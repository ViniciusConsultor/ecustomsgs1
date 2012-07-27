namespace System.Windows.Forms.RCM
{
    #region Directives
    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Drawing;
    #endregion

    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class cListView : IDisposable
    {
        #region Constants
        private const int LVM_FIRST = 0x1000;
        private const int LVM_GETHEADER = (LVM_FIRST + 31);
        #endregion

        #region API
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        #endregion

        #region Fields
        private IntPtr _hListviewWnd = IntPtr.Zero;
        private cHeader _cHeaderSkin;
        private cInternalScrollBar _cInternalScroll;
        #endregion

        #region Constructor
        public cListView(IntPtr handle, Bitmap header, Bitmap hztrack, Bitmap hzarrow, Bitmap hzthumb, Bitmap vttrack, Bitmap vtarrow, Bitmap vtthumb, Bitmap fader)
        {
            if (handle == IntPtr.Zero)
                throw new Exception("The listview handle is invalid.");
            _hListviewWnd = handle;

            if (headerWnd != IntPtr.Zero)
                _cHeaderSkin = new cHeader(headerWnd, header);

            if (hztrack != null && hzarrow != null && hzthumb != null && vttrack != null && vtarrow != null && vtthumb != null)
                _cInternalScroll = new cInternalScrollBar(_hListviewWnd, hztrack, hzarrow, hzthumb, vttrack, vtarrow, vtthumb, fader);
            else
                throw new Exception("The listview image(s) are invalid");
        }

        private IntPtr headerWnd
        {
            get { return (SendMessage(_hListviewWnd, LVM_GETHEADER, 0, 0)); }
        }
        #endregion

        #region Methods
        public void Dispose()
        {
            try
            {
                if (_cHeaderSkin != null) _cHeaderSkin.Dispose();
                if (_cInternalScroll != null) _cInternalScroll.Dispose();
            }
            catch { }
        }
        #endregion
    }
}

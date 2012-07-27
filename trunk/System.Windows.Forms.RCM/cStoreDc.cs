namespace System.Windows.Forms.RCM
{
    #region Directives
    using System;
    using System.Runtime.InteropServices;
    using System.Drawing;
    #endregion

    #region StoreDc
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class cStoreDc
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateDCA([MarshalAs(UnmanagedType.LPStr)]string lpszDriver, [MarshalAs(UnmanagedType.LPStr)]string lpszDevice, [MarshalAs(UnmanagedType.LPStr)]string lpszOutput, int lpInitData);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateDCW([MarshalAs(UnmanagedType.LPWStr)]string lpszDriver, [MarshalAs(UnmanagedType.LPWStr)]string lpszDevice, [MarshalAs(UnmanagedType.LPWStr)]string lpszOutput, int lpInitData);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, int lpInitData);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll", PreserveSig = true)]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteObject(IntPtr hObject);

        private int _iHeight = 0;
        private int _iWidth = 0;
        private IntPtr _pHdc = IntPtr.Zero;
        private IntPtr _pBmp = IntPtr.Zero;
        private IntPtr _pBmpOld = IntPtr.Zero;

        public IntPtr Hdc
        {
            get { return _pHdc; }
        }

        public IntPtr HBmp
        {
            get { return _pBmp; }
        }

        public int Height
        {
            get { return _iHeight; }
            set
            {
                if (_iHeight != value)
                {
                    _iHeight = value;
                    ImageCreate(_iWidth, _iHeight);
                }
            }
        }

        public int Width
        {
            get { return _iWidth; }
            set
            {
                if (_iWidth != value)
                {
                    _iWidth = value;
                    ImageCreate(_iWidth, _iHeight);
                }
            }
        }

        private void ImageCreate(int width, int height)
        {
            IntPtr pHdc = IntPtr.Zero;

            ImageDestroy();
            pHdc = CreateDCA("DISPLAY", "", "", 0);
            _pHdc = CreateCompatibleDC(pHdc);
            _pBmp = CreateCompatibleBitmap(pHdc, _iWidth, _iHeight);
            _pBmpOld = SelectObject(_pHdc, _pBmp);
            if (_pBmpOld == IntPtr.Zero)
            {
                ImageDestroy();
            }
            else
            {
                _iWidth = width;
                _iHeight = height;
            }
            DeleteDC(pHdc);
            pHdc = IntPtr.Zero;
        }

        private void ImageDestroy()
        {
            if (_pBmpOld != IntPtr.Zero)
            {
                SelectObject(_pHdc, _pBmpOld);
                _pBmpOld = IntPtr.Zero;
            }
            if (_pBmp != IntPtr.Zero)
            {
                DeleteObject(_pBmp);
                _pBmp = IntPtr.Zero;
            }
            if (_pHdc != IntPtr.Zero)
            {
                DeleteDC(_pHdc);
                _pHdc = IntPtr.Zero;
            }
        }

        public void Dispose()
        {
            ImageDestroy();
        }
    }
    #endregion
}

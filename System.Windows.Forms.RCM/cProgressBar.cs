namespace System.Windows.Forms.RCM
{
    #region Directives
    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Text;
    #endregion

    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class cProgressBar : NativeWindow, IDisposable
    {
        #region Constants
        // messages
        private const int WM_PAINT = 0xF;
        // alphablend
        private const byte AC_SRC_OVER = 0x00;
        private const byte AC_SRC_ALPHA = 0x01;
        // message handler
        private static IntPtr MSG_HANDLED = new IntPtr(1);
        #endregion

        #region Structs
        [StructLayout(LayoutKind.Sequential)]
        private struct PAINTSTRUCT
        {
            internal IntPtr hdc;
            internal int fErase;
            internal RECT rcPaint;
            internal int fRestore;
            internal int fIncUpdate;
            internal int Reserved1;
            internal int Reserved2;
            internal int Reserved3;
            internal int Reserved4;
            internal int Reserved5;
            internal int Reserved6;
            internal int Reserved7;
            internal int Reserved8;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            internal RECT(int X, int Y, int Width, int Height)
            {
                this.Left = X;
                this.Top = Y;
                this.Right = Width;
                this.Bottom = Height;
            }
            internal int Left;
            internal int Top;
            internal int Right;
            internal int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct BLENDFUNCTION
        {
            byte BlendOp;
            byte BlendFlags;
            byte SourceConstantAlpha;
            byte AlphaFormat;

            internal BLENDFUNCTION(byte op, byte flags, byte alpha, byte format)
            {
                BlendOp = op;
                BlendFlags = flags;
                SourceConstantAlpha = alpha;
                AlphaFormat = format;
            }
        }
        #endregion

        #region API
        [DllImport("user32.dll")]
        private static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool StretchBlt(IntPtr hDest, int X, int Y, int nWidth, int nHeight, IntPtr hdcSrc,
        int sX, int sY, int nWidthSrc, int nHeightSrc, int dwRop);

        [DllImport("gdi32.dll", EntryPoint = "GdiAlphaBlend")]
        private static extern bool AlphaBlend(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest,
        IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, BLENDFUNCTION blendFunction);

        [DllImport("user32.dll")]
        private static extern bool ValidateRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll")]
        private extern static int OffsetRect(ref RECT lpRect, int x, int y);

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hWnd, String pszSubAppName, String pszSubIdList);

        [DllImport("uxtheme.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private extern static bool IsAppThemed();
        #endregion

        #region Fields
        private bool _bPainting = false;
        private IntPtr _hProgressBarWnd = IntPtr.Zero;
        private cStoreDc _cProgressBarDc = new cStoreDc();
        private cStoreDc _cBufferDc = new cStoreDc();
        private Bitmap _oProgressBarBitmap;
        #endregion

        #region Constructor
        public cProgressBar(IntPtr hWnd, Bitmap skin)
        {
            if (hWnd == IntPtr.Zero)
                throw new Exception("The progressbar handle is invalid.");
            if (skin == null)
                throw new Exception("The progressbar image is invalid.");
            ProgressBarGraphic = skin;
            _hProgressBarWnd = hWnd;
            createBufferImage();
            if (Environment.OSVersion.Version.Major > 5)
            {
                if (IsAppThemed())
                    SetWindowTheme(_hProgressBarWnd, "", "");
            }
            this.AssignHandle(_hProgressBarWnd);
        }
        #endregion

        #region Properties
        private Bitmap ProgressBarGraphic
        {
            get { return _oProgressBarBitmap; }
            set
            {
                _oProgressBarBitmap = value;
                if (_cProgressBarDc.Hdc != IntPtr.Zero)
                {
                    _cProgressBarDc.Dispose();
                    _cProgressBarDc = new cStoreDc();
                }
                _cProgressBarDc.Width = _oProgressBarBitmap.Width;
                _cProgressBarDc.Height = _oProgressBarBitmap.Height;
                SelectObject(_cProgressBarDc.Hdc, _oProgressBarBitmap.GetHbitmap());
            }
        }
        #endregion

        #region Methods
        private void alphaBlit(IntPtr DstDc, int X, int Y, int Width, int Height, IntPtr SrcDc, int SrcX, int SrcY, int SrcWidth, int SrcHeight, byte btAlpha)
        {
            AlphaBlend(DstDc, X, Y, Width, Height, SrcDc, SrcX, SrcY, SrcWidth, SrcHeight, new BLENDFUNCTION(AC_SRC_OVER, 0x0, btAlpha, 0x0));
        }

        private GraphicsPath createRoundRectanglePath(Graphics g, float X, float Y, float width, float height, float radius)
        {
            // create a path
            GraphicsPath pathBounds = new GraphicsPath();
            pathBounds.AddLine(X + radius, Y, X + width - (radius * 2), Y);
            pathBounds.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            pathBounds.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
            pathBounds.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            pathBounds.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
            pathBounds.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            pathBounds.AddLine(X, Y + height - (radius * 2), X, Y + radius);
            pathBounds.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            pathBounds.CloseFigure();
            return pathBounds;
        }

        private void createBufferImage()
        {
            ProgressBar pb = (ProgressBar)Control.FromHandle(_hProgressBarWnd);
            Rectangle bounds = pb.ClientRectangle;
            Rectangle bdcopy = bounds;
            _cBufferDc.Height = pb.Height;
            _cBufferDc.Width = pb.Width;
            Graphics g = Graphics.FromHdc(_cBufferDc.Hdc);

            using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.AntiAlias))
            {
                using (GraphicsPath barPath = createRoundRectanglePath(
                    g,
                    bounds.X, bounds.Y,
                    bounds.Width, bounds.Height,
                    1f))
                {
                    using (SolidBrush backBrush = new SolidBrush(pb.BackColor))
                        g.FillRectangle(backBrush, bounds);
                    // draw the frame
                    using (LinearGradientBrush borderBrush = new LinearGradientBrush(
                        bounds,
                        Color.DarkGray,
                        Color.Silver,
                        90f))
                    {
                        borderBrush.SetSigmaBellShape(0.5f);
                        using (Pen borderPen = new Pen(borderBrush, .5f))
                            g.DrawPath(borderPen, barPath);
                    }
                    bounds.Width--;
                    bounds.Height--;
                    // create a clipping region
                    RectangleF clipBounds = bounds;
                    clipBounds.Inflate(-1, -1);
                    using (GraphicsPath clipPath = createRoundRectanglePath(
                        g,
                        clipBounds.X, clipBounds.Y,
                        clipBounds.Width + 1, clipBounds.Height + 1,
                        1f))
                    {
                        using (Region region = new Region(clipPath))
                            g.SetClip(region, CombineMode.Exclude);
                    }
                    // fill in the edge accent
                    using (LinearGradientBrush edgeBrush = new LinearGradientBrush(
                        bounds,
                        Color.DarkGray,
                        Color.Black,
                        90f))
                    {
                        edgeBrush.SetBlendTriangularShape(0.5f);
                        g.FillPath(edgeBrush, barPath);
                        g.ResetClip();
                        bounds.Inflate(-1, -1);
                    }
                    // fill with a subtle glow
                    using (LinearGradientBrush fillBrush = new LinearGradientBrush(
                        bounds,
                        Color.FromArgb(100, Color.White),
                        Color.FromArgb(100, Color.Silver),
                        LinearGradientMode.Vertical))
                    {
                        fillBrush.SetBlendTriangularShape(0.4f);
                        g.FillPath(fillBrush, barPath);
                        g.ResetClip();
                    }
                }
            }
            g.Dispose();
        }

        public void Dispose()
        {
            this.ReleaseHandle();
            if (_oProgressBarBitmap != null) _oProgressBarBitmap.Dispose();
            if (_cProgressBarDc != null) _cProgressBarDc.Dispose();
            if (_cBufferDc != null) _cBufferDc.Dispose();
            GC.SuppressFinalize(this);
        }

        private void drawProgressBar()
        {
            ProgressBar pb = (ProgressBar)Control.FromHandle(_hProgressBarWnd);
            RECT ctlRect = new RECT();
            cStoreDc tempDc = new cStoreDc();

            GetWindowRect(_hProgressBarWnd, ref ctlRect);
            OffsetRect(ref ctlRect, -ctlRect.Left, -ctlRect.Top);
            tempDc.Height = ctlRect.Bottom;
            tempDc.Width = ctlRect.Right;
            float length = (float)ctlRect.Right / ((float)pb.Maximum / (float)pb.Value);
            // draw the background
            alphaBlit(tempDc.Hdc, 0, 0, ctlRect.Right, ctlRect.Bottom, _cBufferDc.Hdc, 0, 0, _cBufferDc.Width, _cBufferDc.Height, 240);
            // draw the progress bar
            using (StretchMode mode = new StretchMode(tempDc.Hdc, StretchModeEnum.STRETCH_HALFTONE))
                StretchBlt(tempDc.Hdc, 1, 1, (int)length - 1, ctlRect.Bottom - 2, _cProgressBarDc.Hdc, 0, 0, _cProgressBarDc.Width, _cProgressBarDc.Height, 0xCC0020);

            Graphics g = Graphics.FromHwnd(_hProgressBarWnd);
            BitBlt(g.GetHdc(), 0, 0, ctlRect.Right, ctlRect.Bottom, tempDc.Hdc, 0, 0, 0xCC0020);
            g.ReleaseHdc();
            g.Dispose();
            tempDc.Dispose();
        }
        #endregion

        #region WndProc
        protected override void WndProc(ref Message m)
        {
            PAINTSTRUCT ps = new PAINTSTRUCT();
            switch (m.Msg)
            {
                case WM_PAINT:
                    if (!_bPainting)
                    {
                        _bPainting = true;
                        // start painting engine
                        BeginPaint(m.HWnd, ref ps);
                        drawProgressBar();
                        ValidateRect(m.HWnd, ref ps.rcPaint);
                        // done
                        EndPaint(m.HWnd, ref ps);
                        _bPainting = false;
                        m.Result = MSG_HANDLED;
                    }
                    else
                    {
                        base.WndProc(ref m);
                    }
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        #endregion
    }
}

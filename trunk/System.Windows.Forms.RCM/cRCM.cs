namespace System.Windows.Forms.RCM
{
    #region Author/About
    /************************************************************************************
    *  vtRCM   Radical (Non)Client Modification Class                                   *
    *                                                                                   *
    *  Created:     June 16, 2009                                                       *
    *  Modified:    Febuary 23, 2009                                                    *
    *  Purpose:     Form and usercontrol style modifier                                 *
    *  Revision:    1.4                                                                 *
    *  IDE:         C# 2008 SP1                                                         *
    *  Referenced:  Control Library NSP                                                 *
    *  Author:      John Underhill (Steppenwolfe)                                       *
    *                                                                                   *
    *************************************************************************************

    You can not:
    Sell or redistribute this code or the binary for profit.
    Use this in spyware, malware, or any generally acknowledged form of malicious software.
    Remove or alter the above author accreditation, or this disclaimer.

    You can:
    Use this code in your applications in any way you like.
    Use this in a published program, (a credit to vtdev.com would be nice)

    I will not:
    Except any responsibility for this code whatsoever. 
    There is no guarantee of fitness, nor should you have any expectation of support. 
    I further renounce any and all responsibilities for this code, in every way conceivable, 
    now, and for the rest of time. (clear enough?)
    
    If you use this in a successful (ie makes money :o) commercial project, you should notify me,
    and could throw a donation at my website' paypal (www.the-noc.net). Otherwise, it's all free..
    If you're looking for a telecommuting programmer, send me an email..
    
    Cheers,
    John
    steppenwolfe_2000@yahoo.com

    ***Revision History***
    -> 1.1
    First revision released June 16
    -> 1.2
    Code optimizations throughout
    xp fixes
    added scrollbar auto sizing
    -> 1.3
    fixed focus issues(hope)
    added a vista-like transition to buttons, combo, and standalone scrollbars(needs a little work)
    -> 1.4
    fixed to work on all frame types
    fixed button show on first click of caption bar in xp
    added offset properties for caption and icon
    added optional help button
    */
    #endregion

    #region Directives
    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;
    #endregion

    #region Public Enums
    public enum ControlType : int
    {
        Button = 1,
        CheckBox,
        ComboBox,
        ListBox,
        ListView,
        NumericUpDown,
        ProgressBar,
        RadioButton,
        ScrollBar,
        TabControl,
        TrackBar,
        TreeView
    }
    #endregion

    public class cRCM : NativeWindow
    {
        #region Constants
        // setbkmode
        private const int TRANSPARENT = 1;
        private const int OPAQUE = 2;
        // drawtext
        private const int DT_TOP = 0x0;
        private const int DT_LEFT = 0x0;
        private const int DT_CENTER = 0x1;
        private const int DT_RIGHT = 0x2;
        private const int DT_VCENTER = 0x4;
        private const int DT_BOTTOM = 0x8;
        private const int DT_WORDBREAK = 0x10;
        private const int DT_SINGLELINE = 0x20;
        private const int DT_EXPANDTABS = 0x40;
        private const int DT_TABSTOP = 0x80;
        private const int DT_NOCLIP = 0x100;
        private const int DT_EXTERNALLEADING = 0x200;
        private const int DT_CALCRECT = 0x400;
        private const int DT_NOPREFIX = 0x800;
        private const int DT_INTERNAL = 0x1000;
        private const int DT_EDITCONTROL = 0x2000;
        private const int DT_PATH_ELLIPSIS = 0x4000;
        private const int DT_END_ELLIPSIS = 0x8000;
        private const int DT_MODIFYSTRING = 0x10000;
        private const int DT_RTLREADING = 0x20000;
        private const int DT_WORD_ELLIPSIS = 0x40000;
        // window messages
        private const int WM_ACTIVATE = 0x6;
        private const int WM_CLICKACTIVE = 2;
        private const int WM_MDIACTIVATE = 0x0222;
        private const int WM_ACTIVATEAPP = 0x001C;
        private const int WM_NCDESTROY = 0x82;
        private const int WM_INITMENU = 0x116;
        private const int WM_INITMENUPOPUP = 0x117;
        private const int WM_EXITMENULOOP = 0x212;
        private const int WM_NCCALCSIZE = 0x83;
        private const int WM_NCHITTEST = 0x84;
        private const int WM_NCPAINT = 0x85;
        private const int WM_NCACTIVATE = 0x86;
        private const int WM_NCMOUSEMOVE = 0xA0;
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int WM_LMOUSEBUTTONDOWN = 0x0201;
        private const int WM_NCLBUTTONUP = 0xA2;
        private const int WM_NCLBUTTONDBLCLK = 0xA3;
        private const int WM_NCRBUTTONDOWN = 0xA4;
        private const int WM_NCRBUTTONUP = 0xA5;
        private const int WM_NCRBUTTONDBLCLK = 0xA6;
        private const int WM_SETFOCUS = 0x7;
        private const int WM_KILLFOCUS = 0x8;
        private const int WM_ENABLE = 0xA;
        private const int WM_TIMER = 0x113;
        private const int WM_SIZE = 0x5;
        private const int WM_STYLECHANGED = 0x7D;
        private const int WM_DISPLAYCHANGE = 0x7E;
        private const int WM_SYSCOMMAND = 0x112;
        private const int WM_GETICON = 0x7F;
        private const int WM_SETTEXT = 0xC;
        private const int WM_SETCURSOR = 0x0020;
        // window styles
        private const int GWL_STYLE = (-16);
        private const int GWL_EXSTYLE = (-20);
        private const int WS_THICKFRAME = 0x40000;
        private const int WS_DLGFRAME = 0x00400000;
        private const int WS_EX_CLIENTEDGE = 0x200;
        private const int WS_EX_WINDOWEDGE = 0x100;
        private const int WS_EX_STATICEDGE = 0x20000;
        private const int WS_EX_TOOLWINDOW = 0x80;
        // setwindowpos
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        // size/move
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_NOREDRAW = 0x0008;
        private const int SWP_NOACTIVATE = 0x0010;
        private const int SWP_FRAMECHANGED = 0x0020;
        private const int SWP_SHOWWINDOW = 0x0040;
        private const int SWP_HIDEWINDOW = 0x0080;
        private const int SWP_NOCOPYBITS = 0x0100;
        private const int SWP_NOOWNERZORDER = 0x0200;
        private const int SWP_NOSENDCHANGING = 0x0400;
        // redraw
        private const int RDW_INVALIDATE = 0x0001;
        private const int RDW_INTERNALPAINT = 0x0002;
        private const int RDW_ERASE = 0x0004;
        private const int RDW_VALIDATE = 0x0008;
        private const int RDW_NOINTERNALPAINT = 0x0010;
        private const int RDW_NOERASE = 0x0020;
        private const int RDW_NOCHILDREN = 0x0040;
        private const int RDW_ALLCHILDREN = 0x0080;
        private const int RDW_UPDATENOW = 0x0100;
        private const int RDW_ERASENOW = 0x0200;
        private const int RDW_FRAME = 0x0400;
        private const int RDW_NOFRAME = 0x0800;
        // nc_calcsize return params
        private const int WVR_VALIDRECTS = 0x400;
        private const int WVR_HREDRAW = 0x0100;
        private const int WVR_VREDRAW = 0x0200;
        private const int WVR_REDRAW = (WVR_HREDRAW | WVR_VREDRAW);
        // misc
        private const int FRAME_WIDTH = 8;
        private const int CAPTION_HEIGHT = 30;
        private const int VK_LBUTTON = 0x1;
        private const int VK_RBUTTON = 0x2;
        private const int KEY_PRESSED = 0x1000;
        private const int SPI_GETWORKAREA = 0x0030;
        private const int DI_NORMAL = 0x0003;
        static readonly IntPtr MESSAGE_HANDLED = new IntPtr(1);
        static readonly IntPtr MESSAGE_PROCESS = new IntPtr(0);
        #endregion

        #region Private Enums
        [Flags]
        private enum MouseEventFlags
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
        }

        private enum POST_MESSAGES : int 
        {
            SC_ARRANGE = 0xF110,
            SC_CLOSE = 0xF060,
            SC_MAXIMIZE = 0xF030,
            SC_MINIMIZE = 0xF020,
            SC_MOVE = 0xF010,
            SC_NEXTWINDOW = 0xF040,
            SC_PREVWINDOW = 0xF050,
            SC_RESTORE = 0xF120,
            SC_SIZE = 0xF000
        }

        private enum HIT_CONSTANTS : int 
        {
            HTERROR = -2,
            HTTRANSPARENT = -1,
            HTNOWHERE = 0,
            HTCLIENT = 1,
            HTCAPTION = 2,
            HTSYSMENU = 3,
            HTGROWBOX = 4,
            HTMENU = 5,
            HTHSCROLL = 6,
            HTVSCROLL = 7,
            HTMINBUTTON = 8,
            HTMAXBUTTON = 9,
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17,
            HTBORDER = 18,
            HTOBJECT = 19,
            HTCLOSE = 20,
            HTHELP = 21
        }

        [Flags]
        private enum SYSTEM_METRIC : int
        {
            SM_CXSCREEN = 0,
            SM_CYSCREEN = 1,
            SM_CXVSCROLL = 2,
            SM_CYHSCROLL = 3,
            SM_CYCAPTION = 4,
            SM_CXBORDER = 5,
            SM_CYBORDER = 6,
            SM_CXDLGFRAME = 7,
            SM_CYDLGFRAME = 8,
            SM_CYVTHUMB = 9,
            SM_CXHTHUMB = 10,
            SM_CXICON = 11,
            SM_CYICON = 12,
            SM_CXCURSOR = 13,
            SM_CYCURSOR = 14,
            SM_CYMENU = 15,
            SM_CXFULLSCREEN = 16,
            SM_CYFULLSCREEN = 17,
            SM_CYKANJIWINDOW = 18,
            SM_MOUSEPRESENT = 19,
            SM_CYVSCROLL = 20,
            SM_CXHSCROLL = 21,
            SM_DEBUG = 22,
            SM_SWAPBUTTON = 23,
            SM_RESERVED1 = 24,
            SM_RESERVED2 = 25,
            SM_RESERVED3 = 26,
            SM_RESERVED4 = 27,
            SM_CXMIN = 28,
            SM_CYMIN = 29,
            SM_CXSIZE = 30,
            SM_CYSIZE = 31,
            SM_CXFRAME = 32,
            SM_CYFRAME = 33,
            SM_CXMINTRACK = 34,
            SM_CYMINTRACK = 35,
            SM_CXDOUBLECLK = 36,
            SM_CYDOUBLECLK = 37,
            SM_CXICONSPACING = 38,
            SM_CYICONSPACING = 39,
            SM_MENUDROPALIGNMENT = 40,
            SM_PENWINDOWS = 41,
            SM_DBCSENABLED = 42,
            SM_CMOUSEBUTTONS = 43,
            SM_SECURE = 44,
            SM_CXEDGE = 45,
            SM_CYEDGE = 46,
            SM_CXMINSPACING = 47,
            SM_CYMINSPACING = 48,
            SM_CXSMICON = 49,
            SM_CYSMICON = 50,
            SM_CYSMCAPTION = 51,
            SM_CXSMSIZE = 52,
            SM_CYSMSIZE = 53,
            SM_CXMENUSIZE = 54,
            SM_CYMENUSIZE = 55,
            SM_ARRANGE = 56,
            SM_CXMINIMIZED = 57,
            SM_CYMINIMIZED = 58,
            SM_CXMAXTRACK = 59,
            SM_CYMAXTRACK = 60,
            SM_CXMAXIMIZED = 61,
            SM_CYMAXIMIZED = 62,
            SM_NETWORK = 63,
            SM_CLEANBOOT = 67,
            SM_CXDRAG = 68,
            SM_CYDRAG = 69,
            SM_SHOWSOUNDS = 70,
            SM_CXMENUCHECK = 71,
            SM_CYMENUCHECK = 72,
            SM_SLOWMACHINE = 73,
            SM_MIDEASTENABLED = 74,
            SM_MOUSEWHEELPRESENT = 75,
            SM_XVIRTUALSCREEN = 76,
            SM_YVIRTUALSCREEN = 77,
            SM_CXVIRTUALSCREEN = 78,
            SM_CYVIRTUALSCREEN = 79,
            SM_CMONITORS = 80,
            SM_SAMEDISPLAYFORMAT = 81,
            SM_IMMENABLED = 82,
            SM_CXFOCUSBORDER = 83,
            SM_CYFOCUSBORDER = 84,
            SM_TABLETPC = 86,
            SM_MEDIACENTER = 87,
            SM_CMETRICS_OTHER = 76,
            SM_CMETRICS_2000 = 83,
            SM_CMETRICS_NT = 88,
            SM_REMOTESESSION = 0x1000,
            SM_SHUTTINGDOWN = 0x2000,
            SM_REMOTECONTROL = 0x2001,
        }
        #endregion

        #region Structs
        [StructLayout(LayoutKind.Sequential)]
        private struct POINT {
            internal int X;
            internal int Y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT {
            internal RECT(int X, int Y, int Width, int Height) {
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
        private struct NCCALCSIZE_PARAMS {
            internal RECT rect0, rect1, rect2;
            internal IntPtr lppos;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WINDOWPOS {
            internal IntPtr hwnd;
            internal IntPtr hwndInsertAfter;
            internal int x;
            internal int y;
            internal int cx;
            internal int cy;
            internal int flags;
        }
        #endregion

        #region API
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool PtInRect([In] ref RECT lprc, Point pt);

        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);

        [DllImport("user32.dll")]
        private static extern int ScreenToClient(IntPtr hwnd, ref Point lpPoint);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndAfter, int x, int y, int cx, int cy, uint flags);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetClientRect(IntPtr hWnd, ref RECT r);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hwnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr handle, IntPtr hdc);

        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(SYSTEM_METRIC smIndex);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool StretchBlt(IntPtr hDest, int X, int Y, int nWidth, int nHeight, IntPtr hdcSrc,
        int sX, int sY, int nWidthSrc, int nHeightSrc, int dwRop);

        [DllImport("user32.dll")]
        private extern static int OffsetRect(ref RECT lpRect, int x, int y);

        [DllImport("user32.dll")]
        private static extern IntPtr SetTimer(IntPtr hWnd, int nIDEvent, uint uElapse, IntPtr lpTimerFunc);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool KillTimer(IntPtr hWnd, uint uIDEvent);

        [DllImport("gdi32.dll")]
        private extern static int ExcludeClipRect(IntPtr hdc, int x1, int y1, int x2, int y2);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, uint flags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr DefWindowProc(IntPtr hWnd, int uMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern short GetKeyState(int nVirtKey);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsZoomed(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SystemParametersInfo(int uAction, uint uParam, ref RECT lpvParam, uint fuWinIni);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DrawIconEx(IntPtr hdc, int xLeft, int yTop, IntPtr hIcon, int cxWidth, int cyHeight, 
            int istepIfAniCur, IntPtr hbrFlickerFreeDraw, int diFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int DrawText(IntPtr hdc, string lpStr, int nCount, ref RECT lpRect, int wFormat);

        [DllImport("gdi32.dll")]
        private static extern int SetTextColor(IntPtr hdc, int crColor);

        [DllImport("gdi32.dll")]
        private static extern int SetBkMode(IntPtr hdc, int iBkMode);

        [DllImport("user32.dll")]
        private extern static int InflateRect(ref RECT lpRect, int x, int y);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hWnd, String pszSubAppName, String pszSubIdList);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        #endregion

        #region Fields

        private bool _isActive = true;
        private bool _bWindowMaximized = false;
        private bool _bFontRightLeading = false;
        private bool _bCenterTitle = false;
        private bool _bSkinChildControls = false;
        private bool _bUseCustomTips = false;
        private bool _bSupressHelpTip = false;
        private bool _bFirstHit = false;
        private bool _bStoreSize = false;
        private bool _bResetSize = false;
        private int _iIconSize = 0;
        private int _iButtonOffsetX = 8;
        private int _iButtonOffsetY = 0;
        private int _iIconOffsetX = 0;
        private int _iIconOffsetY = 0;
        private int _iTitleOffsetX = 0;
        private int _iTitleOffsetY = 0;
        private int _iExcludeLeftStart = 0;
        private int _iExcludeLeftEnd = 0;
        private int _iExcludeRightStart = 0;
        private int _iExcludeRightEnd = 0;
        private int _iFrameHeight = FRAME_WIDTH;
        private int _iFrameWidth = FRAME_WIDTH;
        private int _iCaptionHeight = CAPTION_HEIGHT;
        private int _iCaptionBoxStart = 0;
        private int _buttonTimer = 0;
        private IntPtr _hParentWnd = IntPtr.Zero;
        private Color _oForeColor = Color.White;
        private Font _oTitleFont = new Font("Tahoma", 8, FontStyle.Bold);
        private Bitmap _oTransitionMask;
        // frame
        private cStoreDc _cCaptionBarDc = new cStoreDc();
        private Bitmap _oCaptionBarBitmap;
        private cStoreDc _cLeftFrameDc = new cStoreDc();
        private Bitmap _oLeftFrameBitmap;
        private cStoreDc _cRightFrameDc = new cStoreDc();
        private Bitmap _oRightFrameBitmap;
        private cStoreDc _cBottomFrameDc = new cStoreDc();
        private Bitmap _oBottomFrameBitmap;
        // buttons
        private cStoreDc _cMinimizeButtonDc = new cStoreDc();
        private Bitmap _oMinimizeButtonBitmap;
        private cStoreDc _cMaximizeButtonDc = new cStoreDc();
        private Bitmap _oMaximizeButtonBitmap;
        private cStoreDc _cRestoreButtonDc = new cStoreDc();
        private Bitmap _oRestoreButtonBitmap;
        private cStoreDc _cCloseButtonDc = new cStoreDc();
        private Bitmap _oCloseButtonBitmap;
        private cStoreDc _cHelpButtonDc = new cStoreDc();
        private Bitmap _oHelpButtonBitmap;
        private RECT _tRestoreRect = new RECT();
        private RECT[] _aButtonRect = new RECT[4];
        private HIT_CONSTANTS _eLastWindowHit = HIT_CONSTANTS.HTNOWHERE;
        private HIT_CONSTANTS _eLastButtonHit = HIT_CONSTANTS.HTNOWHERE;
        private cButton _cButtonSkin;
        private Dictionary<IntPtr, cComboBox> _oComboSkin;
        private Dictionary<IntPtr, cProgressBar> _oProgressBarSkin;
        private Dictionary<IntPtr, cTabControl> _oTabControlSkin;
        private Dictionary<IntPtr, cTrackBar> _oTrackBarSkin;
        private Dictionary<IntPtr, cNumericUpDown> _oNumericUpDownSkin;
        private Dictionary<IntPtr, cListView> _oListviewSkin;
        private Dictionary<IntPtr, cScrollBar> _oScrollbarSkin;
        private Dictionary<IntPtr, cTreeView> _oTreeviewSkin;
        private Dictionary<IntPtr, cListBox> _oListboxSkin;
        // enum child delegate
        public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);
        #endregion

        #region Events and Delegates
        public delegate void HelpClickedDelegate(Object sender, EventArgs e);
        public event HelpClickedDelegate HelpClicked;
        #endregion

        #region Constructor
        public cRCM(IntPtr handle)
        {
            _hParentWnd = handle;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set Caption buttons offset from right.
        /// </summary>
        public int ButtonOffsetX
        {
            get { return _iButtonOffsetX; }
            set { _iButtonOffsetX = value; }
        }

        /// <summary>
        /// Get/Set Caption Buttons offset from center.
        /// </summary>
        public int ButtonOffsetY
        {
            get { return _iButtonOffsetY; }
            set { _iButtonOffsetY = value; }
        }

        /// <summary>
        /// Get/Set Center the forms title in the caption bar.
        /// </summary>
        public bool CenterTitle
        {
            get { return _bCenterTitle; }
            set { _bCenterTitle = value; }
        }

        /// <summary>
        /// Get/Set Exclude tiling of left caption area starting position.
        /// </summary>
        public int ExcludeLeftStart
        {
            get { return _iExcludeLeftStart; }
            set { _iExcludeLeftStart = value; }
        }

        /// <summary>
        /// Get/Set Exclude tiling of left caption area ending position.
        /// </summary>
        public int ExcludeLeftEnd
        {
            get { return _iExcludeLeftEnd; }
            set { _iExcludeLeftEnd = value; }
        }

        /// <summary>
        /// Get/Set Exclude tiling of left caption area starting position.
        /// </summary>
        public int ExcludeRightStart
        {
            get { return _iExcludeRightStart; }
            set { _iExcludeRightStart = value; }
        }

        /// <summary>
        /// Get/Set Exclude tiling of right caption area starting position.
        /// </summary>
        public int ExcludeRightEnd
        {
            get { return _iExcludeRightEnd; }
            set { _iExcludeRightEnd = value; }
        }

        /// <summary>
        /// Get Forms focus state.
        /// </summary>
        public bool Focused
        {
            get { return (GetForegroundWindow() == ParentWnd); }
        }

        /// <summary>
        /// Get/Set Use right aligned text in the caption bar.
        /// </summary>
        public bool FontRightLeading
        {
            get { return _bFontRightLeading; }
            set { _bFontRightLeading = value; }
        }

        /// <summary>
        /// Get/Set The caption title forecolor.
        /// </summary>
        public Color ForeColor
        {
            get { return _oForeColor; }
            set { _oForeColor = value; }
        }

        /// <summary>
        /// Get/Set Icon offset from left.
        /// </summary>
        public int IconOffsetX
        {
            get { return _iIconOffsetX; }
            set { _iIconOffsetX = value; }
        }

        /// <summary>
        /// Get/Set Icon offset from center.
        /// </summary>
        public int IconOffsetY
        {
            get { return _iIconOffsetY; }
            set { _iIconOffsetY = value; }
        }

        /// <summary>
        /// Get Parent window handle.
        /// </summary>
        public IntPtr ParentWnd
        {
            get { return _hParentWnd; }
        }

        /// <summary>
        /// Get/Set Skins controls in a container (tab). 
        /// Container controls must be added last to skinned controls list.
        /// </summary>
        public bool SkinChildControls
        {
            get { return _bSkinChildControls; }
            set { _bSkinChildControls = value; }
        }

        /// <summary>
        /// Get/Set Supress tooltip on optional help button.
        /// </summary>
        public bool SupressHelpTip
        {
            get { return _bSupressHelpTip; }
            set { _bSupressHelpTip = value; }
        }

        /// <summary>
        /// Get/Set Caption offset from left.
        /// </summary>
        public int TitleOffsetX
        {
            get { return _iTitleOffsetX; }
            set { _iTitleOffsetX = value; }
        }

        /// <summary>
        /// Get/Set Caption offset from center.
        /// </summary>
        public int TitleOffsetY
        {
            get { return _iTitleOffsetY; }
            set { _iTitleOffsetY = value; }
        }

        /// <summary>
        /// Get/Set The caption font.
        /// </summary>
        public Font TitleFont
        {
            get { return _oTitleFont; }
            set { _oTitleFont = value; }
        }

        public Bitmap TransitionGraphic
        {
            get { return _oTransitionMask; }
            set { _oTransitionMask = value; }
        }

        /// <summary>
        /// Get/Set Use custom tooltips on child controls.
        /// </summary>
        public bool UseCustomTips
        {
            get { return _bUseCustomTips; }
            set { _bUseCustomTips = value; }
        }

        #region Images
        public Bitmap CaptionBarGraphic
        {
            get { return _oCaptionBarBitmap; }
            set
            {
                _oCaptionBarBitmap = value;
                if (_cCaptionBarDc.Hdc != IntPtr.Zero)
                {
                    _cCaptionBarDc.Dispose();
                    _cCaptionBarDc = new cStoreDc();
                }
                _cCaptionBarDc.Width = _oCaptionBarBitmap.Width;
                _cCaptionBarDc.Height = _oCaptionBarBitmap.Height;
                SelectObject(_cCaptionBarDc.Hdc, _oCaptionBarBitmap.GetHbitmap());
            }
        }

        public Bitmap LeftFrameGraphic
        {
            get { return _oLeftFrameBitmap; }
            set
            {
                _oLeftFrameBitmap = value;
                if (_cLeftFrameDc.Hdc != IntPtr.Zero)
                {
                    _cLeftFrameDc.Dispose();
                    _cLeftFrameDc = new cStoreDc();
                }
                _cLeftFrameDc.Width = _oLeftFrameBitmap.Width;
                _cLeftFrameDc.Height = _oLeftFrameBitmap.Height;
                SelectObject(_cLeftFrameDc.Hdc, _oLeftFrameBitmap.GetHbitmap());
            }
        }

        public Bitmap RightFrameGraphic
        {
            get { return _oRightFrameBitmap; }
            set
            {
                _oRightFrameBitmap = value;
                if (_cRightFrameDc.Hdc != IntPtr.Zero)
                {
                    _cRightFrameDc.Dispose();
                    _cRightFrameDc = new cStoreDc();
                }
                _cRightFrameDc.Width = _oRightFrameBitmap.Width;
                _cRightFrameDc.Height = _oRightFrameBitmap.Height;
                SelectObject(_cRightFrameDc.Hdc, _oRightFrameBitmap.GetHbitmap());
            }
        }

        public Bitmap BottomFrameGraphic
        {
            get { return _oBottomFrameBitmap; }
            set
            {
                _oBottomFrameBitmap = value;
                if (_cBottomFrameDc.Hdc != IntPtr.Zero)
                {
                    _cBottomFrameDc.Dispose();
                    _cBottomFrameDc = new cStoreDc();
                }
                _cBottomFrameDc.Width = _oBottomFrameBitmap.Width;
                _cBottomFrameDc.Height = _oBottomFrameBitmap.Height;
                SelectObject(_cBottomFrameDc.Hdc, _oBottomFrameBitmap.GetHbitmap());
            }
        }

        public Bitmap MinimizeButtonGraphic
        {
            get { return _oMinimizeButtonBitmap; }
            set
            {
                _oMinimizeButtonBitmap = value;
                if (_cMinimizeButtonDc.Hdc != IntPtr.Zero)
                {
                    _cMinimizeButtonDc.Dispose();
                    _cMinimizeButtonDc = new cStoreDc();
                }
                _cMinimizeButtonDc.Width = _oMinimizeButtonBitmap.Width;
                _cMinimizeButtonDc.Height = _oMinimizeButtonBitmap.Height;
                SelectObject(_cMinimizeButtonDc.Hdc, _oMinimizeButtonBitmap.GetHbitmap());
            }
        }

        public Bitmap MaximizeButtonGraphic
        {
            get { return _oMaximizeButtonBitmap; }
            set
            {
                _oMaximizeButtonBitmap = value;
                if (_cMaximizeButtonDc.Hdc != IntPtr.Zero)
                {
                    _cMaximizeButtonDc.Dispose();
                    _cMaximizeButtonDc = new cStoreDc();
                }
                _cMaximizeButtonDc.Width = _oMaximizeButtonBitmap.Width;
                _cMaximizeButtonDc.Height = _oMaximizeButtonBitmap.Height;
                SelectObject(_cMaximizeButtonDc.Hdc, _oMaximizeButtonBitmap.GetHbitmap());
            }
        }

        public Bitmap RestoreButtonGraphic
        {
            get { return _oRestoreButtonBitmap; }
            set
            {
                _oRestoreButtonBitmap = value;
                if (_cRestoreButtonDc.Hdc != IntPtr.Zero)
                {
                    _cRestoreButtonDc.Dispose();
                    _cRestoreButtonDc = new cStoreDc();
                }
                _cRestoreButtonDc.Width = _oRestoreButtonBitmap.Width;
                _cRestoreButtonDc.Height = _oRestoreButtonBitmap.Height;
                SelectObject(_cRestoreButtonDc.Hdc, _oRestoreButtonBitmap.GetHbitmap());
            }
        }

        public Bitmap CloseButtonGraphic
        {
            get { return _oCloseButtonBitmap; }
            set
            {
                _oCloseButtonBitmap = value;
                if (_cCloseButtonDc.Hdc != IntPtr.Zero)
                {
                    _cCloseButtonDc.Dispose();
                    _cCloseButtonDc = new cStoreDc();
                }
                _cCloseButtonDc.Width = _oCloseButtonBitmap.Width;
                _cCloseButtonDc.Height = _oCloseButtonBitmap.Height;
                SelectObject(_cCloseButtonDc.Hdc, _oCloseButtonBitmap.GetHbitmap());
            }
        }

        public Bitmap HelpButtonGraphic
        {
            get { return _oHelpButtonBitmap; }
            set
            {
                _oHelpButtonBitmap = value;
                if (_cHelpButtonDc.Hdc != IntPtr.Zero)
                {
                    _cHelpButtonDc.Dispose();
                    _cHelpButtonDc = new cStoreDc();
                }
                _cHelpButtonDc.Width = _oHelpButtonBitmap.Width;
                _cHelpButtonDc.Height = _oHelpButtonBitmap.Height;
                SelectObject(_cHelpButtonDc.Hdc, _oHelpButtonBitmap.GetHbitmap());
            }
        }
        #endregion
        #endregion

        #region Private Properties
        private bool CanClose
        {
            get { return ((GetWindowLong(ParentWnd, GWL_STYLE) & 0x80000) == 0x80000); }
        }

        private bool CanHelp
        {
            //get { return (_oHelpButtonBitmap != null); }
            get
            {
                Form f = (Form)Form.FromHandle(ParentWnd);
                return f.HelpButton;
            }
        }

        private bool CanMinimize
        {
            get
            {
                Form f = (Form)Form.FromHandle(ParentWnd);
                return f.MinimizeBox;
            }
        }

        private bool CanMaximize
        {
            get
            {
                Form f = (Form)Form.FromHandle(ParentWnd);
                return f.MaximizeBox;
            }
        }

        private bool CanSize
        {
            get
            {
                Form f = (Form)Form.FromHandle(ParentWnd);
                return f.MaximizeBox;
            }
        }

        private bool WindowMaximized
        {
            get { return _bWindowMaximized; }
            set { _bWindowMaximized = value; }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Add method for Trackbar control
        /// </summary>
        /// <param name="ct">Control type [TrackBar]</param>
        /// <param name="thumb">Thumb image</param>
        /// <param name="track">Track image</param>
        public void Add(ControlType ct, Bitmap thumb, Bitmap track)
        {
            if (thumb == null)
                throw new Exception("Required image is either missing or invalid.");
            if (track == null)
                throw new Exception("Required image is either missing or invalid.");

            List<IntPtr> list = GetChildWindows(_hParentWnd);
            StringBuilder nameBldr = new StringBuilder(100);
            string ctlname = ct.ToString().ToLower();
            if (ctlname == "trackbar")
            {
                if (_oTrackBarSkin == null)
                    _oTrackBarSkin = new Dictionary<IntPtr, cTrackBar>();

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] != IntPtr.Zero)
                    {
                        Control ctl = Control.FromHandle(list[i]);
                        if (ctl != null)
                        {
                            Type t = ctl.GetType();
                            string name = t.Name.ToLower();
                            if (name == ctlname)
                            {
                                _oTrackBarSkin.Add(ctl.Handle, new cTrackBar(ctl.Handle, thumb, track));
                                ctl.Refresh();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Add method for the ScrollBar control
        /// </summary>
        /// <param name="ct">Control type [ScrollBar]</param>
        /// <param name="track">Track image</param>
        /// <param name="arrow">Arrow image</param>
        /// <param name="thumb">Thumb image</param>
        /// <param name="orientation">ScrollbBar orientation</param>
        public void Add(ControlType ct, Bitmap track, Bitmap arrow, Bitmap thumb, Orientation orientation)
        {
            List<IntPtr> list = GetChildWindows(_hParentWnd);
            StringBuilder nameBldr = new StringBuilder(100);
            string ctlname = ct.ToString().ToLower();
            if (ctlname == "scrollbar")
            {
                if (_oScrollbarSkin == null)
                    _oScrollbarSkin = new Dictionary<IntPtr, cScrollBar>();

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] != IntPtr.Zero)
                    {
                        Control ctl = Control.FromHandle(list[i]);
                        if (ctl != null)
                        {
                            Type t = ctl.GetType();
                            string name = t.Name.ToLower();
                            //Debug.Print(name);
                            if (orientation == Orientation.Horizontal)
                            {
                                if (name == "hscrollbar")
                                {
                                    _oScrollbarSkin.Add(ctl.Handle, new cScrollBar(ctl.Handle, Orientation.Horizontal, thumb, track, arrow, TransitionGraphic));
                                    ctl.Refresh();
                                }
                            }
                            else
                            {
                                if (name == "vscrollbar")
                                {
                                    _oScrollbarSkin.Add(ctl.Handle, new cScrollBar(ctl.Handle, Orientation.Vertical, thumb, track, arrow, TransitionGraphic));
                                    ctl.Refresh();
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Add method for TreeView and ListBox controls.
        /// </summary>
        /// <param name="ct">Control type [ListView]</param>
        /// <param name="hztrack">Horizontal track image</param>
        /// <param name="hzarrow">Horizontal arrow image</param>
        /// <param name="hzthumb">Horizontal thumb image</param>
        /// <param name="vttrack">Vertical track image</param>
        /// <param name="vtarrow">Vertical arrow image</param>
        /// <param name="vtthumb">Vertical thumb image</param>
        public void Add(ControlType ct, Bitmap hztrack, Bitmap hzarrow, Bitmap hzthumb, Bitmap vttrack, Bitmap vtarrow, Bitmap vtthumb)
        {
            List<IntPtr> list = GetChildWindows(_hParentWnd);
            StringBuilder nameBldr = new StringBuilder(100);
            string ctlname = ct.ToString().ToLower();
            if (ctlname == "treeview")
            {
                if (_oTreeviewSkin == null)
                    _oTreeviewSkin = new Dictionary<IntPtr, cTreeView>();

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] != IntPtr.Zero)
                    {
                        Control ctl = Control.FromHandle(list[i]);
                        if (ctl != null)
                        {
                            Type t = ctl.GetType();
                            string name = t.Name.ToLower();
                            if (name == ctlname)
                            {
                                _oTreeviewSkin.Add(ctl.Handle, new cTreeView(ctl.Handle, hztrack, hzarrow, hzthumb, vttrack, vtarrow, vtthumb, TransitionGraphic));
                                ctl.Refresh();
                            }
                        }
                    }
                }
            }
            else if (ctlname == "listbox")
            {
                if (_oListboxSkin == null)
                    _oListboxSkin = new Dictionary<IntPtr, cListBox>();

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] != IntPtr.Zero)
                    {
                        Control ctl = Control.FromHandle(list[i]);
                        if (ctl != null)
                        {
                            Type t = ctl.GetType();
                            string name = t.Name.ToLower();
                            if (name == ctlname)
                            {
                                _oListboxSkin.Add(ctl.Handle, new cListBox(ctl.Handle, hztrack, hzarrow, hzthumb, vttrack, vtarrow, vtthumb, TransitionGraphic));
                                ctl.Refresh();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Add method for ListView control.
        /// </summary>
        /// <param name="ct">Control type [ListView]</param>
        /// <param name="header">Header image</param>
        /// <param name="hztrack">Horizontal track image</param>
        /// <param name="hzarrow">Horizontal arrow image</param>
        /// <param name="hzthumb">Horizontal thumb image</param>
        /// <param name="vttrack">Vertical track image</param>
        /// <param name="vtarrow">Vertical arrow image</param>
        /// <param name="vtthumb">Vertical thumb image</param>
        public void Add(ControlType ct, Bitmap header, Bitmap hztrack, Bitmap hzarrow, Bitmap hzthumb, Bitmap vttrack, Bitmap vtarrow, Bitmap vtthumb)
        {
            List<IntPtr> list = GetChildWindows(_hParentWnd);
            StringBuilder nameBldr = new StringBuilder(100);
            string ctlname = ct.ToString().ToLower();
            if (ctlname == "listview")
            {
                if (_oListviewSkin == null)
                    _oListviewSkin = new Dictionary<IntPtr, cListView>();

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] != IntPtr.Zero)
                    {
                        Control ctl = Control.FromHandle(list[i]);
                        if (ctl != null)
                        {
                            Type t = ctl.GetType();
                            string name = t.Name.ToLower();
                            if (name == ctlname)
                            {
                                _oListviewSkin.Add(ctl.Handle, new cListView(ctl.Handle, header, hztrack, hzarrow, hzthumb, vttrack, vtarrow, vtthumb, TransitionGraphic));
                                ctl.Refresh();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Add method for Button, Checkbox, Radio Button, ComboBox, ProgressBar, Spin Button, and Tab Control
        /// </summary>
        /// <param name="ct">Control type</param>
        /// <param name="skin">Control image</param>
        public void Add(ControlType ct, Bitmap skin)
        {
            if (skin == null)
                throw new Exception("Required image is either missing or invalid.");

            List<IntPtr> list = GetChildWindows(_hParentWnd);
            StringBuilder nameBldr = new StringBuilder(100);
            string ctlname = ct.ToString().ToLower();

            if ((ctlname == "button") || (ctlname == "checkbox") || (ctlname == "radiobutton"))
            {
                if (_cButtonSkin == null)
                    _cButtonSkin = new cButton(_hParentWnd);
                if (ctlname == "checkbox")
                    _cButtonSkin.CheckboxGraphic = skin;
                else if (ctlname == "radiobutton")
                    _cButtonSkin.RadiobuttonGraphic = skin;
                else if (ctlname == "button")
                {

                    if (TransitionGraphic != null)
                        _cButtonSkin.TransitionGraphic = TransitionGraphic;
                    _cButtonSkin.PushbuttonGraphic = skin;
                }
            }
            else if (ctlname == "combobox")
            {
                if (_oComboSkin == null)
                    _oComboSkin = new Dictionary<IntPtr, cComboBox>();
            }
            else if (ctlname == "numericupdown")
            {
                if (_oNumericUpDownSkin == null)
                    _oNumericUpDownSkin = new Dictionary<IntPtr, cNumericUpDown>();
            }
            else if (ctlname == "progressbar")
            {
                if (_oProgressBarSkin == null)
                    _oProgressBarSkin = new Dictionary<IntPtr, cProgressBar>();
            }
            else if (ctlname == "tabcontrol")
            {
                if (_oTabControlSkin == null)
                    _oTabControlSkin = new Dictionary<IntPtr, cTabControl>();
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != IntPtr.Zero)
                {
                    Control ctl = Control.FromHandle(list[i]);
                    if (ctl != null)
                    {
                        Type t = ctl.GetType();
                        string name = t.Name.ToLower();
                        if (name == ctlname)
                        {
                            AddControl(ctlname, list[i], skin);
                            if (ctlname == "tabcontrol")
                            {
                                _oTabControlSkin.Add(list[i], new cTabControl(list[i], skin));
                                TabControl tb = (TabControl)Control.FromHandle(list[i]);
                                if (UseCustomTips)
                                {
                                    _oTabControlSkin[list[i]].UseCustomToolTips(tb);
                                    _oTabControlSkin[list[i]].ToolTipEnable = true;
                                }
                                if (SkinChildControls)
                                {
                                    foreach (TabPage page in tb.Controls)
                                    {
                                        foreach (Control tabElement in page.Controls)
                                        {
                                            Type elementType = tabElement.GetType();
                                            AddControl(elementType.Name.ToLower(), tabElement.Handle, skin);
                                        }
                                    }
                                }
                            }
                            ctl.Refresh();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Remove a control group from the skin engine
        /// </summary>
        /// <param name="ct">Control type</param>
        public void Remove(ControlType ct)
        {
            List<IntPtr> list = GetChildWindows(_hParentWnd);
            StringBuilder nameBldr = new StringBuilder(100);
            string ctlname = ct.ToString().ToLower();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != IntPtr.Zero)
                {
                    Control ctl = Control.FromHandle(list[i]);
                    if (ctl != null)
                    {
                        Type t = ctl.GetType();
                        string name = t.Name.ToLower();

                        if ((ctlname == "checkbox") || (ctlname == "radiobutton") || (ctlname == "button"))
                        {
                            if (name == ctlname)
                            {
                                _cButtonSkin.Remove(list[i]);
                                ctl.Refresh();
                            }
                        }
                        else if (ctlname == "combobox")
                        {
                            if (_oComboSkin.ContainsKey(list[i]))
                            {
                                _oComboSkin[list[i]].Dispose();
                                _oComboSkin.Remove(list[i]);
                                ctl.Refresh();
                            }
                        }
                        else if (ctlname == "listbox")
                        {
                            if (_oListboxSkin.ContainsKey(list[i]))
                            {
                                _oListboxSkin[list[i]].Dispose();
                                _oListboxSkin.Remove(list[i]);
                                ctl.Refresh();
                            }
                        }
                        else if (ctlname == "listview")
                        {
                            if (_oListviewSkin.ContainsKey(list[i]))
                            {
                                _oListviewSkin[list[i]].Dispose();
                                _oListviewSkin.Remove(list[i]);
                                ctl.Refresh();
                            }
                        }
                        else if (ctlname == "numericupdown")
                        {
                            if (_oNumericUpDownSkin.ContainsKey(list[i]))
                            {
                                _oNumericUpDownSkin[list[i]].Dispose();
                                _oNumericUpDownSkin.Remove(list[i]);
                                ctl.Refresh();
                            }
                        }
                        else if (ctlname == "progressbar")
                        {
                            if (_oProgressBarSkin.ContainsKey(list[i]))
                            {
                                _oProgressBarSkin[list[i]].Dispose();
                                _oProgressBarSkin.Remove(list[i]);
                                ctl.Refresh();
                            }
                        }
                        else if (ctlname == "tabcontrol")
                        {
                            if (_oTabControlSkin.ContainsKey(list[i]))
                            {
                                _oTabControlSkin[list[i]].Dispose();
                                _oTabControlSkin.Remove(list[i]);
                                ctl.Refresh();
                            }
                        }
                        else if (ctlname == "tracksbar")
                        {
                            if (_oTrackBarSkin.ContainsKey(list[i]))
                            {
                                _oTrackBarSkin[list[i]].Dispose();
                                _oTrackBarSkin.Remove(list[i]);
                                ctl.Refresh();
                            }
                        }
                        else if (ctlname == "treeview")
                        {
                            if (_oTreeviewSkin.ContainsKey(list[i]))
                            {
                                _oTreeviewSkin[list[i]].Dispose();
                                _oTreeviewSkin.Remove(list[i]);
                                ctl.Refresh();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Remove a specific control from the skin engine
        /// </summary>
        /// <param name="handle">Control handle</param>
        public void Remove(IntPtr handle)
        {
            if (handle != IntPtr.Zero)
            {
                Control ctl = Control.FromHandle(handle);
                if (ctl != null)
                {
                    Type t = ctl.GetType();
                    string ctlname = t.Name.ToLower();

                    if ((ctlname == "checkbox") || (ctlname == "radiobutton") || (ctlname == "button"))
                    {
                        _cButtonSkin.Remove(handle);
                    }
                    else if (ctlname == "combobox")
                    {
                        if (_oComboSkin.ContainsKey(handle))
                            _oComboSkin[handle].Dispose();
                    }
                    else if (ctlname == "listbox")
                    {
                        if (_oListboxSkin.ContainsKey(handle))
                            _oListboxSkin[handle].Dispose();
                    }
                    else if (ctlname == "listview")
                    {
                        if (_oListviewSkin.ContainsKey(handle))
                            _oListviewSkin[handle].Dispose();
                    }
                    else if (ctlname == "numericupdown")
                    {
                        if (_oNumericUpDownSkin.ContainsKey(handle))
                            _oNumericUpDownSkin[handle].Dispose();
                    }
                    else if (ctlname == "progressbar")
                    {
                        if (_oProgressBarSkin.ContainsKey(handle))
                            _oProgressBarSkin[handle].Dispose();
                    }
                    else if (ctlname == "tabcontrol")
                    {
                        if (_oTabControlSkin.ContainsKey(handle))
                            _oTabControlSkin[handle].Dispose();
                    }
                    else if (ctlname == "trackbar")
                    {
                        if (_oTrackBarSkin.ContainsKey(handle))
                            _oTrackBarSkin[handle].Dispose();
                    }
                    else if (ctlname == "treeview")
                    {
                        if (_oTreeviewSkin.ContainsKey(handle))
                            _oTreeviewSkin[handle].Dispose();
                    }
                    ctl.Refresh();
                }
            }
        }

        /// <summary>
        /// Starts the skinning engine.
        /// </summary>
        /// <param name="Handle">Target window handle.</param>
        public void Start()
        {
            if (!ImageCheck())
                throw new Exception("Required image(s) are either missing or invalid.");

            if ((_hParentWnd == IntPtr.Zero) || (!IsWindow(_hParentWnd)))
                throw new Exception("The window handle is invalid.");
            WindowMaximized = IsZoomed(_hParentWnd);
            this.AssignHandle(_hParentWnd);
            // redraw
            InvalidateWindow();
            // force NCCALCSIZE message
            RecalculateSize();
            // redraw
            InvalidateWindow();
        }

        /// <summary>
        /// Disposes this class. Done automatically when the form is closed.
        /// </summary>
        public void Dispose()
        {
            // reset frame to original size
            _bResetSize = true;
            RecalculateSize();
            _bResetSize = false;
            this.ReleaseHandle();
            _bStoreSize = false;
            _bFirstHit = false;
            Remove(ControlType.Button);
            Remove(ControlType.CheckBox);
            Remove(ControlType.RadioButton);
            // graphics
            //if (_oTransitionMask != null)
            //    _oTransitionMask.Dispose();
            if (_oCaptionBarBitmap != null)
                _oCaptionBarBitmap.Dispose();
            if (_oLeftFrameBitmap != null)
                _oLeftFrameBitmap.Dispose();
            if (_oRightFrameBitmap != null)
                _oRightFrameBitmap.Dispose();
            if (_oBottomFrameBitmap != null)
                _oBottomFrameBitmap.Dispose();
            if (_oMinimizeButtonBitmap != null)
                _oMinimizeButtonBitmap.Dispose();
            if (_oMaximizeButtonBitmap != null)
                _oMaximizeButtonBitmap.Dispose();
            if (_oRestoreButtonBitmap != null)
                _oRestoreButtonBitmap.Dispose();
            if (_oCloseButtonBitmap != null)
                _oCloseButtonBitmap.Dispose();
            if (_oHelpButtonBitmap != null)
                _oHelpButtonBitmap.Dispose();
            // temp dc
            if (_cCaptionBarDc != null)
                _cCaptionBarDc.Dispose();
            if (_cLeftFrameDc != null)
                _cLeftFrameDc.Dispose();
            if (_cRightFrameDc != null)
                _cRightFrameDc.Dispose();
            if (_cBottomFrameDc != null)
                _cBottomFrameDc.Dispose();
            if (_cMinimizeButtonDc != null)
                _cMinimizeButtonDc.Dispose();
            if (_cMaximizeButtonDc != null)
                _cMaximizeButtonDc.Dispose();
            if (_cRestoreButtonDc != null)
                _cRestoreButtonDc.Dispose();
            if (_cCloseButtonDc != null)
                _cRestoreButtonDc.Dispose();
            if (_cHelpButtonDc != null)
                _cHelpButtonDc.Dispose();
            // resources
            if (_oTitleFont != null)
                _oTitleFont.Dispose();
            if (_cButtonSkin != null)
                _cButtonSkin.Dispose();

            if (_oComboSkin != null && _oComboSkin.Count > 0)
            {
                foreach (cComboBox cb in _oComboSkin.Values)
                    cb.Dispose();
                _oComboSkin.Clear();
            }
            if (_oListboxSkin != null && _oListboxSkin.Count > 0)
            {
                foreach (cListBox lb in _oListboxSkin.Values)
                    lb.Dispose();
                _oListboxSkin.Clear();
            }
            if (_oListviewSkin != null && _oListviewSkin.Count > 0)
            {
                foreach (cListView lv in _oListviewSkin.Values)
                    lv.Dispose();
                _oListviewSkin.Clear();
            }
            if (_oNumericUpDownSkin != null && _oNumericUpDownSkin.Count > 0)
            {
                foreach (cNumericUpDown nu in _oNumericUpDownSkin.Values)
                    nu.Dispose();
                _oNumericUpDownSkin.Clear();
            }
            if (_oProgressBarSkin != null && _oProgressBarSkin.Count > 0)
            {
                foreach (cProgressBar pb in _oProgressBarSkin.Values)
                    pb.Dispose();
                _oProgressBarSkin.Clear();
            }
            if (_oScrollbarSkin != null && _oScrollbarSkin.Count > 0)
            {
                foreach (cScrollBar sb in _oScrollbarSkin.Values)
                    sb.Dispose();
                _oScrollbarSkin.Clear();
            }
            if (_oTabControlSkin != null && _oTabControlSkin.Count > 0)
            {
                foreach (cTabControl tc in _oTabControlSkin.Values)
                    tc.Dispose();
                _oTabControlSkin.Clear();
            }
            if (_oTrackBarSkin != null && _oTrackBarSkin.Count > 0)
            {
                foreach (cTrackBar tb in _oTrackBarSkin.Values)
                    tb.Dispose();
                _oTrackBarSkin.Clear();
            }
            if (_oTreeviewSkin != null && _oTreeviewSkin.Count > 0)
            {
                foreach (cTreeView tv in _oTreeviewSkin.Values)
                    tv.Dispose();
                _oTreeviewSkin.Clear();
            }
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Private Methods
        #region Helpers
        private void AddControl(string name, IntPtr hwnd, Bitmap skin)
        {
            if ((name == "checkbox") || (name == "radiobutton") || (name == "button"))
                _cButtonSkin.Add(hwnd);
            else if (name == "combobox")
                _oComboSkin.Add(hwnd, new cComboBox(hwnd, skin, TransitionGraphic));
            else if (name == "progressbar")
                _oProgressBarSkin.Add(hwnd, new cProgressBar(hwnd, skin));
            else if (name == "numericupdown")
                _oNumericUpDownSkin.Add(hwnd, new cNumericUpDown(hwnd, skin));
        }

        private bool EnumWindow(IntPtr handle, IntPtr pointer)
        {
            GCHandle gch = GCHandle.FromIntPtr(pointer);
            List<IntPtr> list = gch.Target as List<IntPtr>;

            if (list != null)
            {
                list.Add(handle);
                return true;
            }
            return false;
        }

        private List<IntPtr> GetChildWindows(IntPtr parent)
        {
            List<IntPtr> result = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(result);
            try
            {
                EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
            }
            finally
            {
                if (listHandle.IsAllocated)
                    listHandle.Free();
            }
            return result;
        }

        private void FrameChanged()
        {
            RECT rcClient = new RECT();
            GetWindowRect(this.Handle, ref rcClient);
            // force a calc size message
            SetWindowPos(this.Handle,
                         IntPtr.Zero,
                         rcClient.Left, rcClient.Top,
                         rcClient.Right - rcClient.Left, rcClient.Bottom - rcClient.Top,
                         SWP_FRAMECHANGED);
        }

        private HIT_CONSTANTS HitTest()
        {
            RECT windowRect = new RECT();
            Point cursorPoint = new Point();

            GetCursorPos(ref cursorPoint);
            GetWindowRect(ParentWnd, ref windowRect);
            cursorPoint.X -= windowRect.Left;
            cursorPoint.Y -= windowRect.Top;

            if (CanClose)
            {
                if (PtInRect(ref _aButtonRect[2], cursorPoint))
                    return HIT_CONSTANTS.HTCLOSE;
                _iCaptionBoxStart = _aButtonRect[2].Left;
            }
            if (CanSize)
            {
                if (PtInRect(ref _aButtonRect[1], cursorPoint))
                    return HIT_CONSTANTS.HTMAXBUTTON;
                _iCaptionBoxStart = _aButtonRect[1].Left;
            }
            if (CanMinimize)
            {
                if (PtInRect(ref _aButtonRect[0], cursorPoint))
                    return HIT_CONSTANTS.HTMINBUTTON;
                _iCaptionBoxStart = _aButtonRect[0].Left;
            }
            if (CanHelp)
            {
                if (PtInRect(ref _aButtonRect[3], cursorPoint))
                    return HIT_CONSTANTS.HTHELP;
                _iCaptionBoxStart = _aButtonRect[3].Left;
            }
            windowRect = new RECT(_iCaptionBoxStart, _iFrameHeight, (windowRect.Right - windowRect.Left) - _iFrameWidth, _iCaptionHeight);
            if (PtInRect(ref windowRect, cursorPoint))
                return HIT_CONSTANTS.HTNOWHERE;

            return HIT_CONSTANTS.HTCLIENT;
        }

        private bool ImageCheck()
        {
            if (_oCaptionBarBitmap == null)
                return false;
            if (_oLeftFrameBitmap == null)
                return false;
            if (_oRightFrameBitmap == null)
                return false;
            if (_oBottomFrameBitmap == null)
                return false;
            if (CanSize)
            {
                if (_oMinimizeButtonBitmap == null)
                    return false;
                if (_oMaximizeButtonBitmap == null)
                    return false;
                if (_oRestoreButtonBitmap == null)
                    return false;
            }
            if (CanClose)
            {
                if (_oCloseButtonBitmap == null)
                    return false;
            }
            return true;
        }

        private void InvalidateWindow()
        {
            RedrawWindow(ParentWnd, IntPtr.Zero, IntPtr.Zero, RDW_FRAME | RDW_UPDATENOW | RDW_INVALIDATE | RDW_ERASE);
        }

        public void LeftClick()
        {
            // required on older os
            if (Environment.OSVersion.Version.Major < 6)
            {
                RECT rc = new RECT();
                GetWindowRect(ParentWnd, ref rc);
                Point store = Cursor.Position;
                Cursor.Position = new System.Drawing.Point(rc.Left + 24, rc.Top + 5);
                mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
                mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
                Cursor.Position = store;
            }
        }

        private bool LeftKeyPressed()
        {
            if (MouseButtonsSwitched())
                return (GetKeyState(VK_RBUTTON) < 0);
            else
                return (GetKeyState(VK_LBUTTON) < 0);
        }

        private void MaximizeWindow()
        {
            if (WindowMaximized)
            {
                //windowMessage(POST_MESSAGES.SC_RESTORE);
                SetWindowPos(ParentWnd, IntPtr.Zero, 
                    _tRestoreRect.Left, _tRestoreRect.Top,
                    _tRestoreRect.Right - _tRestoreRect.Left, _tRestoreRect.Bottom - _tRestoreRect.Top, 
                    SWP_NOACTIVATE | SWP_NOOWNERZORDER);
                WindowMaximized = false;
            }
            else
            {
                if (CanMaximize)
                {
                    RECT screenRect = new RECT();
                    GetWindowRect(ParentWnd, ref _tRestoreRect);
                    screenRect = ScreenSize();
                    if (screenRect.Right > 0)
                    {
                        InflateRect(ref screenRect, 8, 8);
                        OffsetRect(ref screenRect, -4, 4);
                        SetWindowPos(ParentWnd, IntPtr.Zero,
                            -4, -4,
                            screenRect.Right + 8, screenRect.Bottom,
                            SWP_NOACTIVATE | SWP_NOOWNERZORDER);
                    }
                    //windowMessage(POST_MESSAGES.SC_MAXIMIZE);
                    WindowMaximized = true;
                }
            }
            InvalidateWindow();
        }

        private bool MouseButtonsSwitched()
        {
            return (GetSystemMetrics(SYSTEM_METRIC.SM_SWAPBUTTON) != 0);
        }

        private RECT ScreenSize()
        {
            RECT windowRect = new RECT();
            try
            {
                SystemParametersInfo(SPI_GETWORKAREA, 0, ref windowRect, 0);
            }

            catch { }
            return windowRect; 
        }

        private void RecalculateSize()
        {
            SetWindowPos(ParentWnd, IntPtr.Zero,
                0, 0, 0, 0,
                SWP_FRAMECHANGED | SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER);
        }

        private RECT CalculateFrameSize(int x, int y, int cx, int cy)
        {
            RECT windowRect = new RECT(x, y, x + cx, y + cy);
            // subtract original frame size
            windowRect.Left -= _iFrameWidth;
            windowRect.Right += _iFrameWidth;
            windowRect.Top -= _iCaptionHeight;
            windowRect.Bottom += _iFrameHeight;
            // reset client area with new size
            windowRect.Left += (_oLeftFrameBitmap.Width / 2);
            windowRect.Right -= (_oRightFrameBitmap.Width / 2);
            windowRect.Bottom -= (_oBottomFrameBitmap.Height / 2);
            windowRect.Top += (_oCaptionBarBitmap.Height / 2);
            return windowRect;
        }

        private void StartTimer()
        {
            if (_buttonTimer > 0)
                StopTimer();
			SetTimer(ParentWnd, 66, 100, IntPtr.Zero);
        }

        private void StopTimer()
        {
            if (_buttonTimer > 0)
            {
			    KillTimer(ParentWnd, 66);
                _buttonTimer = 0;
			}
        }

        private void WindowMessage(POST_MESSAGES message)
        {
            PostMessage(ParentWnd, (uint)WM_SYSCOMMAND, (IntPtr)message, IntPtr.Zero);
        }
        #endregion

        #region Drawing
        private void DrawWindow()
        {
            int imageWidth = 0;
            int imageHeight = 0;
            int drawWidth = 0;
            int drawHeight = 0;

            RECT windowRect = new RECT();
            GetWindowRect(ParentWnd, ref windowRect);
            OffsetRect(ref windowRect, -windowRect.Left, -windowRect.Top);
            int offset = Focused ? 0 : 1;
            if (Focused)
            {

            }
            cStoreDc windowDc = new cStoreDc();
            windowDc.Height = windowRect.Bottom;
            windowDc.Width = windowRect.Right;

            using (StretchMode mode = new StretchMode(windowDc.Hdc, StretchModeEnum.STRETCH_HALFTONE))
            {
                if ((ExcludeLeftEnd == 0) && (ExcludeRightEnd == 0))
                {
                    // top
                    imageWidth = _cCaptionBarDc.Width;
                    imageHeight = (_cCaptionBarDc.Height / 2);
                    drawWidth = windowRect.Right - ((_cLeftFrameDc.Width / 2) + (_cRightFrameDc.Width / 2));
                    drawHeight = (_cCaptionBarDc.Height / 2);
                    StretchBlt(windowDc.Hdc, (_cLeftFrameDc.Width / 2), 0, drawWidth, drawHeight, _cCaptionBarDc.Hdc, 0, (imageHeight * offset), imageWidth, imageHeight, 0xCC0020);
                }
                else
                {
                    int pieceOffset = 0;
                    int centerLength = windowDc.Width - ((_cLeftFrameDc.Width / 2) + (_cRightFrameDc.Width / 2));
                    // left exclusion area
                    if (ExcludeLeftEnd > 0)
                    {
                        // draw the start
                        if (ExcludeLeftStart > 0)
                        {
                            drawWidth = ExcludeLeftStart;
                            drawHeight = (_cCaptionBarDc.Height / 2);
                            pieceOffset = (_cLeftFrameDc.Width / 2);
                            StretchBlt(windowDc.Hdc, pieceOffset, 0, drawWidth, drawHeight, _cCaptionBarDc.Hdc, 0, (imageHeight * offset), drawWidth, drawHeight, 0xCC0020);
                        }
                        imageWidth = ExcludeLeftEnd - ExcludeLeftStart;
                        imageHeight = (_cCaptionBarDc.Height / 2);
                        pieceOffset = (_cLeftFrameDc.Width / 2) + ExcludeLeftStart;
                        BitBlt(windowDc.Hdc, pieceOffset, 0, imageWidth, imageHeight, _cCaptionBarDc.Hdc, ExcludeLeftStart, (imageHeight * offset), 0xCC0020);
                        centerLength -= ExcludeLeftEnd;
                    }
                    // right exclusion area
                    if (ExcludeRightEnd > 0)
                    {
                        imageWidth = ExcludeRightEnd - ExcludeRightStart;
                        imageHeight = (_cCaptionBarDc.Height / 2);
                        pieceOffset = windowDc.Width - ((_cRightFrameDc.Width / 2) + (_cCaptionBarDc.Width - ExcludeRightStart));
                        //if (pieceOffset > 0)
                        BitBlt(windowDc.Hdc, pieceOffset, 0, imageWidth, imageHeight, _cCaptionBarDc.Hdc, ExcludeRightStart, (imageHeight * offset), 0xCC0020);
                        centerLength -= imageWidth;
                    }
                    // draw the end
                    if (ExcludeRightEnd < _cCaptionBarDc.Width)
                    {
                        drawWidth = _cCaptionBarDc.Width - ExcludeRightEnd;
                        drawHeight = (_cCaptionBarDc.Height / 2);
                        pieceOffset += (ExcludeRightEnd - ExcludeRightStart);
                        StretchBlt(windowDc.Hdc, pieceOffset, 0, drawWidth, drawHeight, _cCaptionBarDc.Hdc, 0, (imageHeight * offset), drawWidth, drawHeight, 0xCC0020);
                        centerLength -= drawWidth;
                    }
                    // draw the center
                    if (ExcludeRightStart > 0)
                        imageWidth = _cCaptionBarDc.Width - (ExcludeRightStart - ExcludeLeftEnd);
                    else
                        imageWidth = _cCaptionBarDc.Width - ExcludeLeftEnd;

                    imageHeight = (_cCaptionBarDc.Height / 2);
                    pieceOffset = (_cLeftFrameDc.Width / 2) + ExcludeLeftEnd;
                    drawWidth = centerLength;
                    drawHeight = (_cCaptionBarDc.Height / 2);
                    StretchBlt(windowDc.Hdc, pieceOffset, 0, drawWidth, drawHeight, _cCaptionBarDc.Hdc, ExcludeLeftEnd, (imageHeight * offset), imageWidth, imageHeight, 0xCC0020);
                }

                // left
                imageWidth = (_cLeftFrameDc.Width / 2);
                imageHeight = _cLeftFrameDc.Height - ((_cCaptionBarDc.Height / 2) + (_cBottomFrameDc.Height / 2));
                drawWidth = (_cLeftFrameDc.Width / 2);
                drawHeight = windowRect.Bottom - ((_cCaptionBarDc.Height / 2) + (_cBottomFrameDc.Height / 2));
                StretchBlt(windowDc.Hdc, 0, (_cCaptionBarDc.Height / 2), drawWidth, drawHeight, _cLeftFrameDc.Hdc, (imageWidth * offset), (_cCaptionBarDc.Height / 2), imageWidth, imageHeight, 0xCC0020);
                //right
                imageWidth = (_cRightFrameDc.Width / 2);
                imageHeight = _cRightFrameDc.Height - ((_cCaptionBarDc.Height / 2) + (_cBottomFrameDc.Height / 2));
                drawWidth = (_cRightFrameDc.Width / 2);
                drawHeight = windowRect.Bottom - ((_cCaptionBarDc.Height / 2) + (_cBottomFrameDc.Height / 2));
                StretchBlt(windowDc.Hdc, (windowRect.Right - imageWidth), (_cCaptionBarDc.Height / 2), drawWidth, drawHeight, _cRightFrameDc.Hdc, (imageWidth * offset), (_cCaptionBarDc.Height / 2), imageWidth, imageHeight, 0xCC0020);
                // bottom
                imageWidth = _cBottomFrameDc.Width;
                imageHeight = (_cBottomFrameDc.Height / 2);
                drawWidth = windowRect.Right - ((_cLeftFrameDc.Width / 2) + (_cRightFrameDc.Width / 2));
                drawHeight = (_cBottomFrameDc.Height / 2);
                StretchBlt(windowDc.Hdc, (_cLeftFrameDc.Width / 2), windowRect.Bottom - (_cBottomFrameDc.Height / 2), drawWidth, drawHeight, _cBottomFrameDc.Hdc, 0, (imageHeight * offset), imageWidth, imageHeight, 0xCC0020);
            }
            // top left
            imageWidth = (_cLeftFrameDc.Width / 2);
            imageHeight = (_cCaptionBarDc.Height / 2);
            BitBlt(windowDc.Hdc, 0, 0, imageWidth, imageHeight, _cLeftFrameDc.Hdc, (imageWidth * offset), 0, 0xCC0020);
            // top right
            imageWidth = (_cRightFrameDc.Width / 2);
            imageHeight = (_cCaptionBarDc.Height / 2);
            BitBlt(windowDc.Hdc, (windowRect.Right - imageWidth), 0, imageWidth, imageHeight, _cRightFrameDc.Hdc, (imageWidth * offset), 0, 0xCC0020);
            // bottom left
            imageWidth = (_cLeftFrameDc.Width / 2);
            imageHeight = (_cBottomFrameDc.Height / 2);
            BitBlt(windowDc.Hdc, 0, (windowRect.Bottom - imageHeight), imageWidth, imageHeight, _cLeftFrameDc.Hdc, (imageHeight * offset), (_cLeftFrameDc.Height - imageHeight), 0xCC0020);
            // bottom right
            imageWidth = (_cRightFrameDc.Width / 2);
            imageHeight = (_cBottomFrameDc.Height / 2);
            BitBlt(windowDc.Hdc, (windowRect.Right - imageWidth), (windowRect.Bottom - imageHeight), imageWidth, imageHeight, _cRightFrameDc.Hdc, (imageHeight * offset), (_cRightFrameDc.Height - imageHeight), 0xCC0020);

            RECT captionRect = new RECT(0, 0, windowDc.Width, _cCaptionBarDc.Height / 2);

            DrawButtons(windowDc.Hdc, captionRect);
            DrawIcon(windowDc.Hdc, captionRect);
            DrawTitle(windowDc.Hdc, captionRect);

            // exclude client area
            imageWidth = (_cLeftFrameDc.Width / 2);
            imageHeight = (_cCaptionBarDc.Height / 2);
            //drawWidth = windowRect.Right - ((_leftFrameDc.Width / 2) + (_rightFrameDc.Width / 2));
            //drawHeight = windowRect.Bottom - ((_captionBarDc.Height / 2) + (_bottomFrameDc.Height / 2));
            drawWidth = ((_cLeftFrameDc.Width / 2) + (_cRightFrameDc.Width / 2));
            drawHeight = ((_cCaptionBarDc.Height / 2) + (_cBottomFrameDc.Height / 2));
            IntPtr hdc = GetWindowDC(ParentWnd);
            RECT clientRect = new RECT();
            GetWindowRect(ParentWnd, ref clientRect);
            OffsetRect(ref clientRect, -clientRect.Left, -clientRect.Top);
            OffsetRect(ref clientRect, -drawWidth, -drawHeight);

            ExcludeClipRect(hdc, imageWidth, imageHeight, clientRect.Right + imageWidth, clientRect.Bottom + imageHeight);
            // blit to window
            BitBlt(hdc, 0, 0, windowRect.Right, windowRect.Bottom, windowDc.Hdc, 0, 0, 0xCC0020);
            
            // clean up
            ReleaseDC(ParentWnd, hdc);
            windowDc.Dispose();
        }

        private void DrawButtons(IntPtr hdc, RECT captionRect)
        {
            int offset = 0;
            int width = 0;
            int height = 0;
            int left = 0;
            HIT_CONSTANTS buttonHit = HitTest();
            int topOffset = 0;
            if(!Focused)
                topOffset = _cCloseButtonDc.Height /2;
            if (CanClose)
            {
                // close button
                _aButtonRect[2].Right = captionRect.Right - _iButtonOffsetX;
                _aButtonRect[2].Left = _aButtonRect[2].Right - (_cCloseButtonDc.Width / 3);
                _aButtonRect[2].Top = (((_cCaptionBarDc.Height / 2) - (_cCloseButtonDc.Height /2)) / 2) + _iButtonOffsetY;
                _aButtonRect[2].Bottom = _aButtonRect[2].Top + _cCloseButtonDc.Height / 2;

                if (buttonHit == HIT_CONSTANTS.HTCLOSE)
                {
                    if (LeftKeyPressed())
                        offset = (_cCloseButtonDc.Width / 3) * 2;
                    else
                        offset = (_cCloseButtonDc.Width / 3);
                }
                width = _aButtonRect[2].Right - _aButtonRect[2].Left;
                height = _cCloseButtonDc.Height /2;
                BitBlt(hdc, _aButtonRect[2].Left, _aButtonRect[2].Top, width, height, _cCloseButtonDc.Hdc, offset, topOffset, 0xCC0020);
                left = _aButtonRect[2].Left - width;
            }
            if (CanSize)
            {
                // maximize
                _aButtonRect[1].Right = _aButtonRect[2].Left - 1;
                _aButtonRect[1].Left = _aButtonRect[1].Right - (_cMaximizeButtonDc.Width / 3);
                _aButtonRect[1].Top = _aButtonRect[2].Top;
                _aButtonRect[1].Bottom = _aButtonRect[2].Bottom;
                width = _aButtonRect[1].Right - _aButtonRect[1].Left;
                height = _cMaximizeButtonDc.Height /2;
                offset = 0;
                if (buttonHit == HIT_CONSTANTS.HTMAXBUTTON)
                {
                    if (LeftKeyPressed())
                        offset = (_cMaximizeButtonDc.Width / 3) * 2;
                    else
                        offset = (_cMaximizeButtonDc.Width / 3);
                }
                if (WindowMaximized)
                    BitBlt(hdc, _aButtonRect[1].Left, _aButtonRect[1].Top, width, height, _cRestoreButtonDc.Hdc, offset, topOffset, 0xCC0020);
                else
                    BitBlt(hdc, _aButtonRect[1].Left, _aButtonRect[1].Top, width, height, _cMaximizeButtonDc.Hdc, offset, topOffset, 0xCC0020);
                left = _aButtonRect[1].Left - width;
            }
            if (CanMinimize)
            {
                // minimize
                if (CanSize)
                {
                    _aButtonRect[0].Right = _aButtonRect[1].Left - 1;
                    _aButtonRect[0].Left = _aButtonRect[0].Right - (_cMinimizeButtonDc.Width / 3);
                    _aButtonRect[0].Top = _aButtonRect[1].Top;
                    _aButtonRect[0].Bottom = _aButtonRect[1].Bottom;
                    width = _aButtonRect[0].Right - _aButtonRect[0].Left;
                    height = _cMinimizeButtonDc.Height /2;
                }
                else
                {
                    _aButtonRect[0].Right = _aButtonRect[2].Left - 1;
                    _aButtonRect[0].Left = _aButtonRect[0].Right - (_cMinimizeButtonDc.Width / 3);
                    _aButtonRect[0].Top = _aButtonRect[2].Top;
                    _aButtonRect[0].Bottom = _aButtonRect[2].Bottom;
                    width = _aButtonRect[0].Right - _aButtonRect[0].Left;
                    height = _cMinimizeButtonDc.Height /2;
                }
                offset = 0;
                if (buttonHit == HIT_CONSTANTS.HTMINBUTTON)
                {
                    if (LeftKeyPressed())
                        offset = (_cMinimizeButtonDc.Width / 3) * 2;
                    else
                        offset = (_cMinimizeButtonDc.Width / 3);
                }
                BitBlt(hdc, _aButtonRect[0].Left, _aButtonRect[0].Top, width, height, _cMinimizeButtonDc.Hdc, offset, topOffset, 0xCC0020);
                left = _aButtonRect[0].Left - width;
            }
            if (CanHelp)
            {
                // help/user button
                _aButtonRect[3].Left = left - 1;
                _aButtonRect[3].Right = _aButtonRect[3].Left + (_cHelpButtonDc.Width / 3);
                _aButtonRect[3].Top = _aButtonRect[2].Top;
                _aButtonRect[3].Bottom = _aButtonRect[2].Bottom;
                width = _aButtonRect[3].Right - _aButtonRect[3].Left;
                height = _cHelpButtonDc.Height /2;
                offset = 0;
                if (buttonHit == HIT_CONSTANTS.HTHELP)
                {
                    if (LeftKeyPressed())
                        offset = (_cHelpButtonDc.Width / 3) * 2;
                    else
                        offset = (_cHelpButtonDc.Width / 3);
                }
                BitBlt(hdc, _aButtonRect[3].Left, _aButtonRect[3].Top, width, height, _cHelpButtonDc.Hdc, offset, topOffset, 0xCC0020);
            }
        }

        private void DrawIcon(IntPtr hdc, RECT captionRect)
        {
            IntPtr hIcon = SendMessage(ParentWnd, WM_GETICON, IntPtr.Zero, IntPtr.Zero);
            _iIconSize = 0;
            if (hIcon != IntPtr.Zero)
            {
                _iIconSize = GetSystemMetrics(SYSTEM_METRIC.SM_CXSMICON);
                int top = (captionRect.Bottom - _iIconSize) / 2;
                int left = (_cLeftFrameDc.Width / 2);
                top += IconOffsetY;
                left += IconOffsetX;
                DrawIconEx(hdc, left, top, hIcon, _iIconSize, _iIconSize, 0, IntPtr.Zero, DI_NORMAL);
            }
        }

        private void DrawTitle(IntPtr hdc, RECT captionRect)
        {
            int len = GetWindowTextLength(ParentWnd);
            if (len > 0)
            {
                StringBuilder title = new StringBuilder(len + 1);
                GetWindowText(ParentWnd, title, title.Capacity);
                if (title.Length > 0)
                {
                    using (Graphics g = Graphics.FromHdc(hdc))
                    {
                        Rectangle captionBounds = new Rectangle();
                        captionBounds.X = (_cLeftFrameDc.Width / 2) + ((_iIconSize > 0) ? _iIconSize + 4 : 0) + _iIconOffsetX;
                        captionBounds.Width = _iCaptionBoxStart - captionBounds.X;
                        captionBounds.Y = _iTitleOffsetY;
                        captionBounds.Height = captionRect.Bottom;
                        using (StringFormat sf = new StringFormat())
                        {
                            sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
                            sf.FormatFlags = StringFormatFlags.NoWrap;
                            sf.Alignment = StringAlignment.Near;
                            sf.LineAlignment = StringAlignment.Center;
                            using (Brush ht = new SolidBrush(ForeColor))
                                g.DrawString(title.ToString(), _oTitleFont, ht, captionBounds, sf);
                        }
                    }
                }
            }

        }
        #endregion
        #endregion

        #region WndProc
        protected override void WndProc(ref Message m)
        {
            Console.WriteLine(m.Msg.ToString());
            switch (m.Msg)
            {
                //case WM_LMOUSEBUTTONDOWN:
                //    InvalidateWindow();
                //    break;
                case WM_INITMENU:
                    base.WndProc(ref m);
                    InvalidateWindow();
                    break;

                case WM_INITMENUPOPUP:
                case WM_EXITMENULOOP:
                    base.WndProc(ref m);
                    InvalidateWindow();
                    break;

                case WM_NCACTIVATE:
                    if (!_bFirstHit)
                    {
                        _bFirstHit = true;
                        LeftClick();
                    }
                    if (m.WParam == IntPtr.Zero)
                        m.Result = MESSAGE_HANDLED;
                    InvalidateWindow();
                    break;

                case WM_SETCURSOR:
                    m.Result = MESSAGE_PROCESS;
                    if (!WindowMaximized)
                        base.WndProc(ref m);
                    InvalidateWindow();
                    break;

                case WM_NCCALCSIZE:
                    if (m.WParam != IntPtr.Zero)
                    {
                        NCCALCSIZE_PARAMS ncsize = (NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NCCALCSIZE_PARAMS));
                        WINDOWPOS wp = (WINDOWPOS)Marshal.PtrToStructure(ncsize.lppos, typeof(WINDOWPOS));
                        // store original frame sizes
                        if (!_bStoreSize)
                        {
                            _bStoreSize = true;
                            _iCaptionHeight = ncsize.rect2.Top - ncsize.rect0.Top;
                            _iFrameHeight = ncsize.rect0.Bottom - ncsize.rect2.Bottom;
                            _iFrameWidth = ncsize.rect2.Left - ncsize.rect0.Left;
                        }
                        if (!_bResetSize)
                        {
                            ncsize.rect0 = CalculateFrameSize(wp.x, wp.y, wp.cx, wp.cy);
                            ncsize.rect1 = ncsize.rect0;
                        }
                        Marshal.StructureToPtr(ncsize, m.LParam, false);
                        m.Result = (IntPtr)WVR_VALIDRECTS;
                    }
                    else
                    {
                        RECT rc = (RECT)m.GetLParam(typeof(RECT));
                        rc = CalculateFrameSize(rc.Left, rc.Top, rc.Right - rc.Left, rc.Bottom - rc.Top); ;
                        Marshal.StructureToPtr(rc, m.LParam, true);
                        m.Result = MESSAGE_PROCESS;
                    }
                    base.WndProc(ref m);
                    
                    break;

                case WM_NCDESTROY:
                    Dispose();
                    base.WndProc(ref m);
                    break;

                case WM_NCHITTEST:
                    _eLastWindowHit = (HIT_CONSTANTS)DefWindowProc(m.HWnd, m.Msg, m.WParam, m.LParam);
                    _eLastButtonHit = HitTest();
                    if ((_eLastButtonHit == HIT_CONSTANTS.HTCLOSE) ||
                        (_eLastButtonHit == HIT_CONSTANTS.HTMAXBUTTON) ||
                        (_eLastButtonHit == HIT_CONSTANTS.HTMINBUTTON) ||
                        (_eLastButtonHit == HIT_CONSTANTS.HTHELP) ||
                        (_eLastButtonHit == HIT_CONSTANTS.HTNOWHERE))
                    {
                        if (this.SupressHelpTip && _eLastButtonHit == HIT_CONSTANTS.HTHELP && !LeftKeyPressed())
                            m.Result = (IntPtr)HIT_CONSTANTS.HTCAPTION;
                        else
                            m.Result = (IntPtr)_eLastButtonHit;
                    }
                    else
                    {
                        m.Result = (IntPtr)_eLastWindowHit;
                        base.WndProc(ref m);
                    }
                    break;

                case WM_NCRBUTTONDBLCLK:
                case WM_NCLBUTTONDBLCLK:
                    if (((MouseButtonsSwitched()) && (m.Msg == WM_NCRBUTTONDBLCLK)) ||
                        ((!MouseButtonsSwitched()) && (m.Msg == WM_NCLBUTTONDBLCLK)))
                    {
                        if (_eLastWindowHit == HIT_CONSTANTS.HTCAPTION)
                            MaximizeWindow();
                        else
                            base.WndProc(ref m);
                    }
                    else
                    {
                        base.WndProc(ref m);
                    }
                    break;

                case WM_NCRBUTTONDOWN:
                case WM_NCLBUTTONDOWN:
                    if (((MouseButtonsSwitched()) && (m.Msg == WM_NCRBUTTONDOWN)) ||
                        ((!MouseButtonsSwitched()) && (m.Msg == WM_NCLBUTTONDOWN)))
                    {
                        _eLastButtonHit = HitTest();
                        if ((_eLastButtonHit == HIT_CONSTANTS.HTCLOSE) ||
                            (_eLastButtonHit == HIT_CONSTANTS.HTMAXBUTTON) ||
                            (_eLastButtonHit == HIT_CONSTANTS.HTMINBUTTON) ||
                            (_eLastButtonHit == HIT_CONSTANTS.HTHELP))
                        {
                            m.Result = (IntPtr)MESSAGE_HANDLED;
                        }
                        else
                        {
                            if ((_eLastWindowHit == HIT_CONSTANTS.HTCLOSE) ||
                                (_eLastWindowHit == HIT_CONSTANTS.HTMAXBUTTON) ||
                                (_eLastWindowHit == HIT_CONSTANTS.HTMINBUTTON) ||
                                (_eLastButtonHit == HIT_CONSTANTS.HTHELP))
                            {
                                InvalidateWindow();
                            }
                            else
                            {
                                base.WndProc(ref m);
                            }
                        }
                    }
                    else
                    {
                        base.WndProc(ref m);
                    }
                    InvalidateWindow();
                    break;

                case WM_NCRBUTTONUP:
                case WM_NCLBUTTONUP:
                    if (((MouseButtonsSwitched()) && (m.Msg == WM_NCRBUTTONUP)) ||
                        ((!MouseButtonsSwitched()) && (m.Msg == WM_NCLBUTTONUP)))
                    {
                        if (_eLastButtonHit == HIT_CONSTANTS.HTCLOSE)
                            WindowMessage(POST_MESSAGES.SC_CLOSE);
                        else if (_eLastButtonHit == HIT_CONSTANTS.HTMINBUTTON)
                            WindowMessage(POST_MESSAGES.SC_MINIMIZE);
                        else if (_eLastButtonHit == HIT_CONSTANTS.HTMAXBUTTON)
                            MaximizeWindow();
                        else if (_eLastButtonHit == HIT_CONSTANTS.HTHELP)
                        {
                            if (HelpClicked != null)
                                HelpClicked(this, new EventArgs());
                        }
                        else
                            base.WndProc(ref m);
                    }
                    else
                    {
                        base.WndProc(ref m);
                    }
                    InvalidateWindow();
                    break;

                case WM_NCMOUSEMOVE:
                    _eLastButtonHit = HitTest();
                    if ((_eLastButtonHit == HIT_CONSTANTS.HTCLOSE) ||
                        (_eLastButtonHit == HIT_CONSTANTS.HTMAXBUTTON) ||
                        (_eLastButtonHit == HIT_CONSTANTS.HTMINBUTTON) ||
                        (_eLastButtonHit == HIT_CONSTANTS.HTHELP))
                    {
                        StartTimer();
                        InvalidateWindow();
                    }
                    base.WndProc(ref m);
                    break;

                case WM_NCPAINT:
                    if (IsWindowVisible(ParentWnd))
                        DrawWindow();
                    break;

                case WM_TIMER:
                    _buttonTimer += 1;
                    HIT_CONSTANTS hitTimer = HitTest();
                    if ((hitTimer == HIT_CONSTANTS.HTCLOSE) ||
                        (hitTimer == HIT_CONSTANTS.HTMAXBUTTON) ||
                        (hitTimer == HIT_CONSTANTS.HTMINBUTTON) ||
                        (hitTimer == HIT_CONSTANTS.HTHELP))
                    {
                        if (hitTimer != _eLastButtonHit)
                        {
                            StopTimer();
                            InvalidateWindow();
                        }
                        else
                        {
                            if (_buttonTimer > 500)
                                StopTimer();
                        }
                    }
                    else
                    {
                        if (!LeftKeyPressed())
                        {
                            StopTimer();
                            InvalidateWindow();
                        }
                    }
                    base.WndProc(ref m);
                    break;

                case WM_ACTIVATE:
                    _isActive = 
                        ((int)WM_ACTIVATE == (int)m.WParam || (int)WM_CLICKACTIVE == (int)m.WParam);
                    break;
                case WM_ACTIVATEAPP:
                    _isActive = (int) m.WParam != 0;
                    break;
                case WM_MDIACTIVATE:
                    if (m.WParam == _hParentWnd)
                        _isActive = false;
                    else if (m.LParam == _hParentWnd)
                        _isActive = true;
                    break;
                case WM_KILLFOCUS:
                case WM_SETFOCUS:
                case WM_DISPLAYCHANGE:
                case WM_STYLECHANGED:
                case WM_SETTEXT:
                    InvalidateWindow();
                    base.WndProc(ref m);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        #endregion
    }
}

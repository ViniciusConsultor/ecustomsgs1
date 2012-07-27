// UXTHEME.H +
// http://msdn.microsoft.com/en-us/library/bb773187(VS.85).aspx
// MAINTAINED FOR A FUTURE RELEASE - NOT USED IN V. 1.1
namespace System.Windows.Forms.RCM
{
    #region Directives
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Text;
    #endregion

    internal class cThemeManager : IDisposable
    {
        #region Contants
        private const int MAX_PATH = 260;
        private const int COLOR_GRADIENTINACTIVECAPTION = 28;
        #endregion

        #region Enums
        /// <summary>
        ///  "Window" (i.e., non-client) Parts
        /// </summary>
        public enum UxThemeWindowParts : int
        {
             /// <summary>Caption</summary>
             WP_CAPTION = 1,
             /// <summary>Small Caption</summary>
             WP_SMALLCAPTION = 2,
             /// <summary>Minimised Caption</summary>
             WP_MINCAPTION = 3,
             /// <summary>Small minimised Caption</summary>
             WP_SMALLMINCAPTION = 4,
             /// <summary>Maximised Caption</summary>
             WP_MAXCAPTION = 5,
             /// <summary>Small maximised Caption</summary>
             WP_SMALLMAXCAPTION = 6,
             /// <summary>Frame left</summary>
             WP_FRAMELEFT = 7,
             /// <summary>Frame right</summary>
             WP_FRAMERIGHT = 8,
             /// <summary>Frame bottom</summary>
             WP_FRAMEBOTTOM = 9,
             /// <summary>Small frame left</summary>
             WP_SMALLFRAMELEFT = 10,
             /// <summary>Small frame right</summary>
             WP_SMALLFRAMERIGHT = 11,
             /// <summary>Small frame bottom</summary>
             WP_SMALLFRAMEBOTTOM = 12,
             /// <summary>System button</summary>
             WP_SYSBUTTON = 13,
             /// <summary>MDI System button</summary>
             WP_MDISYSBUTTON = 14,
             /// <summary>Min button</summary>
             WP_MINBUTTON = 15,
             /// <summary>MDI Min button</summary>
             WP_MDIMINBUTTON = 16,
             /// <summary>Max button</summary>
             WP_MAXBUTTON = 17,
             /// <summary>Close button</summary>
             WP_CLOSEBUTTON = 18,
             /// <summary>Small close button</summary>
             WP_SMALLCLOSEBUTTON = 19,
             /// <summary>MDI close button</summary>
             WP_MDICLOSEBUTTON = 20,
             /// <summary>Restore button</summary>
             WP_RESTOREBUTTON = 21,
             /// <summary>MDI Restore button</summary>
             WP_MDIRESTOREBUTTON = 22,
             /// <summary>Help button</summary>
             WP_HELPBUTTON = 23,
             /// <summary>MDI Help button</summary>
             WP_MDIHELPBUTTON = 24,
             /// <summary>Horizontal scroll bar</summary>
             WP_HORZSCROLL = 25,
             /// <summary>Horizontal scroll thumb</summary>
             WP_HORZTHUMB = 26,
             /// <summary>Vertical scroll bar</summary>
             WP_VERTSCROLL = 27,
             /// <summary>Vertical scroll thumb</summary>
             WP_VERTTHUMB = 28,
             /// <summary>Dialog</summary>
             WP_DIALOG = 29,
             /// <summary>Caption sizing hittest template</summary>
             WP_CAPTIONSIZINGTEMPLATE = 30,
             /// <summary>Small caption sizing hittest template</summary>
             WP_SMALLCAPTIONSIZINGTEMPLATE = 31,
             /// <summary>Frame left sizing hittest template</summary>
             WP_FRAMELEFTSIZINGTEMPLATE = 32,
             /// <summary>Small frame left sizing hittest template</summary>
             WP_SMALLFRAMELEFTSIZINGTEMPLATE = 33,
             /// <summary>Frame right sizing hittest template</summary>
             WP_FRAMERIGHTSIZINGTEMPLATE = 34,
             /// <summary>Small frame right sizing hittest template</summary>
             WP_SMALLFRAMERIGHTSIZINGTEMPLATE = 35,
             /// <summary>Frame button sizing hittest template</summary>
             WP_FRAMEBOTTOMSIZINGTEMPLATE = 36,
             /// <summary>Small frame bottom sizing hittest template</summary>
             WP_SMALLFRAMEBOTTOMSIZINGTEMPLATE = 37
        }

        /// <summary>
        /// Frame states
        /// </summary>
        public enum UxThemeFrameStates : int
        {
            /// <summary>Active frame</summary>
            FS_ACTIVE = 1,
            /// <summary>Inactive frame</summary>
            FS_INACTIVE = 2
        }

        /// <summary>
        /// Caption states
        /// </summary>
        public enum UxThemeCaptionStates : int
        {
            /// <summary>Active caption</summary>
            CS_ACTIVE = 1,
            /// <summary>Inactive caption</summary>
            CS_INACTIVE = 2,
            /// <summary>Disabled caption</summary>
            CS_DISABLED = 3
        }

        /// <summary>
        /// Maximised caption states
        /// </summary>
        public enum UxThemeMaxCaptionStates : int
        {
            /// <summary>Max Active caption</summary>
            MXCS_ACTIVE = 1,
            /// <summary>Max inactive caption</summary>
            MXCS_INACTIVE = 2,
            /// <summary>Max disabled caption</summary>
            MXCS_DISABLED = 3
        }

        /// <summary>
        /// Minimised caption states
        /// </summary>
        public enum UxThemeMinCaptionStates : int
        {
            /// <summary>Minimised active caption</summary>
            MNCS_ACTIVE = 1,
            /// <summary>Minimised inactive caption</summary>
            MNCS_INACTIVE = 2,
            /// <summary>Minimised disabled caption</summary>
            MNCS_DISABLED = 3
        }

        /// <summary>
        /// Horizontal scroll states
        /// </summary>
        public enum UxThemeHorzScrollStates : int
        {         
            /// <summary>Normal</summary>
            HSS_NORMAL = 1,
            /// <summary>Hot</summary>
            HSS_HOT = 2,
            /// <summary>Pushed</summary>
            HSS_PUSHED = 3,
            /// <summary>Disabled</summary>
            HSS_DISABLED = 4
        }

        /// <summary>
        /// Horizontal thumb states
        /// </summary>
        public enum UxThemeHorzThumbStates : int
        {
            /// <summary>Normal</summary>
            HTS_NORMAL = 1,
            /// <summary>Hot</summary>
            HTS_HOT = 2,
            /// <summary>Pushed</summary>
            HTS_PUSHED = 3,
            /// <summary>Disabled</summary>
            HTS_DISABLED = 4
        }

        /// <summary>
        /// Vertical scroll states
        /// </summary>
        public enum UxThemeVertScrollStates : int
        {
            /// <summary>Normal</summary>
            VSS_NORMAL = 1,
            /// <summary>Hot</summary>
            VSS_HOT = 2,
            /// <summary>Pushed</summary>
            VSS_PUSHED = 3,
            /// <summary>Disabled</summary>
            VSS_DISABLED = 4
        }

        /// <summary>
        /// Vertical thumb states
        /// </summary>
        public enum UxThemeVertThumbStates : int
        {
            /// <summary>Normal</summary>
            VTS_NORMAL = 1,
            /// <summary>Hot</summary>
            VTS_HOT = 2,
            /// <summary>Pushed</summary>
            VTS_PUSHED = 3,
            /// <summary>Disabled</summary>
            VTS_DISABLED = 4
        }

        /// <summary>
        /// System Button states
        /// </summary>
        public enum UxThemeSysButtonStates : int
        {
            /// <summary>Normal</summary>
            SBS_NORMAL = 1,
            /// <summary>Hot</summary>
            SBS_HOT = 2,
            /// <summary>Pushed</summary>
            SBS_PUSHED = 3,
            /// <summary>Disabled</summary>
            SBS_DISABLED = 4
        }

        /// <summary>
        /// Min Button states
        /// </summary>
        public enum UxThemeMinButtonStates : int
        {
            /// <summary>Normal</summary>
            MINBS_NORMAL = 1,
            /// <summary>Hot</summary>
            MINBS_HOT = 2,
            /// <summary>Pushed</summary>
            MINBS_PUSHED = 3,
            /// <summary>Disabled</summary>
            MINBS_DISABLED = 4
        }

        /// <summary>
        /// Max Button states
        /// </summary>
        public enum UxThemeMaxButtonStates :  int
        {
            /// <summary>Normal</summary>
            MAXBS_NORMAL = 1,
            /// <summary>Hot</summary>
            MAXBS_HOT = 2,
            /// <summary>Pushed</summary>
            MAXBS_PUSHED = 3,
            /// <summary>Disabled</summary>
            MAXBS_DISABLED = 4
        }

        /// <summary>
        /// Restore button states
        /// </summary>
        public enum UxThemeRestoreButtonStates : int
        {
            /// <summary>Normal</summary>
            RBS_NORMAL = 1,
            /// <summary>Hot</summary>
            RBS_HOT = 2,
            /// <summary>Pushed</summary>
            RBS_PUSHED = 3,
            /// <summary>Disabled</summary>
            RBS_DISABLED = 4
        }

        /// <summary>
        /// Help button states
        /// </summary>
        public enum UxThemeHelpButtonStates : int
        {
            /// <summary>Normal</summary>
            HBS_NORMAL = 1,
            /// <summary>Hot</summary>
            HBS_HOT = 2,
            /// <summary>Pushed</summary>
            HBS_PUSHED = 3,
            /// <summary>Disabled</summary>
            HBS_DISABLED = 4,
        }

        /// <summary>
        /// Closed button states
        /// </summary>
        public enum UxThemeCloseButtonStates : int
        {
            /// <summary>Normal</summary>
            CBS_NORMAL = 1,
            /// <summary>Hot</summary>
            CBS_HOT = 2,
            /// <summary>Pushed</summary>
            CBS_PUSHED = 3,
            /// <summary>Disabled</summary>
            CBS_DISABLED = 4
        }


        /// <summary>
        ///  "Button" Parts
        /// </summary>
        public enum UxThemeButtonParts : int
        {
            /// <summary>Push Button</summary>
            BP_PUSHBUTTON = 1,
            /// <summary>Radio Button</summary>
            BP_RADIOBUTTON = 2,
            /// <summary>Check box</summary>
            BP_CHECKBOX = 3,
            /// <summary>Group box</summary>
            BP_GROUPBOX = 4,
            /// <summary>User button</summary>
            BP_USERBUTTON = 5
        }

        /// <summary>
        /// Push Button states
        /// </summary>
        public enum UxThemePushButtonStates : int
        {
            /// <summary>Normal</summary>
            PBS_NORMAL = 1,
            /// <summary>Hot</summary>
            PBS_HOT = 2,
            /// <summary>Pressed</summary>
            PBS_PRESSED = 3,
            /// <summary>Disabled</summary>
            PBS_DISABLED = 4,
            /// <summary>Defaulted</summary>
            PBS_DEFAULTED = 5
        }

        /// <summary>
        /// Radio button states
        /// </summary>
        public enum UxThemeRadioButtonStates : int
        {
            /// <summary>Unchecked Normal</summary>
            RBS_UNCHECKEDNORMAL = 1,
            /// <summary>Unchecked Hot</summary>
            RBS_UNCHECKEDHOT = 2,
            /// <summary>Unchecked Pressed</summary>
            RBS_UNCHECKEDPRESSED = 3,
            /// <summary>Unchecked Disabled</summary>
            RBS_UNCHECKEDDISABLED = 4,
            /// <summary>Checked Normal</summary>
            RBS_CHECKEDNORMAL = 5,
            /// <summary>Checked Hot</summary>
            RBS_CHECKEDHOT = 6,
            /// <summary>Checked Pressed</summary>
            RBS_CHECKEDPRESSED = 7,
            /// <summary>Checked Disabled</summary>
            RBS_CHECKEDDISABLED = 8
        }

        /// <summary>
        /// Check box states
        /// </summary>
        public enum UxThemeCheckBoxStates : int 
        {
            /// <summary>Unchecked Normal</summary>
            CBS_UNCHECKEDNORMAL = 1,
            /// <summary>Unchecked Hot</summary>
            CBS_UNCHECKEDHOT = 2,
            /// <summary>Unchecked Pressed</summary>
            CBS_UNCHECKEDPRESSED = 3,
            /// <summary>Unchecked Disabled</summary>
            CBS_UNCHECKEDDISABLED = 4,
            /// <summary>Checked Normal</summary>
            CBS_CHECKEDNORMAL = 5,
            /// <summary>Checked Hot</summary>
            CBS_CHECKEDHOT = 6,
            /// <summary>Checked Pressed</summary>
            CBS_CHECKEDPRESSED = 7,
            /// <summary>Checked Disabled</summary>
            CBS_CHECKEDDISABLED = 8,
            /// <summary>Mixed Normal</summary>
            CBS_MIXEDNORMAL = 9,
            /// <summary>Mixed Hot</summary>
            CBS_MIXEDHOT = 10,
            /// <summary>Mixed Pressed</summary>
            CBS_MIXEDPRESSED = 11,
            /// <summary>Mixed Disabled</summary>
            CBS_MIXEDDISABLED = 12
        }

        /// <summary>
        /// Group box states
        /// </summary>
        public enum UxThemeGroupBoxStates : int 
        {
            /// <summary>Normal</summary>
            GBS_NORMAL = 1,
            /// <summary>Disabled</summary>
            GBS_DISABLED = 2
        }


        /// <summary>
        /// "Rebar" Parts
        /// </summary>
        public enum UxThemeRebarParts : int
        {
            /// <summary>Gripper</summary>
            RP_GRIPPER = 1,
            /// <summary>Vertical Gripper</summary>
            RP_GRIPPERVERT = 2,
            /// <summary>Band</summary>
            RP_BAND = 3,
            /// <summary>Chevron</summary>
            RP_CHEVRON = 4,
            /// <summary>Vertical Chevron</summary>
            RP_CHEVRONVERT = 5
        }

        /// <summary>
        /// Chevron states
        /// </summary>
        public enum UxThemeChevronStates : int 
        {
            /// <summary>Normal</summary>
            CHEVS_NORMAL = 1,
            /// <summary>Hot</summary>
            CHEVS_HOT = 2,
            /// <summary>Pressed</summary>
            CHEVS_PRESSED = 3
        }


        /// <summary>
        ///  "Toolbar" Parts
        /// </summary>
        public enum UxThemeToolBarParts : int
        {
            /// <summary>Button</summary>
            TP_BUTTON = 1,
            /// <summary>Drop-Down Button</summary>
            TP_DROPDOWNBUTTON = 2,
            /// <summary>Split Button</summary>
            TP_SPLITBUTTON = 3,
            /// <summary>Split drop-Down Button</summary>
            TP_SPLITBUTTONDROPDOWN = 4,
            /// <summary>Separator</summary>
            TP_SEPARATOR = 5,
            /// <summary>Vertical Separator</summary>
            TP_SEPARATORVERT = 6
        }


        /// <summary>
        /// Tool bar states
        /// </summary>
        public enum UxThemeToolBarStates : int
        {
            /// <summary>Normal</summary>
            TS_NORMAL = 1,
            /// <summary>Hot</summary>
            TS_HOT = 2,
            /// <summary>Pressed</summary>
            TS_PRESSED = 3,
            /// <summary>Disabled</summary>
            TS_DISABLED = 4,
            /// <summary>Checked</summary>
            TS_CHECKED = 5,
            /// <summary>Checked and Hot</summary>
            TS_HOTCHECKED = 6
        }

        /// <summary> "Status" Parts </summary>      
        public enum UxThemeStatusParts : int
        {
            /// <summary>Pane</summary>
            SP_PANE = 1,
            /// <summary>Gripper Pane</summary>
            SP_GRIPPERPANE = 2,
            /// <summary>Gripper</summary>
            SP_GRIPPER = 3
        }

        /// <summary> "Menu" Parts </summary>summary>
        public enum UxThemeMenuParts : int 
        {
            /// <summary>Menu Item</summary>
            MP_MENUITEM = 1,
            /// <summary>Menu Drop-Down</summary>
            MP_MENUDROPDOWN = 2,
            /// <summary>Menu Bar Item</summary>
            MP_MENUBARITEM = 3,
            /// <summary>Menu Bar Drop-DOwn</summary>
            MP_MENUBARDROPDOWN = 4,
            /// <summary>Chevron</summary>
            MP_CHEVRON = 5,
            /// <summary>Separator</summary>
            MP_SEPARATOR = 6
        }
        /// <summary>Menu States</summary>
        public enum UxThemeMenuStates : int
        {
            /// <summary>Normal</summary>
            MS_NORMAL = 1,
            /// <summary>Selected</summary>
            MS_SELECTED = 2,
            /// <summary>Demoted</summary>
            MS_DEMOTED = 3
        }

        /// <summary> "ListView" Parts</summary>
        public enum UxThemeLISTVIEWParts : int 
        {
            /// <summary>List item</summary>
            LVP_LISTITEM = 1,
            /// <summary>List Group</summary>
            LVP_LISTGROUP = 2,
            /// <summary>List Detail</summary>
            LVP_LISTDETAIL = 3,
            /// <summary>List Sorted Detail</summary>
            LVP_LISTSORTEDDETAIL = 4,
            /// <summary>List Empty text</summary>
            LVP_EMPTYTEXT = 5
        }

        /// <summary>List Item States</summary>
        public enum UxThemeLISTITEMStates : int
        {
            /// <summary>Normal</summary>      
            LIS_NORMAL = 1,
            /// <summary>Hot</summary>
            LIS_HOT = 2,
            /// <summary>Selected</summary>      
            LIS_SELECTED = 3,
            /// <summary>Disabled</summary>      
            LIS_DISABLED = 4,
            /// <summary>Selected no focus</summary>      
            LIS_SELECTEDNOTFOCUS = 5
        }

        /// <summary> "Header" Parts</summary>
        public enum UxThemeHEADERParts : int
        {
            /// <summary>Header Item</summary>
            HP_HEADERITEM = 1,
            /// <summary>Left Header Item</summary>
            HP_HEADERITEMLEFT = 2,
            /// <summary>Right Header Item</summary>
            HP_HEADERITEMRIGHT = 3,
            /// <summary>Sort Arrow</summary>
            HP_HEADERSORTARROW = 4
        }

        /// <summary>Header Item States</summary>
        public enum UxThemeHEADERITEMStates : int
        {
            /// <summary>Normal</summary>      
            HIS_NORMAL = 1,
            /// <summary>Hot</summary>
            HIS_HOT = 2,
            /// <summary>Pressed</summary>      
            HIS_PRESSED = 3
        }

        /// <summary>Left Header Item States</summary>
        public enum UxThemeHEADERITEMLEFTStates : int
        {
            /// <summary>Normal</summary>      
            HILS_NORMAL = 1,
            /// <summary>Hot</summary>
            HILS_HOT = 2,
            /// <summary>Pressed</summary>      
            HILS_PRESSED = 3
        }

        /// <summary>Right Header Item States</summary>
        public enum UxThemeHEADERITEMRIGHTStates : int
        {
            /// <summary>Normal</summary>      
            HIRS_NORMAL = 1,
            /// <summary>Hot</summary>
            HIRS_HOT = 2,
            /// <summary>Pressed</summary>      
            HIRS_PRESSED = 3
        }

        /// <summary>Header Sort Arrow States</summary>
        public enum UxThemeHEADERSORTARROWStates : int
        {
            /// <summary>Up</summary>
            HSAS_SORTEDUP = 1,
            /// <summary>Down</summary>
            HSAS_SORTEDDOWN = 2
        }

        /// <summary>
        ///  Progress Parts
        /// </summary>
        public enum UxThemePROGRESSParts : int
        {
            /// <summary>Bar</summary>      
            PP_BAR = 1,
            /// <summary>Vertical Bar</summary>      
            PP_BARVERT = 2,
            /// <summary>Chunks</summary>      
            PP_CHUNK = 3,
            /// <summary>Vertical chunks</summary>      
            PP_CHUNKVERT = 4
        }

        /// <summary>
        ///  Tab Parts
        /// </summary>
        public enum UsxThemeTABParts : int
        {
            /// <summary>Tab</summary>      
            TABP_TABITEM = 1,
            /// <summary>Tab left edge</summary>      
            TABP_TABITEMLEFTEDGE = 2,
            /// <summary>Tab right edge</summary>      
            TABP_TABITEMRIGHTEDGE = 3,
            /// <summary>Tab both edge</summary>      
            TABP_TABITEMBOTHEDGE = 4,
            /// <summary>Top tab item</summary>      
            TABP_TOPTABITEM = 5,
            /// <summary>Top tab item left edge</summary>      
            TABP_TOPTABITEMLEFTEDGE = 6,
            /// <summary>Top tab item right edge</summary>      
            TABP_TOPTABITEMRIGHTEDGE = 7,
            /// <summary>Top tab item both edge</summary>      
            TABP_TOPTABITEMBOTHEDGE = 8,
            /// <summary>Tab pane</summary>      
            TABP_PANE = 9,
            /// <summary>Tab body</summary>      
            TABP_BODY = 10
        }

        /// <summary>
        /// Tab Item States
        /// </summary>
        public enum UxThemeTABITEMStates : int
        {
            /// <summary>Normal</summary>      
            TIS_NORMAL = 1,
            /// <summary>Hot</summary>      
            TIS_HOT = 2,
            /// <summary>Selected</summary>      
            TIS_SELECTED = 3,
            /// <summary>Disabled</summary>      
            TIS_DISABLED = 4,
            /// <summary>Focused</summary>      
            TIS_FOCUSED = 5
        }

        /// <summary>
        /// Tab item left edge states
        /// </summary>
        public enum UxThemeTABITEMLEFTEDGEStates : int
        {
            /// <summary>Normal</summary>      
            TILES_NORMAL = 1,
            /// <summary>Hot</summary>      
            TILES_HOT = 2,
            /// <summary>Selected</summary>      
            TILES_SELECTED = 3,
            /// <summary>Disabled</summary>      
            TILES_DISABLED = 4,
            /// <summary>Focused</summary>      
            TILES_FOCUSED = 5
        }

        /// <summary>
        /// Tab item right edge states
        /// </summary>
        public enum UxThemeTABITEMRIGHTEDGEStates : int
        {
            /// <summary>Normal</summary>      
            TIRES_NORMAL = 1,
            /// <summary>Hot</summary>      
            TIRES_HOT = 2,
            /// <summary>Selected</summary>      
            TIRES_SELECTED = 3,
            /// <summary>Disabled</summary>      
            TIRES_DISABLED = 4,
            /// <summary>Focused</summary>      
            TIRES_FOCUSED = 5
        }

        /// <summary>
        /// Tab item both edge states
        /// </summary>
        public enum UxThemeTABITEMBOTHEDGESStates : int
        {
            /// <summary>Normal</summary>      
            TIBES_NORMAL = 1,
            /// <summary>Hot</summary>      
            TIBES_HOT = 2,
            /// <summary>Selected</summary>      
            TIBES_SELECTED = 3,
            /// <summary>Disabled</summary>      
            TIBES_DISABLED = 4,
            /// <summary>Focused</summary>      
            TIBES_FOCUSED = 5
        }

        /// <summary>
        /// Top tab item states
        /// </summary>
        public enum UxThemeTOPTABITEMStates : int
        {
            /// <summary>Normal</summary>      
            TTIS_NORMAL = 1,
            /// <summary>Hot</summary>      
            TTIS_HOT = 2,
            /// <summary>Selected</summary>      
            TTIS_SELECTED = 3,
            /// <summary>Disabled</summary>      
            TTIS_DISABLED = 4,
            /// <summary>Focused</summary>      
            TTIS_FOCUSED = 5
        }

        /// <summary>
        /// Top tab item left edge states
        /// </summary>
        public enum UxThemeTOPTABITEMLEFTEDGEStates : int
        {
            /// <summary>Normal</summary>      
            TTILES_NORMAL = 1,
            /// <summary>Hot</summary>      
            TTILES_HOT = 2,
            /// <summary>Selected</summary>      
            TTILES_SELECTED = 3,
            /// <summary>Disabled</summary>      
            TTILES_DISABLED = 4,
            /// <summary>Focused</summary>      
            TTILES_FOCUSED = 5
        }

        /// <summary>
        /// Top tab item right edge states
        /// </summary>
        public enum UxThemeTOPTABITEMRIGHTEDGEStates : int
        {
            /// <summary>Normal</summary>      
            TTIRES_NORMAL = 1,
            /// <summary>Hot</summary>      
            TTIRES_HOT = 2,
            /// <summary>Selected</summary>      
            TTIRES_SELECTED = 3,
            /// <summary>Disabled</summary>      
            TTIRES_DISABLED = 4,
            /// <summary>Focused</summary>      
            TTIRES_FOCUSED = 5
        }

        /// <summary>
        /// Top tab item both edge states
        /// </summary>
        public enum UxThemeTOPTABITEMBOTHEDGESStates : int
        {
            /// <summary>Normal</summary>      
            TTIBES_NORMAL = 1,
            /// <summary>Hot</summary>      
            TTIBES_HOT = 2,
            /// <summary>Selected</summary>      
            TTIBES_SELECTED = 3,
            /// <summary>Disabled</summary>      
            TTIBES_DISABLED = 4,
            /// <summary>Focused</summary>      
            TTIBES_FOCUSED = 5
        }

        /// <summary> "Trackbar" Parts</summary>
        public enum UxThemeTRACKBARParts : int
        {
            /// <summary>Track</summary>      
            TKP_TRACK = 1,
            /// <summary>Vertical Track</summary>      
            TKP_TRACKVERT = 2,
            /// <summary>Thumb</summary>      
            TKP_THUMB = 3,
            /// <summary>Thumb Button</summary>      
            TKP_THUMBBOTTOM = 4,
            /// <summary>Thumb Top</summary>      
            TKP_THUMBTOP = 5,
            /// <summary>Vertical Thumb</summary>      
            TKP_THUMBVERT = 6,
            /// <summary>Thumb left</summary>      
            TKP_THUMBLEFT = 7,
            /// <summary>Thumb right</summary>      
            TKP_THUMBRIGHT = 8,
            /// <summary>Track tic marks</summary>      
            TKP_TICS = 9,
            /// <summary>Vertical track tic marks</summary>      
            TKP_TICSVERT = 10
        }

        /// <summary>
        /// Track Bar states
        /// </summary>
        public enum UxThemeTRACKBARStates : int
        {
            /// <summary>Normal</summary>      
            TKS_NORMAL = 1
        }

        /// <summary>
        /// Track states
        /// </summary>
        public enum UxThemeTRACKStates : int
        {
            /// <summary>Normal</summary>      
            TRS_NORMAL = 1
        }

        /// <summary>
        /// Vertical track bar states
        /// </summary>
        public enum UxThemeTRACKVERTStates : int
        {
            /// <summary>Normal</summary>      
            TRVS_NORMAL = 1
        }

        /// <summary>
        /// Thumb states
        /// </summary>
        public enum UxThemeTHUMBStates : int
        {
            /// <summary>Normal</summary>      
            TUS_NORMAL = 1,
            /// <summary>Hot</summary>      
            TUS_HOT = 2,
            /// <summary>Pressed</summary>      
            TUS_PRESSED = 3,
            /// <summary>Focused</summary>      
            TUS_FOCUSED = 4,
            /// <summary>Disabled</summary>      
            TUS_DISABLED = 5
        }

        /// <summary>Thumb Bottom states</summary>
        public enum UxThemeTHUMBBOTTOMStates : int
        {
            /// <summary>Normal</summary>      
            TUBS_NORMAL = 1,
            /// <summary>Hot</summary>      
            TUBS_HOT = 2,
            /// <summary>Pressed</summary>      
            TUBS_PRESSED = 3,
            /// <summary>Focused</summary>      
            TUBS_FOCUSED = 4,
            /// <summary>Disabled</summary>      
            TUBS_DISABLED = 5
        }

        /// <summary>Thumb Top states</summary>
        public enum UxThemeTHUMBTOPStates : int
        {
            /// <summary>Normal</summary>      
            TUTS_NORMAL = 1,
            /// <summary>Hot</summary>      
            TUTS_HOT = 2,
            /// <summary>Pressed</summary>      
            TUTS_PRESSED = 3,
            /// <summary>Focused</summary>      
            TUTS_FOCUSED = 4,
            /// <summary>Disabled</summary>      
            TUTS_DISABLED = 5
        }

        /// <summary>Vertical thumb states</summary>
        public enum UxThemeTHUMBVERTStates : int
        {
            /// <summary>Normal</summary>      
            TUVS_NORMAL = 1,
            /// <summary>Hot</summary>      
            TUVS_HOT = 2,
            /// <summary>Pressed</summary>      
            TUVS_PRESSED = 3,
            /// <summary>Focused</summary>      
            TUVS_FOCUSED = 4,
            /// <summary>Disabled</summary>      
            TUVS_DISABLED = 5
        }

        /// <summary>Vertical thumb left states</summary>
        public enum UxThemeTHUMBLEFTStates : int
        {
            /// <summary>Normal</summary>      
            TUVLS_NORMAL = 1,
            /// <summary>Hot</summary>      
            TUVLS_HOT = 2,
            /// <summary>Pressed</summary>      
            TUVLS_PRESSED = 3,
            /// <summary>Focused</summary>      
            TUVLS_FOCUSED = 4,
            /// <summary>Disabled</summary>      
            TUVLS_DISABLED = 5
        }

        /// <summary>Vertical thumb right states</summary>
        public enum UxThemeTHUMBRIGHTStates : int
        {
            /// <summary>Normal</summary>      
            TUVRS_NORMAL = 1,
            /// <summary>Hot</summary>      
            TUVRS_HOT = 2,
            /// <summary>Pressed</summary>      
            TUVRS_PRESSED = 3,
            /// <summary>Focused</summary>      
            TUVRS_FOCUSED = 4,
            /// <summary>Disabled</summary>      
            TUVRS_DISABLED = 5
        }

        /// <summary>Thumb states</summary>
        public enum UxThemeTICSStates : int
        {
            /// <summary>Normal</summary>      
            TSS_NORMAL = 1
        }

        /// <summary>Vertical thumb tics states</summary>
        public enum UxThemeTICSVERTStates : int
        {
            /// <summary>Normal</summary>      
            TSVS_NORMAL = 1
        }

        /// <summary> "Tooltips" Parts</summary>
        public enum UxThemeTOOLTIPParts : int
        {
            /// <summary>Standard</summary>      
            TTP_STANDARD = 1,
            /// <summary>Standard with title</summary>      
            TTP_STANDARDTITLE = 2,
            /// <summary>Balloon</summary>      
            TTP_BALLOON = 3,
            /// <summary>Balloon with title</summary>      
            TTP_BALLOONTITLE = 4,
            /// <summary>Close</summary>      
            TTP_CLOSE = 5
        }

        /// <summary>Tool tip Close states</summary>
        public enum UxThemeCLOSEStates : int
        {
            /// <summary>Normal</summary>      
            TTCS_NORMAL = 1,
            /// <summary>Hot</summary>      
            TTCS_HOT = 2,
            /// <summary>Pressed</summary>      
            TTCS_PRESSED = 3
        }

        /// <summary>
        /// Standard Tool Tip states
        /// </summary>
        public enum UxThemeSTANDARDStates : int
        {
            /// <summary>Normal</summary>      
            TTSS_NORMAL = 1,
            /// <summary>Link</summary>      
            TTSS_LINK = 2
        }

        /// <summary>
        /// Balloon tool tip states
        /// </summary>
        public enum UxThemeBALLOONStates : int
        {
            /// <summary>Normal</summary>      
            TTBS_NORMAL = 1,
            /// <summary>Link</summary>      
            TTBS_LINK = 2
        }

        /// <summary> "TreeView" Parts</summary>
        public enum UxThemeTREEVIEWParts : int
        {
            /// <summary>Tree Item</summary>      
            TVP_TREEITEM = 1,
            /// <summary>Glyph</summary>      
            TVP_GLYPH = 2,
            /// <summary>Branch</summary>      
            TVP_BRANCH = 3
        }

        /// <summary>Tree Item States</summary>      
        public enum UxThemeTREEITEMStates : int
        {
            /// <summary>Normal</summary>      
            TREIS_NORMAL = 1,
            /// <summary>Hot</summary>      
            TREIS_HOT = 2,
            /// <summary>Selected</summary>      
            TREIS_SELECTED = 3,
            /// <summary>Disabled</summary>      
            TREIS_DISABLED = 4,
            /// <summary>Selected no focus</summary>      
            TREIS_SELECTEDNOTFOCUS = 5
        }

        /// <summary>Glyph states</summary>      
        public enum UxThemeGLYPHStates : int
        {
            /// <summary>Closed</summary>      
            GLPS_CLOSED = 1,
            /// <summary>Opened</summary>      
            GLPS_OPENED = 2
        }

        /// <summary> "Spin" Parts</summary>
        public enum UxThemeSPINStates : int
        {
            /// <summary>Spin up</summary>      
            SPNP_UP = 1,
            /// <summary>Spin down</summary>      
            SPNP_DOWN = 2,
            /// <summary>Spin up horizontal</summary>      
            SPNP_UPHORZ = 3,
            /// <summary>Spin down horizontal</summary>      
            SPNP_DOWNHORZ = 4
        }

        /// <summary>Spin up states</summary>
        public enum UxThemeUPStates : int
        {
            /// <summary>Normal</summary>      
            UPS_NORMAL = 1,
            /// <summary>Hot</summary>      
            UPS_HOT = 2,
            /// <summary>Pressed</summary>      
            UPS_PRESSED = 3,
            /// <summary>Disabled</summary>      
            UPS_DISABLED = 4
        }

        /// <summary>Spin down states</summary>
        public enum UxThemeDOWNStates : int
        {
            /// <summary>Normal</summary>      
            DNS_NORMAL = 1,
            /// <summary>Hot</summary>      
            DNS_HOT = 2,
            /// <summary>Pressed</summary>      
            DNS_PRESSED = 3,
            /// <summary>Disabled</summary>      
            DNS_DISABLED = 4
        }

        /// <summary>Horizontal spin up states</summary>
        public enum UxThemeUPHORZStates : int
        {
            /// <summary>Normal</summary>      
            UPHZS_NORMAL = 1,
            /// <summary>Hot</summary>      
            UPHZS_HOT = 2,
            /// <summary>Pressed</summary>      
            UPHZS_PRESSED = 3,
            /// <summary>Disabled</summary>      
            UPHZS_DISABLED = 4
        }

        /// <summary>Horizontal spin down states</summary>
        public enum UxThemeDOWNHORZStates : int
        {
            /// <summary>Normal</summary>      
            DNHZS_NORMAL = 1,
            /// <summary>Hot</summary>      
            DNHZS_HOT = 2,
            /// <summary>Pressed</summary>      
            DNHZS_PRESSED = 3,
            /// <summary>Disabled</summary>      
            DNHZS_DISABLED = 4
        }

        /// <summary> "Page" Parts.Pager uses same states as Spin</summary>
        public enum UxThemePageParts : int
        {
            /// <summary>Up</summary>
            PGRP_UP = 1,
            /// <summary>Down</summary>
            PGRP_DOWN = 2,
            /// <summary>Horizontal Up</summary>
            PGRP_UPHORZ = 3,
            /// <summary>Horizontal Down</summary>
            PGRP_DOWNHORZ = 4
        }


        /// <summary> "Scrollbar" Parts</summary>
        public enum UxThemeSCROLLBARParts : int
        {
            /// <summary>Arrow button</summary>
            SBP_ARROWBTN = 1,
            /// <summary>Horizontal thumb button</summary>
            SBP_THUMBBTNHORZ = 2,
            /// <summary>Verical thumb button</summary>
            SBP_THUMBBTNVERT = 3,
            /// <summary>Horizontal lower track</summary>
            SBP_LOWERTRACKHORZ = 4,
            /// <summary>Horizontal upper track</summary>
            SBP_UPPERTRACKHORZ = 5,
            /// <summary>Vertical lower track</summary>
            SBP_LOWERTRACKVERT = 6,
            /// <summary>Vertical upper track</summary>
            SBP_UPPERTRACKVERT = 7,
            /// <summary>Horizontal gripper</summary>
            SBP_GRIPPERHORZ = 8,
            /// <summary>Vertical gripper</summary>
            SBP_GRIPPERVERT = 9,
            /// <summary>Size box</summary>
            SBP_SIZEBOX = 10
        }

        /// <summary>
        /// Scroll Arrow Button states
        /// </summary>
        public enum UxThemeARROWBTNStates : int
        {
            /// <summary>Up Normal</summary>
            ABS_UPNORMAL = 1,
            /// <summary>Up Hot</summary>
            ABS_UPHOT = 2,
            /// <summary>Up Pressed</summary>
            ABS_UPPRESSED = 3,
            /// <summary>Up Disabled</summary>
            ABS_UPDISABLED = 4,
            /// <summary>Down Normal</summary>
            ABS_DOWNNORMAL = 5,
            /// <summary>Down Hot</summary>
            ABS_DOWNHOT = 6,
            /// <summary>Down Pressed</summary>
            ABS_DOWNPRESSED = 7,
            /// <summary>Down Disabled</summary>
            ABS_DOWNDISABLED = 8,
            /// <summary>Left Normal</summary>
            ABS_LEFTNORMAL = 9,
            /// <summary>Left Hot</summary>
            ABS_LEFTHOT = 10,
            /// <summary>Left Pressed</summary>
            ABS_LEFTPRESSED = 11,
            /// <summary>Left Disabled</summary>
            ABS_LEFTDISABLED = 12,
            /// <summary>Right Normal</summary>
            ABS_RIGHTNORMAL = 13,
            /// <summary>Right Hot</summary>
            ABS_RIGHTHOT = 14,
            /// <summary>Right Pressed</summary>
            ABS_RIGHTPRESSED = 15,
            /// <summary>Right Disabled</summary>
            ABS_RIGHTDISABLED = 16
        }

        /// <summary>
        /// Scroll bar states
        /// </summary>
        public enum UxThemeSCROLLBARStates : int
        {
            /// <summary>Normal</summary>      
            SCRBS_NORMAL = 1,
            /// <summary>Hot</summary>      
            SCRBS_HOT = 2,
            /// <summary>Pressed</summary>      
            SCRBS_PRESSED = 3,
            /// <summary>Disabled</summary>      
            SCRBS_DISABLED = 4
        }

        /// <summary>
        /// Size box states
        /// </summary>
        public enum UxThemeSIZEBOXStates : int
        {
            /// <summary>Right Align</summary>
            SZB_RIGHTALIGN = 1,
            /// <summary>Left Align</summary>
            SZB_LEFTALIGN = 2
        }

        /// <summary> "Edit" Parts</summary>
        public enum UxThemeEDITParts : int
        {
            /// <summary>Text</summary>
            EP_EDITTEXT = 1,
            /// <summary>Caret</summary>
            EP_CARET = 2
        }

        /// <summary>
        /// Edit states
        /// </summary>
        public enum UxThemeEDITTEXTStates : int
        {
            /// <summary>Normal</summary>      
            ETS_NORMAL = 1,
            /// <summary>Hot</summary>      
            ETS_HOT = 2,
            /// <summary>Selected</summary>      
            ETS_SELECTED = 3,
            /// <summary>Disabled</summary>      
            ETS_DISABLED = 4,
            /// <summary>Focused</summary>      
            ETS_FOCUSED = 5,
            /// <summary>Read only</summary>      
            ETS_READONLY = 6,
            /// <summary>Assist</summary>      
            ETS_ASSIST = 7
        }

        /// <summary> "ComboBox" Parts</summary>
        public enum UxThemeComboBoxParts : int
        {
            /// <summary>Drop-down button</summary>      
            CP_DROPDOWNBUTTON = 1
        }

        /// <summary>
        /// Combo box states
        /// </summary>
        public enum UxThemeComboBoxStates : int
        {
            /// <summary>Normal</summary>      
            CBXS_NORMAL = 1,
            /// <summary>Hot</summary>      
            CBXS_HOT = 2,
            /// <summary>Pressed</summary>      
            CBXS_PRESSED = 3,
            /// <summary>Disabled</summary>      
            CBXS_DISABLED = 4
        }

        /// <summary> "Taskbar Clock" Parts</summary>
        public enum UxThemeCLOCKParts : int
        {
            /// <summary>Time</summary>      
            CLP_TIME = 1
        }

        /// <summary>
        /// Clock states
        /// </summary>
        public enum UxThemeCLOCKStates : int
        {
            /// <summary>Normal</summary>      
            CLS_NORMAL = 1
        }

        /// <summary> "Tray Notify" Parts</summary>
        public enum UxThemeTRAYNOTIFYParts : int
        {
            /// <summary>Background</summary>
            TNP_BACKGROUND = 1,
            /// <summary>Animation Background</summary>
            TNP_ANIMBACKGROUND = 2
        }

        /// <summary> "TaskBar" Parts</summary>
        public enum UxThemeTASKBARParts : int
        {
            /// <summary>Background bottom</summary>
            TBP_BACKGROUNDBOTTOM = 1,
            /// <summary>Background right</summary>
            TBP_BACKGROUNDRIGHT = 2,
            /// <summary>Background top</summary>
            TBP_BACKGROUNDTOP = 3,
            /// <summary>Background left</summary>
            TBP_BACKGROUNDLEFT = 4,
            /// <summary>Sizing bar bottom</summary>         
            TBP_SIZINGBARBOTTOM = 5,
            /// <summary>Sizing bar right</summary>
            TBP_SIZINGBARRIGHT = 6,
            /// <summary>Sizing bar top</summary>         
            TBP_SIZINGBARTOP = 7,
            /// <summary>Sizing bar left</summary>         
            TBP_SIZINGBARLEFT = 8
        }

        /// <summary> "TaskBand" Parts</summary>
        public enum UxThemeTASKBANDParts : int
        {
            /// <summary>Group count</summary>         
            TDP_GROUPCOUNT = 1,
            /// <summary>Flash button</summary>         
            TDP_FLASHBUTTON = 2,
            /// <summary>Flash button group menu</summary>         
            TDP_FLASHBUTTONGROUPMENU = 3
        }

        /// <summary> "StartPanel" Parts</summary>
        public enum UxThemeSTARTPANELParts : int
        {
            /// <summary>User pane</summary>         
            SPP_USERPANE = 1,
            /// <summary>More programs</summary>         
            SPP_MOREPROGRAMS = 2,
            /// <summary>More programs arrow</summary>         
            SPP_MOREPROGRAMSARROW = 3,
            /// <summary>Program list</summary>         
            SPP_PROGLIST = 4,
            /// <summary>Program list separator</summary>         
            SPP_PROGLISTSEPARATOR = 5,
            /// <summary>Places list</summary>         
            SPP_PLACESLIST = 6,
            /// <summary>Places list separator</summary>         
            SPP_PLACESLISTSEPARATOR = 7,
            /// <summary>Log off</summary>         
            SPP_LOGOFF = 8,
            /// <summary>Log off buttons</summary>         
            SPP_LOGOFFBUTTONS = 9,
            /// <summary>User picture</summary>         
            SPP_USERPICTURE = 10,
            /// <summary>Preview</summary>         
            SPP_PREVIEW = 11
        }

        /// <summary>
        /// More programs arrow states
        /// </summary>
        public enum UxThemeMOREPROGRAMSARROWStates : int
        {
            /// <summary>Normal</summary>      
            SPS_NORMAL = 1,
            /// <summary>Hot</summary>      
            SPS_HOT = 2,
            /// <summary>Pressed</summary>      
            SPS_PRESSED = 3
        }

        /// <summary>
        /// Log off button states
        /// </summary>
        public enum UxThemeLOGOFFBUTTONSStates : int
        {
            /// <summary>Normal</summary>      
            SPLS_NORMAL = 1,
            /// <summary>Hot</summary>      
            SPLS_HOT = 2,
            /// <summary>Pressed</summary>      
            SPLS_PRESSED = 3
        }

        public enum UxDrawTextAdditionalFlags : int
        {
            DTT_GRAYED = 0x1
        }

        /// <summary> "ExplorerBar" Parts</summary>
        public enum UxThemeEXPLORERBARParts : int
        {
            /// <summary>Header background</summary>         
            EBP_HEADERBACKGROUND = 1,
            /// <summary>Header close</summary>         
            EBP_HEADERCLOSE = 2,
            /// <summary>Header pin</summary>         
            EBP_HEADERPIN = 3,
            /// <summary>Header IE Bar menu</summary>         
            EBP_IEBARMENU = 4,
            /// <summary>Normal group background</summary>         
            EBP_NORMALGROUPBACKGROUND = 5,
            /// <summary>Normal group collapse</summary>         
            EBP_NORMALGROUPCOLLAPSE = 6,
            /// <summary>Normal group expand</summary>         
            EBP_NORMALGROUPEXPAND = 7,
            /// <summary>Normal group head</summary>         
            EBP_NORMALGROUPHEAD = 8,
            /// <summary>Special group background</summary>         
            EBP_SPECIALGROUPBACKGROUND = 9,
            /// <summary>Special group collapse</summary>         
            EBP_SPECIALGROUPCOLLAPSE = 10,
            /// <summary>Special group expand</summary>         
            EBP_SPECIALGROUPEXPAND = 11,
            /// <summary>Special group header</summary>         
            EBP_SPECIALGROUPHEAD = 12
        }

        /// <summary>
        /// Header close states
        /// </summary>
        public enum UxThemeHEADERCLOSEStates
        {
            /// <summary>Normal</summary>      
            EBHC_NORMAL = 1,
            /// <summary>Hot</summary>      
            EBHC_HOT = 2,
            /// <summary>Pressed</summary>      
            EBHC_PRESSED = 3
        }

        /// <summary>
        /// Header Pin states
        /// </summary>
        public enum UxThemeHEADERPINStates
        {
            /// <summary>Normal</summary>      
            EBHP_NORMAL = 1,
            /// <summary>Hot</summary>      
            EBHP_HOT = 2,
            /// <summary>Pressed</summary>      
            EBHP_PRESSED = 3,
            /// <summary>Selected normal</summary>      
            EBHP_SELECTEDNORMAL = 4,
            /// <summary>Selected hot</summary>      
            EBHP_SELECTEDHOT = 5,
            /// <summary>Selected pressed</summary>      
            EBHP_SELECTEDPRESSED = 6
        }

        /// <summary>
        /// IE Bar Menu states
        /// </summary>
        public enum UxThemeIEBARMENUStates
        {
            /// <summary>Normal</summary>      
            EBM_NORMAL = 1,
            /// <summary>Hot</summary>      
            EBM_HOT = 2,
            /// <summary>Pressed</summary>      
            EBM_PRESSED = 3
        }

        /// <summary>
        /// Normal group collapse states
        /// </summary>
        public enum UxThemeNORMALGROUPCOLLAPSEStates
        {
            /// <summary>Normal</summary>      
            EBNGC_NORMAL = 1,
            /// <summary>Hot</summary>      
            EBNGC_HOT = 2,
            /// <summary>Pressed</summary>      
            EBNGC_PRESSED = 3
        }

        /// <summary>
        /// Normal group expand states
        /// </summary>
        public enum UxThemeNORMALGROUPEXPANDStates
        {
            /// <summary>Normal</summary>      
            EBNGE_NORMAL = 1,
            /// <summary>Hot</summary>      
            EBNGE_HOT = 2,
            /// <summary>Pressed</summary>      
            EBNGE_PRESSED = 3
        }

        /// <summary>
        /// Special group collapse states
        /// </summary>
        public enum UxThemeSPECIALGROUPCOLLAPSEStates
        {
            /// <summary>Normal</summary>      
            EBSGC_NORMAL = 1,
            /// <summary>Hot</summary>      
            EBSGC_HOT = 2,
            /// <summary>Pressed</summary>      
            EBSGC_PRESSED = 3
        }

        /// <summary>
        /// Special group expand states
        /// </summary>
        public enum UxThemeSPECIALGROUPEXPANDStates
        {
            /// <summary>Normal</summary>      
            EBSGE_NORMAL = 1,
            /// <summary>Hot</summary>      
            EBSGE_HOT = 2,
            /// <summary>Pressed</summary>      
            EBSGE_PRESSED = 3
        }

        /// <summary> "TaskBand" Parts</summary>
        public enum UxThemeMENUBANDParts : int
        {
            /// <summary>New application button</summary>
            MDP_NEWAPPBUTTON = 1,
            /// <summary>Separator</summary>
            MDP_SEPARATOR = 2
        }

        /// <summary> "TaskBand" States</summary>
        public enum UxThemeMENUBANDStates : int
        {
            /// <summary>Normal</summary>      
            MDS_NORMAL = 1,
            /// <summary>Hot</summary>      
            MDS_HOT = 2,
            /// <summary>Pressed</summary>      
            MDS_PRESSED = 3,
            /// <summary>Disabled</summary>      
            MDS_DISABLED = 4,
            /// <summary>Checked</summary>      
            MDS_CHECKED = 5,
            /// <summary>Checked and Hot</summary>      
            MDS_HOTCHECKED = 6
        }

        public enum EnableThemeDialogTextureFlags : int
        {
            ETDT_DISABLE = 0x00000001,
            ETDT_ENABLE = 0x00000002,
            ETDT_USETABTEXTURE = 0x00000004,
            ETDT_ENABLETAB = (ETDT_ENABLE | ETDT_USETABTEXTURE)
        }

        public enum THEME_COLORS : int
        {
             TMT_SCROLLBAR = 1601,
             TMT_BACKGROUND = 1602,
             TMT_ACTIVECAPTION = 1603,
             TMT_INACTIVECAPTION = 1604,
             TMT_MENU = 1605,
             TMT_WINDOW = 1606,
             TMT_WINDOWFRAME = 1607,
             TMT_MENUTEXT = 1608,
             TMT_WINDOWTEXT = 1609,
             TMT_CAPTIONTEXT = 1610,
             TMT_ACTIVEBORDER = 1611,
             TMT_INACTIVEBORDER = 1612,
             TMT_APPWORKSPACE = 1613,
             TMT_HIGHLIGHT = 1614,
             TMT_HIGHLIGHTTEXT = 1615,
             TMT_BTNFACE = 1616,
             TMT_BTNSHADOW = 1617,
             TMT_GRAYTEXT = 1618,
             TMT_BTNTEXT = 1619,
             TMT_INACTIVECAPTIONTEXT = 1620,
             TMT_BTNHIGHLIGHT = 1621,
             TMT_DKSHADOW3D = 1622,
             TMT_LIGHT3D = 1623,
             TMT_INFOTEXT = 1624,
             TMT_INFOBK = 1625,
             TMT_BUTTONALTERNATEFACE = 1626,
             TMT_HOTTRACKING = 1627,
             TMT_GRADIENTACTIVECAPTION = 1628,
             TMT_GRADIENTINACTIVECAPTION = 1629,
             TMT_MENUHILIGHT = 1630,
             TMT_MENUBAR = 1631
        }

        public enum UxDrawEdgeEdgeTypes : int
        {
            BDR_RAISEDOUTER = 0x1,
            BDR_SUNKENOUTER = 0x2,
            BDR_RAISEDINNER = 0x4,
            BDR_SUNKENINNER = 0x8,
            BDR_OUTER = (BDR_RAISEDOUTER | BDR_SUNKENOUTER),
            BDR_INNER = (BDR_RAISEDINNER | BDR_SUNKENINNER),
            BDR_RAISED = (BDR_RAISEDOUTER | BDR_RAISEDINNER),
            BDR_SUNKEN = (BDR_SUNKENOUTER | BDR_SUNKENINNER),
            EDGE_RAISED = (BDR_RAISEDOUTER | BDR_RAISEDINNER),
            EDGE_SUNKEN = (BDR_SUNKENOUTER | BDR_SUNKENINNER),
            EDGE_ETCHED = (BDR_SUNKENOUTER | BDR_RAISEDINNER),
            EDGE_BUMP = (BDR_RAISEDOUTER | BDR_SUNKENINNER)
        }

        public enum UxDrawEdgeBorderFlags : int
        {
            BF_LEFT = 0x1,
            BF_TOP = 0x2,
            BF_RIGHT = 0x4,
            BF_BOTTOM = 0x8,
            BF_TOPLEFT = (BF_TOP | BF_LEFT),
            BF_TOPRIGHT = (BF_TOP | BF_RIGHT),
            BF_BOTTOMLEFT = (BF_BOTTOM | BF_LEFT),
            BF_BOTTOMRIGHT = (BF_BOTTOM | BF_RIGHT),
            BF_RECT = (BF_LEFT | BF_TOP | BF_RIGHT | BF_BOTTOM),
            BF_DIAGONAL = 0x10,
            BF_DIAGONAL_ENDTOPRIGHT = (BF_DIAGONAL | BF_TOP | BF_RIGHT),
            BF_DIAGONAL_ENDTOPLEFT = (BF_DIAGONAL | BF_TOP | BF_LEFT),
            BF_DIAGONAL_ENDBOTTOMLEFT = (BF_DIAGONAL | BF_BOTTOM | BF_LEFT),
            BF_DIAGONAL_ENDBOTTOMRIGHT = (BF_DIAGONAL | BF_BOTTOM | BF_RIGHT),
            BF_MIDDLE = 0x800,
            BF_SOFT = 0x1000,
            BF_ADJUST = 0x2000,
            BF_FLAT = 0x4000,
            BF_MONO = 0x8000
        }

        public enum UxDrawTextFlags : int
        {
            DT_TOP = 0x0,
            DT_LEFT = 0x0,
            DT_CENTER = 0x1,
            DT_RIGHT = 0x2,
            DT_VCENTER = 0x4,
            DT_BOTTOM = 0x8,
            DT_WORDBREAK = 0x10,
            DT_SINGLELINE = 0x20,
            DT_EXPANDTABS = 0x40,
            DT_TABSTOP = 0x80,
            DT_NOCLIP = 0x100,
            DT_EXTERNALLEADING = 0x200,
            DT_CALCRECT = 0x400,
            DT_NOPREFIX = 0x800,
            DT_INTERNAL = 0x1000,
            DT_EDITCONTROL = 0x2000,
            DT_PATH_ELLIPSIS = 0x4000,
            DT_END_ELLIPSIS = 0x8000,
            DT_MODIFYSTRING = 0x10000,
            DT_RTLREADING = 0x20000,
            DT_WORD_ELLIPSIS = 0x40000,
            DT_NOFULLWIDTHCHARBREAK = 0x80000,
            DT_HIDEPREFIX = 0x100000,
            DT_PREFIXONLY = 0x200000
        }

        private enum PROPERTYORIGIN : int
        {
            PO_STATE = 0,
            PO_PART = 1,
            PO_CLASS = 2,
            PO_GLOBAL = 3,
            PO_NOTFOUND = 4
        }

        private enum WINDOWTHEMEATTRIBUTETYPE : int
        {
            WTA_NONCLIENT = 1
        }

        public enum UxThemeName
        {
            HomeStead,
            NormalColor,
            Metallic
        }

        public enum UxClassName
        {
            Window,
            Button,
            Rebar,
            Toolbar,
            Status,
            Menu,
            ListView,
            Header,
            Progress,
            Tab,
            Trackbar,
            Tooltip,
            Treeview,
            Spin,
            Page,
            Scrollbar,
            Edit,
            ComboBox,
            Clock,
            TrayNotify,
            TaskBar,
            TaskBand,
            StartPanel,
            ExplorerBar,
            MenuBand
        }

        private enum BP_ANIMATIONSTYLE
        {
            BPAS_NONE,
            BPAS_LINEAR,
            BPAS_CUBIC,
            BPAS_SINE
        }

        private enum THEMESIZE : int
        {
            TS_MIN,
            TS_TRUE,
            TS_DRAW
        }

        public enum ThemeAppProperties : uint
        {
            AllowNonClient = 0x00000001,
            AllowControls = 0x00000002,
            AllowWebContent = 0x00000004
        }

        public enum HitTestThemeBackgroundCode : ushort
        {
            BackgroundSegment    = 0x0000,
            FixedBorder      = 0x0002,
            Caption          = 0x0004,
            LeftResizingBorder   = 0x0010,
            TopResizingBorder    = 0x0020,
            RightResizingBorder  = 0x0040,
            BottomResizingBorder = 0x0080,
            ResizingBorder       = 0x00F0,
            SizingTemplate       = 0x0100,
            SystemSizingMargins  = 0x0200
        }
        #endregion

        #region Structs
        [StructLayout(LayoutKind.Sequential)]
        private struct SIZE
        {
            internal int cx;
            internal int cy;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT {
            internal int X;
            internal int Y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public RECT(Rectangle rc)
            {
                Left = rc.X;
                Top = rc.Y;
                Right = rc.Right;
                Bottom = rc.Bottom;
            }

            public RECT(int left, int top, int right, int bottom)
            {
                this.Left = left;
                this.Top = top;
                this.Right = right;
                this.Bottom = bottom;
            }
        }


        [StructLayout(LayoutKind.Sequential)]
        private struct BP_ANIMATIONPARAMS
        {
            internal int cbSize;
            internal int dwFlags;
            internal BP_ANIMATIONSTYLE style;
            internal int dwDuration;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct DTBGOPTS
        {
            internal int dwSize;
            internal int dwFlags;
            internal RECT rcClip;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct DTTOPTS 
        {
            internal int dwSize;
            internal int dwFlags;
            internal IntPtr crText;
            internal IntPtr crBorder;
            internal IntPtr crShadow;
            internal int iTextShadowType;
            internal POINT ptShadowOffset;
            internal int iBorderSize;
            internal int iFontPropId;
            internal int iColorPropId;
            internal int iStateId;
            internal bool fApplyOverlay;
            internal int iGlowSize;
            internal IntPtr pfnDrawTextCallback;
            internal IntPtr lParam;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MARGINS
        {
            internal int cxLeftWidth;
            internal int cxRightWidth;
            internal int cyTopHeight;
            internal int cyBottomHeight;
        }

        /*[StructLayout(LayoutKind.Sequential)]
        private struct WTA_OPTIONS
        {
            internal int dwFlags;
            internal int dwMask;
        }*/

        [Serializable, StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct TEXTMETRIC
        {
            internal int tmHeight;
            internal int tmAscent;
            internal int tmDescent;
            internal int tmInternalLeading;
            internal int tmExternalLeading;
            internal int tmAveCharWidth;
            internal int tmMaxCharWidth;
            internal int tmWeight;
            internal int tmOverhang;
            internal int tmDigitizedAspectX;
            internal int tmDigitizedAspectY;
            internal char tmFirstChar;
            internal char tmLastChar;
            internal char tmDefaultChar;
            internal char tmBreakChar;
            internal byte tmItalic;
            internal byte tmUnderlined;
            internal byte tmStruckOut;
            internal byte tmPitchAndFamily;
            internal byte tmCharSet;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private class LOGFONT
        {
            internal int lfHeight = 0;
            internal int lfWidth = 0;
            internal int lfEscapement = 0;
            internal int lfOrientation = 0;
            internal int lfWeight = 0;
            internal byte lfItalic = 0;
            internal byte lfUnderline = 0;
            internal byte lfStrikeOut = 0;
            internal byte lfCharSet = 0;
            internal byte lfOutPrecision = 0;
            internal byte lfClipPrecision = 0;
            internal byte lfQuality = 0;
            internal byte lfPitchAndFamily = 0;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            internal string lfFaceName = string.Empty;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct INTLIST
        {
            internal int iValueCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            internal int[] iValues;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct COLORREF
        {
            internal byte R;
            internal byte G;
            internal byte B;
        }
        #endregion

        #region API
        [DllImport("user32.dll")]
        private static extern int GetSysColor(int nIndex);

        [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
        private static extern bool GetTextMetrics(IntPtr hdc, out TEXTMETRIC lptm);

        [DllImport("user32.dll")]
        private extern static IntPtr GetParent(IntPtr hWnd);

        // theme API
        [DllImport("uxtheme.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private extern static bool IsAppThemed();

        [DllImport("uxtheme.dll")]
        private extern static int DrawThemeEdge(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref RECT pDestRect, uint egde, uint flags, out RECT pRect);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private extern static int GetThemeTextExtent(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, String text, int textLength, uint textFlags, ref RECT boundingRect, out RECT extentRect);

        [DllImport("uxtheme.dll")]
        private extern static int DrawThemeIcon(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref RECT pRect, IntPtr himl, int iImageIndex);

        [DllImport("uxtheme.dll")]
        private extern static int GetThemeBackgroundContentRect(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref RECT pBoundingRect, out RECT pContentRect);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrentThemeName")]
        private static extern int GetCurrentThemeNameForFile([MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszThemeFileName,
        int dwMaxNameChars, IntPtr pszColorBuff, int cchMaxColorChars, IntPtr pszSizeBuff, int cchMaxSizeChars);

        [DllImport("uxtheme.dll")]
        private extern static int DrawThemeParentBackground(IntPtr hWnd, IntPtr hdc, ref RECT pRect);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private extern static int GetThemeDocumentationProperty(String stringThemeName, String stringPropertyName, out StringBuilder stringValue, int lengthValue);

        [DllImport("uxtheme.dll")]
        private extern static void SetThemeAppProperties(ThemeAppProperties props);

        [DllImport("uxtheme.dll")]
        private extern static ThemeAppProperties GetThemeAppProperties();

        [DllImport("uxtheme.dll")]
        private extern static int EnableThemeDialogTexture(IntPtr hWnd, EnableThemeDialogTextureFlags flags);

        [DllImport("uxtheme.dll")]
        private extern static int IsThemeDialogTextureEnabled(IntPtr hWnd);

        [DllImport("uxtheme.dll")]
        private extern static IntPtr GetWindowTheme(IntPtr hWnd);

        [DllImport("uxtheme.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private extern static bool IsThemeActive();

        [DllImport("uxtheme.dll")]
        private extern static int GetThemeSysInt(IntPtr hTheme, int iIntId, out int piVal);

        [DllImport("uxtheme.dll", ExactSpelling=true, CharSet=CharSet.Unicode)]
        private extern static int GetThemeSysString(IntPtr hTheme, int iStringId, out StringBuilder stringSys, int stringSysLength);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private extern static int GetThemeSysFont(IntPtr hTheme, int iFontId, out LOGFONT plf);

        [DllImport("uxtheme.dll")]
        private extern static int GetThemeSysSize(IntPtr hTheme, int iSizeId);

        [DllImport("uxtheme.dll")]
        private extern static int GetThemeSysBool(IntPtr hTheme, int iBoolId);

        [DllImport("uxtheme.dll")]
        private extern static IntPtr GetThemeSysColorBrush(IntPtr hTheme, int iColorId);

        [DllImport("uxtheme.dll")]
        private extern static uint GetThemeSysColor(IntPtr hTheme, int iColorId);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private extern static int GetThemeFilename(IntPtr hTheme, int iPartId, int iStateId, int iPropId, StringBuilder themeFileName, int themeFileNameLength);

        [DllImport("uxtheme.dll.dll", CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hWnd, String pszSubAppName, String pszSubIdList);

        [DllImport("uxtheme.dll")]
        private extern static int GetThemePropertyOrigin(IntPtr hTheme, int iPartId, int iStateId, int iPropId, out PROPERTYORIGIN pOrigin);

        [DllImport("uxtheme.dll")]
        private extern static int GetThemeIntList(IntPtr hTheme, int iPartId, int iStateId, int iPropId, out INTLIST pIntList);

        [DllImport("uxtheme.dll")]
        private extern static int GetThemeRect(IntPtr hTheme, int iPartId, int iStateId, int iPropId, out RECT pRect); 
        
        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private extern static int GetThemeFont(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, int iPropId, out LOGFONT pFont);

        [DllImport("uxtheme.dll")]
        private extern static int GetThemePosition(IntPtr hTheme, int iPartId, int iStateId, int iPropId, out POINT pPoint);

        [DllImport("uxtheme.dll")]
        private extern static int GetThemeEnumValue(IntPtr hTheme, int iPartId, int iStateId, int iPropId, out int piVal);

        [DllImport("uxtheme.dll")]
        private extern static int GetThemeInt(IntPtr hTheme, int iPartId, int iStateId, int iPropId, out int piVal);

        [DllImport("uxtheme.dll")]
        private extern static int GetThemeBool(IntPtr hTheme, int iPartId, int iStateId, int iPropId, out int pfVal);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private extern static int GetThemeString(IntPtr hTheme, int iPartId, int iStateId, int iPropId, out StringBuilder themeString, int themeStringLength);

        [DllImport("uxtheme.dll")]
        private extern static int GetThemeMetric(IntPtr hTheme, IntPtr hDC, int iPartId, int iStateId, int iPropId, out int piVal);

        [DllImport("uxtheme.dll")]
        private extern static int GetThemeColor(IntPtr hTheme, int iPartId, int iStateId, int iPropId, out COLORREF pColor);

        [DllImport("uxtheme.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private extern static bool IsThemeBackgroundPartiallyTransparent(IntPtr hTheme, int iPartId, int iStateId);

        [DllImport("uxtheme.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private extern static bool IsThemePartDefined(IntPtr hTheme, int iPartId, int iStateId);

        [DllImport("uxtheme.dll")]
        private extern static int HitTestThemeBackground(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, uint dwOptions, ref RECT pRect, IntPtr hrgn, POINT ptTest, out HitTestThemeBackgroundCode code); 

        [DllImport("uxtheme.dll")]
        private extern static int GetThemeBackgroundRegion(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref RECT pRect, out IntPtr pRegion);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr OpenThemeData(IntPtr hWnd, string pszClassList);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private static extern int CloseThemeData(IntPtr hTheme);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private static extern int DrawThemeBackground(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref RECT pRect, ref RECT pClipRect);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private extern static int GetCurrentThemeName(StringBuilder stringThemeName, int lengthThemeName, StringBuilder stringColorName, int lengthColorName, StringBuilder stringSizeName, int lengthSizeName);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrentThemeName")]
        private static extern int GetCurrentThemeNameForColor(IntPtr pszThemeFileName, int dwMaxNameChars,[MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszColorBuff,
        int cchMaxColorChars, IntPtr pszSizeBuff, int cchMaxSizeChars);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private static extern int GetThemePartSize(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref RECT prc,
        [MarshalAs(UnmanagedType.I4)] THEMESIZE eSize, ref SIZE psz);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private static extern int DrawThemeText(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, string pszText, int iCharCount,
        int dwTextFlags, int dwTextFlags2, ref RECT pRect);
        #endregion

        #region Fields
        private IntPtr _hTheme = IntPtr.Zero;
        private IntPtr _controlHandle = IntPtr.Zero;
        private IntPtr _parentHandle = IntPtr.Zero;
        private UxClassName _classId = UxClassName.Button;
        #endregion


        #region Constructors
        public cThemeManager()
        {
        }

        public bool Start(IntPtr handle, UxClassName classId)
        {
            if ((CompatablePlatform) && (ThemedApplication))
            {
                ClassId = classId;
                ControlHandle = handle;
                ThemeHandle = OpenThemeData(handle, classId.ToString()); 
            }
            else
            {
                return false;
            }
            return true;
        }

        public void Dispose()
        {
            if (ThemeHandle != IntPtr.Zero)
            {
                CloseThemeData(_hTheme);
                ThemeHandle = IntPtr.Zero;
            }

        }
        #endregion

        #region Properties
        public UxClassName ClassId
        {
            get { return _classId; }
            set { _classId = value; }
        }

        public bool CompatablePlatform
        {
            get { 
                Version os = OSVersion;
                return ((os.Major > 5) || ((os.Major == 5) && (os.Minor > 1))); 
            }
        }

        public IntPtr ControlHandle
        {
            get { return _controlHandle; }
            set { _controlHandle = value; }
        }

        public Version OSVersion
        {
            get {
                OperatingSystem os = Environment.OSVersion;
                return os.Version;
            }
        }

        public IntPtr ParentHandle
        {
            get { return (GetParent(ControlHandle)); }
        }

        public bool ThemedApplication
        {
            get { return (IsAppThemed()); }
        }

        public string ThemeColor
        {
            get {
                StringBuilder colourName = new StringBuilder(MAX_PATH, MAX_PATH);
                GetCurrentThemeNameForColor(IntPtr.Zero, 0, colourName, MAX_PATH, IntPtr.Zero, 0);
                return colourName.ToString();
            }
        }

        public IntPtr ThemeHandle
        {
            get { return _hTheme; }
            set { _hTheme = value; }
        }

        public string ThemeName
        {
            get {
                StringBuilder fileName = new StringBuilder(MAX_PATH, MAX_PATH);
                GetCurrentThemeNameForFile(fileName, MAX_PATH, IntPtr.Zero, 0, IntPtr.Zero, 0);
                return fileName.ToString();
            }
        }
        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion


        /// <summary>
        /// Draws text for the specified theme part
        /// </summary>
        /// <param name="gfx">Graphics object to draw onto </param>
        /// <param name="rect">Bounding rectangle</param>
        /// <param name="partId">Theme part id</param>
        /// <param name="stateId">Theme state id</param>
        /// <param name="text">Text to draw</param>
        /// <param name="textFlags">Text flags to use</param>
        public void DrawThemeText(Graphics gfx, int partId, int stateId, Rectangle rect, string text, int textFlags)
        {
            IntPtr hdc = gfx.GetHdc();
            RECT rc = new RECT(rect);
            DrawThemeText(ThemeHandle, hdc, partId, stateId, text, -1, textFlags, 0, ref rc);
            gfx.ReleaseHdc(hdc);
        }

        /// <summary>
        /// Draws the background for the specified theme part
        /// </summary>
        /// <param name="gfx">Graphics object to draw onto</param>
        /// <param name="rect">Bounding rectangle</param>
        /// <param name="partId">Theme part id</param>
        /// <param name="stateId">Theme state id</param>
        public void DrawThemeBackground(Graphics gfx, int partId, int stateId, Rectangle rect)
        {
            IntPtr hdc = gfx.GetHdc();
            RECT rc = new RECT(rect);
            DrawThemeBackground(ThemeHandle, hdc, partId, stateId, ref rc, ref rc);
            gfx.ReleaseHdc(hdc);
        }

        /// <summary>
        /// Gets the size of the specified theme part
        /// </summary>
        /// <param name="gfx">Graphics object to evaluate size for</param>
        /// <param name="partId">Theme part</param>
        /// <param name="stateId">Theme state</param>
        /// <returns>Size of the specified theme part</returns>
        public Size GetThemePartSize(Graphics gfx, int partId, int stateId)
        {
            RECT rc = new RECT();
            SIZE size = new SIZE();

            IntPtr hdc = gfx.GetHdc();
            GetThemePartSize(ThemeHandle, hdc, partId, stateId, ref rc,
            THEMESIZE.TS_TRUE, ref size);
            gfx.ReleaseHdc(hdc);
            return new Size(size.cx, size.cy);
        }

        /// <summary>
        /// Draws the background to the Explorer Bar
        /// </summary>
        /// <param name="gfx">Graphics to render to</param>
        /// <param name="rect">Bounding rectangle</param>
        /// <param name="style">Drawing style</param>
        /// <param name="backgroundStart">Custom start colour</param>
        /// <param name="backgroundEnd">Custom end colour</param>
        public void UxDrawBackground(Graphics gfx, Rectangle rect, Color backgroundStart, Color backgroundEnd)
        {
            // Use theme to draw the background
            IntPtr hdc = gfx.GetHdc();
            RECT rc = new RECT(rect);
            DrawThemeBackground(ThemeHandle, hdc, 0, 0, ref rc, ref rc);
            gfx.ReleaseHdc(hdc);
        }

        public bool UxDrawEdge(Graphics gfx, int partId, int stateId, Rectangle rect, Rectangle textRect, UxDrawEdgeEdgeTypes edge, UxDrawEdgeBorderFlags flags)
        {
            RECT rc = new RECT(rect);
            RECT trc = new RECT(textRect);
            bool success = false;
            IntPtr hdc = gfx.GetHdc();

            if (GetThemeBackgroundContentRect(ThemeHandle, hdc, partId, stateId, ref rc, out rc) == 0)
            {
                if (DrawThemeEdge(ThemeHandle, hdc, partId, stateId, ref rc, (uint)edge, (uint)flags, out trc) == 0)
                    success = true;
            }
            gfx.ReleaseHdc(hdc);
            return success;
        }


        public bool UxDrawText(Graphics gfx, int partId, int stateId, Rectangle rect, String text, int offset, UxDrawTextFlags align, bool useExtent)
        {
            bool success = false;
            IntPtr hTheme = IntPtr.Zero;
            RECT textRect = new RECT();
            RECT contRect = new RECT();
            RECT areaRect = new RECT();
            RECT rc = new RECT(rect);
            IntPtr hdc = gfx.GetHdc();

            if (GetThemeBackgroundContentRect(ThemeHandle, hdc, partId, stateId, ref rc, out textRect) == 0)
            {
                if (useExtent)
                {
                    areaRect = rc;
                    // get parent rect
                    GetThemeBackgroundContentRect(ThemeHandle, hdc, partId, stateId, ref areaRect, out contRect);
                    // calc text size
                    if (GetThemeTextExtent(ThemeHandle, hdc, partId, stateId, text, -1, (uint)align, ref areaRect, out textRect) == 0)
                    {
                        if ((contRect.Bottom - contRect.Top) < (textRect.Bottom - textRect.Top))
                            areaRect.Bottom = areaRect.Bottom + ((textRect.Bottom - textRect.Top) - (contRect.Bottom - contRect.Top));
                        if ((contRect.Right - contRect.Left - offset) < (textRect.Right - textRect.Left + 8)) 
                            areaRect.Right = areaRect.Right + ((textRect.Right - textRect.Left + 8) - (contRect.Right - contRect.Left - offset));
                    }
                }
            }
            // offset
            textRect.Left += offset;
            textRect.Right += offset;
            // draw text
            success = (DrawThemeText(ThemeHandle, hdc, partId, stateId, text, -1, (int)align, 0, ref textRect) == 0);
            gfx.ReleaseHdc(hdc);
            return success;
        }
    }
}

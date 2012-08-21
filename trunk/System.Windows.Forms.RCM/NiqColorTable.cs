using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Niq.Msd.Common
{
    public class NiqColorTable
    {
        public static Color Input_Border1 = ColorTranslator.FromHtml("#2F9BC5");
        public static Color Input_Border2 = ColorTranslator.FromHtml("#b8b8b8");
        public static Color Input_Border3 = ColorTranslator.FromHtml("#0072c6");
        
        public static Color ModuleList_BackGround = ColorTranslator.FromHtml("#2a5599");
        public static Color ModuleItem_BackGroundSelected = ColorTranslator.FromHtml("#ffffff");
        public static Color ModuleItem_BackGround = ColorTranslator.FromHtml("#2a5599");

        public static Color Group_BackGround= ColorTranslator.FromHtml("#ffffff");
        public static Color Group_RightBgColor = ColorTranslator.FromHtml("#f7924a");

        public static Color ModuleItem_Text = ColorTranslator.FromHtml("#ffffff");
        public static Color ModuleItem_TextSelected = ColorTranslator.FromHtml("#555555");

        public static Color TransparentColor = Color.Transparent;

        public static Color StandardColor_Yellow = Color.FromArgb(247, 146, 74);
        public static Color StandardColor_Blue = Color.FromArgb(47, 155, 197);
        public static Color StandardColor_Violet = Color.FromArgb(156, 34, 187);
        public static Color StandardColor_Gray1 = Color.FromArgb(243, 243, 243);
        public static Color StandardColor_Gray2 = Color.FromArgb(227, 227, 227);
    }
}

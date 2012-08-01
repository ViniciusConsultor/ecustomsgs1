using System.Collections;
using System.Text;

namespace ApplicationUtils.Utils
{
	/// <summary>
	/// Summary description for UmlautsHelper.
	/// </summary>
	public class UmlautsHelper
	{
		public static string ReplaceUmlauts(string type)
		{
			StringBuilder replacement = new StringBuilder(type);
			replacement = replacement.Replace("�", "ae");
			replacement = replacement.Replace("�", "ue");
			replacement = replacement.Replace("�", "oe");
			replacement = replacement.Replace("�", "Oe");
			replacement = replacement.Replace("�", "Ae");
			replacement = replacement.Replace("�", "Ue");
			return replacement.ToString();
		}

		public static string ReplaceUmlautsBidirectional(string type)
		{
			StringBuilder replacement = new StringBuilder(type);
			replacement = replacement.Replace("�", "__ae");
			replacement = replacement.Replace("�", "__ue");
			replacement = replacement.Replace("�", "__oe");
			replacement = replacement.Replace("�", "__Oe");
			replacement = replacement.Replace("�", "__Ae");
			replacement = replacement.Replace("�", "__Ue");
			replacement = replacement.Replace("/", "__PER");
			replacement = replacement.Replace(@"\", "__IPER");
			return replacement.ToString();
		}

		public static string RecoverUmlautsBidirectional(string type)
		{
			StringBuilder replacement = new StringBuilder(type);
			replacement = replacement.Replace("__ae", "�");
			replacement = replacement.Replace("__ue", "�");
			replacement = replacement.Replace("__oe", "�");
			replacement = replacement.Replace("__Oe", "�");
			replacement = replacement.Replace("__Ae", "�");
			replacement = replacement.Replace("__Ue", "�");
			replacement = replacement.Replace("__PER", "/");
			replacement = replacement.Replace("__IPER", @"\");
			return replacement.ToString();
		}

		public static string ReplaceUmlautsForHtml(string strValue)
		{
			StringBuilder replacement = new StringBuilder(strValue);
			replacement = replacement.Replace("�", "&auml;");
			replacement = replacement.Replace("�", "&uuml;");
			replacement = replacement.Replace("�", "&ouml;");
			replacement = replacement.Replace("�", "&Ouml;");
			replacement = replacement.Replace("�", "&Auml;");
			replacement = replacement.Replace("�", "&Uuml;");

			replacement = replacement.Replace("�", "&aacute;");
			replacement = replacement.Replace("�", "&Aacute;");
			replacement = replacement.Replace("�", "&agrave;");
			replacement = replacement.Replace("�", "&Agrave;");
			replacement = replacement.Replace("�", "&acirc;");
			replacement = replacement.Replace("�", "&Acirc;");
			replacement = replacement.Replace("�", "&aelig;");
			replacement = replacement.Replace("�", "&Aelig;");

			replacement = replacement.Replace("�", "&ccedil;");
			replacement = replacement.Replace("�", "&Ccedil;");

			replacement = replacement.Replace("�", "&eacute;");
			replacement = replacement.Replace("�", "&Eacute;");

			replacement = replacement.Replace("�", "&egrave;");
			replacement = replacement.Replace("�", "&Egrave;");

			replacement = replacement.Replace("�", "&ecirc;");
			replacement = replacement.Replace("�", "&Ecirc;");

			replacement = replacement.Replace("�", "&szlig;");


			return replacement.ToString();
		}

		public static string ReplaceHtmlUmlautCodes(string strValue)
		{
			StringBuilder replacement = new StringBuilder(strValue);
			replacement = replacement.Replace("&auml;", "�");
			replacement = replacement.Replace("&uuml;", "�");
			replacement = replacement.Replace("&ouml;", "�");
			replacement = replacement.Replace("&Ouml;", "�");
			replacement = replacement.Replace("&Auml;", "�");
			replacement = replacement.Replace("&Uuml;", "�");

			replacement = replacement.Replace("&aacute;", "�");
			replacement = replacement.Replace("&Aacute;", "�");
			replacement = replacement.Replace("&agrave;", "�");
			replacement = replacement.Replace("&Agrave;", "�");
			replacement = replacement.Replace("&acirc;", "�");
			replacement = replacement.Replace("&Acirc;", "�");
			replacement = replacement.Replace("&aelig;", "�");
			replacement = replacement.Replace("&Aelig;", "�");

			replacement = replacement.Replace("&ccedil;", "�");
			replacement = replacement.Replace("&Ccedil;", "�");

			replacement = replacement.Replace("&eacute;", "�");
			replacement = replacement.Replace("&Eacute;", "�");

			replacement = replacement.Replace("&egrave;", "�");
			replacement = replacement.Replace("&Egrave;", "�");

			replacement = replacement.Replace("&ecirc;", "�");
			replacement = replacement.Replace("&Ecirc;", "�");

			replacement = replacement.Replace("&szlig;", "�");

			replacement = replacement.Replace("%28", "(");
			replacement = replacement.Replace("%29", ")");
			replacement = replacement.Replace("%2F", "/");
			replacement = replacement.Replace("%20", " ");
			replacement = replacement.Replace("%E4", "�");
			replacement = replacement.Replace("%FC", "�");
			replacement = replacement.Replace("%FC", "�");
			replacement = replacement.Replace("%F6", "�");
			replacement = replacement.Replace("%DC", "�");
			replacement = replacement.Replace("%D6", "�");
			replacement = replacement.Replace("%C4", "�");
      replacement = replacement.Replace("%2C", ",");
      replacement = replacement.Replace("%26", "&");
      replacement = replacement.Replace("%2B", "+");
      replacement = replacement.Replace("%2D", "-");

			return replacement.ToString();
		}


		public class StringWithUmlautsComparer : IComparer
		{
			private static readonly char[] umlauts = new char[] {'�', '�', '�', '�', '�', '�'};
			private static readonly char[] umlauts_Replacemet = new char[] {'a', 'A', 'o', 'O', 'u', 'U'};

			public int Compare(object strA, object strB)
			{
				return Compare(strA as string, strB as string);
			}

			private static string ReplaceUmlauts(string strToModifie)
			{
				string res = strToModifie;
				for (int i = 0; i < umlauts.Length; i++)
				{
					res = res.Replace(umlauts[i], umlauts_Replacemet[i]);
				}
				return res;
			}

			public static int Compare(string str1, string str2)
			{
				if ((str1 == null) || (str2 == null)) return 0;
				string x = ReplaceUmlauts(str1);
				string y = ReplaceUmlauts(str2);
				return string.Compare(x, y);
			}
		}
	}


	/*
    u228? -> &auml;   
    u196? -> &Auml;
    u235? -> &euml;
    u203? -> &Euml;
    u252? -> &uuml;
    u220? -> &Uuml;
    u246? -> &ouml;
    u214? -> &Ouml;
    */
}
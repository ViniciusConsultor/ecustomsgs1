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
			replacement = replacement.Replace("ä", "ae");
			replacement = replacement.Replace("ü", "ue");
			replacement = replacement.Replace("ö", "oe");
			replacement = replacement.Replace("Ö", "Oe");
			replacement = replacement.Replace("Ä", "Ae");
			replacement = replacement.Replace("Ü", "Ue");
			return replacement.ToString();
		}

		public static string ReplaceUmlautsBidirectional(string type)
		{
			StringBuilder replacement = new StringBuilder(type);
			replacement = replacement.Replace("ä", "__ae");
			replacement = replacement.Replace("ü", "__ue");
			replacement = replacement.Replace("ö", "__oe");
			replacement = replacement.Replace("Ö", "__Oe");
			replacement = replacement.Replace("Ä", "__Ae");
			replacement = replacement.Replace("Ü", "__Ue");
			replacement = replacement.Replace("/", "__PER");
			replacement = replacement.Replace(@"\", "__IPER");
			return replacement.ToString();
		}

		public static string RecoverUmlautsBidirectional(string type)
		{
			StringBuilder replacement = new StringBuilder(type);
			replacement = replacement.Replace("__ae", "ä");
			replacement = replacement.Replace("__ue", "ü");
			replacement = replacement.Replace("__oe", "ö");
			replacement = replacement.Replace("__Oe", "Ö");
			replacement = replacement.Replace("__Ae", "Ä");
			replacement = replacement.Replace("__Ue", "Ü");
			replacement = replacement.Replace("__PER", "/");
			replacement = replacement.Replace("__IPER", @"\");
			return replacement.ToString();
		}

		public static string ReplaceUmlautsForHtml(string strValue)
		{
			StringBuilder replacement = new StringBuilder(strValue);
			replacement = replacement.Replace("ä", "&auml;");
			replacement = replacement.Replace("ü", "&uuml;");
			replacement = replacement.Replace("ö", "&ouml;");
			replacement = replacement.Replace("Ö", "&Ouml;");
			replacement = replacement.Replace("Ä", "&Auml;");
			replacement = replacement.Replace("Ü", "&Uuml;");

			replacement = replacement.Replace("á", "&aacute;");
			replacement = replacement.Replace("Á", "&Aacute;");
			replacement = replacement.Replace("à", "&agrave;");
			replacement = replacement.Replace("À", "&Agrave;");
			replacement = replacement.Replace("â", "&acirc;");
			replacement = replacement.Replace("Â", "&Acirc;");
			replacement = replacement.Replace("æ", "&aelig;");
			replacement = replacement.Replace("Æ", "&Aelig;");

			replacement = replacement.Replace("ç", "&ccedil;");
			replacement = replacement.Replace("Ç", "&Ccedil;");

			replacement = replacement.Replace("é", "&eacute;");
			replacement = replacement.Replace("É", "&Eacute;");

			replacement = replacement.Replace("è", "&egrave;");
			replacement = replacement.Replace("È", "&Egrave;");

			replacement = replacement.Replace("ê", "&ecirc;");
			replacement = replacement.Replace("Ê", "&Ecirc;");

			replacement = replacement.Replace("ß", "&szlig;");


			return replacement.ToString();
		}

		public static string ReplaceHtmlUmlautCodes(string strValue)
		{
			StringBuilder replacement = new StringBuilder(strValue);
			replacement = replacement.Replace("&auml;", "ä");
			replacement = replacement.Replace("&uuml;", "ü");
			replacement = replacement.Replace("&ouml;", "ö");
			replacement = replacement.Replace("&Ouml;", "Ö");
			replacement = replacement.Replace("&Auml;", "Ä");
			replacement = replacement.Replace("&Uuml;", "Ü");

			replacement = replacement.Replace("&aacute;", "á");
			replacement = replacement.Replace("&Aacute;", "Á");
			replacement = replacement.Replace("&agrave;", "à");
			replacement = replacement.Replace("&Agrave;", "À");
			replacement = replacement.Replace("&acirc;", "â");
			replacement = replacement.Replace("&Acirc;", "Â");
			replacement = replacement.Replace("&aelig;", "æ");
			replacement = replacement.Replace("&Aelig;", "Æ");

			replacement = replacement.Replace("&ccedil;", "ç");
			replacement = replacement.Replace("&Ccedil;", "Ç");

			replacement = replacement.Replace("&eacute;", "é");
			replacement = replacement.Replace("&Eacute;", "É");

			replacement = replacement.Replace("&egrave;", "è");
			replacement = replacement.Replace("&Egrave;", "È");

			replacement = replacement.Replace("&ecirc;", "ê");
			replacement = replacement.Replace("&Ecirc;", "Ê");

			replacement = replacement.Replace("&szlig;", "ß");

			replacement = replacement.Replace("%28", "(");
			replacement = replacement.Replace("%29", ")");
			replacement = replacement.Replace("%2F", "/");
			replacement = replacement.Replace("%20", " ");
			replacement = replacement.Replace("%E4", "ä");
			replacement = replacement.Replace("%FC", "ü");
			replacement = replacement.Replace("%FC", "ü");
			replacement = replacement.Replace("%F6", "ö");
			replacement = replacement.Replace("%DC", "Ü");
			replacement = replacement.Replace("%D6", "Ö");
			replacement = replacement.Replace("%C4", "Ä");
      replacement = replacement.Replace("%2C", ",");
      replacement = replacement.Replace("%26", "&");
      replacement = replacement.Replace("%2B", "+");
      replacement = replacement.Replace("%2D", "-");

			return replacement.ToString();
		}


		public class StringWithUmlautsComparer : IComparer
		{
			private static readonly char[] umlauts = new char[] {'ä', 'Ä', 'ö', 'Ö', 'ü', 'Ü'};
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
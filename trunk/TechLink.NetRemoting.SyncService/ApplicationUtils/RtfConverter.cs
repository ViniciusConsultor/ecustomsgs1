using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace ApplicationUtils.Utils
{
	/// <summary>
	/// Summary description for RtfToHtml.
	/// </summary>
	public class RtfConverter
	{
		#region InnerClasses

		public abstract class HtmlType
		{
			private readonly string tag, closingtag;
			private readonly string kw, kwclose;

			protected HtmlType(string htmltag, string rtfkw) : this(htmltag, rtfkw, null)
			{
			}

			protected HtmlType(string htmltag, string rtfkw, string rtfkwclose)
			{
				tag = htmltag;
				kw = rtfkw;
				kwclose = rtfkwclose;
				if (kwclose == null)
				{
					kwclose = kw + "0";
				}
				int i = tag.IndexOf(' ');
				closingtag = i == -1 ? tag : tag.Substring(0, i);
			}

			public bool IsOpen = false;
			public StringBuilder sb;

			public void Close()
			{
				if (IsOpen)
				{
					sb.Append("</");
					sb.Append(closingtag);
					sb.Append(">");
					IsOpen = false;
					value = 0;
				}
			}

			protected int value = 0;

			public bool CheckChanged(ref string kw)
			{
				if (kw == kwclose &&
				    kw != "f0")
				{
					Close();
				}
				else if (kw.StartsWith(this.kw))
				{
					string substring = kw.Substring(this.kw.Length);
					int vv = -1;
					if (substring != "")
					{
						int.TryParse(substring, out vv);
					}
					int v = (kw.Length == this.kw.Length) ? -1 : vv;

					if (v != value ||
					    kw == "f0") //f0 has a special treatment
					{
						Close();
						value = v;

						sb.Append("<");
						sb.Append(tag);
						Addvalue();
						sb.Append(">");
						IsOpen = true;
					}
				}
				else
				{
					return false;
				}
				return true;
			}

			protected virtual void Addvalue()
			{
			}
		}

		public class FontSize : HtmlType
		{
			public FontSize() : base("span", "fs")
			{
			}

			protected override void Addvalue()
			{
				sb.Append(" style='font-size:");
				sb.Append(value/2); //as to rtf specs, value is given in half-points
				sb.Append("pt'");
			}
		}

		public class FontFace : HtmlType
		{
			public FontFace() : base("span", "f")
			{
			}

			protected override void Addvalue()
			{
//				if (FontTable.Fonts[value.ToString()] != null)
//				{
				sb.Append(" style='font-family:");
				sb.Append((string) FontTable.Fonts[value.ToString()]);
				sb.Append("'");
//				}
			}
		}

		public class FontTable
		{
			private static Hashtable fonts = null;
			private static string txt = "";

			public static Hashtable Fonts
			{
				get
				{
					if (fonts == null)
					{
						fonts = new Hashtable();
						ReadTable();
					}
					return fonts;
				}
			}

			public static void LoadRTF(string rtfText)
			{
				txt = rtfText;
			}

			private static void ReadTable()
			{
				string fonttbl = @"{\fonttbl";
				int startTable = txt.IndexOf(fonttbl);
				int endTable = txt.IndexOf(";}}", startTable) + 3;
				int startPos = txt.IndexOf("{\\f", startTable + fonttbl.Length);
				int endPos = startPos;
				string fontText = "", fontIndex = "";
				while (startPos < endTable)
				{
					endPos = txt.IndexOf(";}", startPos);
					if (startPos == endPos)
					{
						break;
					}
					fontText = txt.Substring(startPos + 2, endPos - startPos - 2);
					fontIndex = fontText.Substring(1, fontText.IndexOf("\\") - 1);
					fontText = fontText.Substring(fontText.LastIndexOf("\\") + 1);
					startPos = fontText.IndexOf("}");
					if (startPos == -1)
					{
						startPos = fontText.IndexOf(" ");
					}
					fontText = fontText.Substring(startPos + 1);
					startPos = endPos;
					fonts[fontIndex] = fontText;
				}
			}
		}

		public class FontColor : HtmlType
		{
			public FontColor() : base("font color", "cf")
			{
			}

			private void hex(int i)
			{
				if (i < 16)
				{
					sb.Append("0");
				}
				sb.Append(i.ToString("x"));
			}

			protected override void Addvalue()
			{
				sb.Append("=#");
				Color c = Schema[value - 1];
				hex(c.R);
				hex(c.G);
				hex(c.B);
			}

			public Color[] Schema = null;
		}

		public class Bold : HtmlType
		{
			public Bold() : base("b", "b")
			{
			}
		}

//		public class BulletType:HtmlType
//		{
//			public BulletType() : base("li", "pnlvblt")
//			{
//			}
//		}

		public class Italic : HtmlType
		{
			public Italic() : base("i", "i")
			{
			}
		}

		public class Underline : HtmlType
		{
			public Underline() : base("u", "ul", "ulnone")
			{
			}
		}

		public enum mode
		{
			Radio,
			Checkbox,
			Button,
			Hyperlink
		}

		public enum StartAs
		{
			Hidden,
			Scrollable,
			Full
		}


		private class Tabber
		{
			private readonly int indent;
			private readonly StringBuilder htmlString;
			private readonly StringBuilder plainTextString;
			private readonly Stack divs = new Stack();

			public int OpenDivs
			{
				get
				{
					return divs.Count;
				}
			}

			public Tabber(int indent, StringBuilder htmlSB, StringBuilder plainTextSB)
			{
				this.indent = indent;
				htmlString = htmlSB;
				plainTextString = plainTextSB;
			}

			public int PrevCount = 0;
			public int Count = 0;
			private bool newline = false;
			public bool TextBegun = false;

			public bool NewLine
			{
				get
				{
					return newline;
				}
				set
				{
					newline = value;
					if (value)
					{
						Count = 0;
					}
				}
			}

			public void Check()
			{
				if (!(newline || !TextBegun))
				{
					return;
				}
				TextBegun = true;
				if (newline && Count == PrevCount)
				{
					htmlString.Append("<br>");
					plainTextString.Append("\n");
				}
				else
				{
					while (Count < PrevCount)
					{
						divs.Pop();
						htmlString.Append("</" + block + ">");
						PrevCount = divs.Count > 0 ? (int) divs.Peek() : 0;
					}
					if (Count > PrevCount)
					{
						htmlString.Append("<" + block + " style=\"margin-left:");
						htmlString.Append(indent*(Count - PrevCount));
						htmlString.Append("pt\">");
						divs.Push(Count);
					}
					PrevCount = Count;
				}
				newline = false;
			}

			public void Add()
			{
				if (newline || !TextBegun)
				{
					Count++;
				}
				else
				{
					for (int t = Count*4; t > 0; t--)
					{
						htmlString.Append(space);
						plainTextString.Append(" ");
					}
				}
			}
		}

		#endregion

		public enum Formats
		{
			Html,
			PlainText
		}

		private const string block = "span";
		private const string space = "&nbsp";
		private const int TabSpaces = 4;

		private static readonly
			char[] ToReplace = "<>\"&".ToCharArray();

		private static readonly
			string[] ReplaceWith = {"&lt", "&gt", "&quot", "&amp"}; //indent-tabs can be used, other tabs are replaced by a space

		private const string IgnoreList = "\r\n{}";

		private static string inttohex(decimal d)
		{
			int i = (int) d;
			string s = i.ToString("x");
			s.PadLeft(6, '0');
			return "#" + s;
		}

		private static ArrayList htmltypestypes = null;
		private static readonly FontFace fontFace = new FontFace();
		private static readonly FontSize fontSize = new FontSize();
		private static readonly FontColor fontColor = new FontColor();
		private static readonly Bold bold = new Bold();
		private static readonly Underline underline = new Underline();
		private static readonly Italic italic = new Italic();

		private static void Initialize()
		{
			htmltypestypes = new ArrayList();
			Type t = fontColor.GetType();
			htmltypestypes.Add(t);

			t = bold.GetType();
			htmltypestypes.Add(t);

			t = underline.GetType();
			htmltypestypes.Add(t);

			t = italic.GetType();
			htmltypestypes.Add(t);

			t = fontSize.GetType();
			htmltypestypes.Add(t);

			t = fontFace.GetType();
			htmltypestypes.Add(t);
		}

		private static int getHexDigit(char hexdigit)
		{
			if (Char.IsDigit(hexdigit))
			{
				return int.Parse(hexdigit.ToString());
			}
			else if (Char.IsLetter(hexdigit))
			{
				int pos = "abcdef".IndexOf(Char.ToLower(hexdigit));
				if (pos != -1)
				{
					return 10 + pos;
				}
			}
			return -1;
		}

		private static string hex2dec(string hex)
		{
			int rez = 0;
			int digit = getHexDigit(hex[0]);
			if (digit != -1)
			{
				rez += 16*digit;
			}
			digit = getHexDigit(hex[1]);
			if (digit != -1)
			{
				rez += digit;
			}
			return rez.ToString().PadLeft(2, '0');
		}

		public static string Convert(string rtfText, Formats format)
		{
			if (rtfText == null ||
			    rtfText.Length == 0)
			{
				return "";
			}

			if (htmltypestypes == null)
			{
				Initialize();
			}

			bool bullets = false;
			bool liOpen = false;

			string txtHTML = "";

			StringBuilder htmlString = new StringBuilder();
			StringBuilder plainTextString = new StringBuilder();

			ArrayList htmltypes = new ArrayList();
			foreach (Type t in htmltypestypes)
			{
				HtmlType ht = (HtmlType) Activator.CreateInstance(t);
				ht.sb = htmlString;
				htmltypes.Add(ht);
			}

			int ir;

			//these are consts, kept in consts to make them ui-editable at some point
			//const string borderstyle="solid";
			//const bool usecopy = true;
			const int tabindent = 20;

			//moved from const to editable :)
			string bordercolor = inttohex(0),
			       backcolor = inttohex(Color.White.ToArgb());

			//divcount keeps track of the number of open <div> blocks to ensure they are all closed at the end
			int divcount = 0 /*,
			//	startas=0*/;

			#region Margin/border, start

			//start div with margins and border
			htmlString.Append(@"<" + block + " style='");
			htmlString.Append("'>");
			divcount++;

			#endregion

			#region start of actual text-section

			htmlString.Append("<" + block + " style=\"overflow:auto;");
			//get the font info //Font settings (size and font-family are set only once in this version)

			htmlString.Append("font-size:");
			htmlString.Append(((int) (GDIConstants.UIStandardFont.Size*1.5)).ToString());
			htmlString.Append(";font-family:'" + GDIConstants.UIStandardFont.FontFamily.Name + "'");
			//Backcolor
			htmlString.Append("\">");
			divcount++;

			#endregion

			FontTable.LoadRTF(rtfText);

			string txt = rtfText;

			int spacecount = 0, len = txt.Length - 2, pstep = len/5;
			Tabber tab = new Tabber(tabindent, htmlString, plainTextString);
			try
			{
				#region code

				int k = 1;
				if (txt[0] != '{')
				{
					k = 0;
					len = txt.Length;
				}
				for (int i = k; i < len; i++)
					//Start from first position, skip first "{", len is one less then length: skip last "}"
				{
					char c = txt[i];
					if (IgnoreList.IndexOf(c) != -1)
					{
						continue;
					}

					if (c == '\\')
					{
						//keyword?
						c = txt[++i];
						if (c == '\'' && txt[i + 1] != 'B') //umlaut?
						{
							//flush all waiting spaces
							if (spacecount > 0)
							{
								if (spacecount == 1)
								{
									htmlString.Append(" ");
									plainTextString.Append(" ");
									spacecount = 0;
								}
								else
								{
									for (; spacecount > 0; spacecount--)
									{
										htmlString.Append(space);
										plainTextString.Append(" ");
									}
								}
							}
							string hex = txt[++i] + txt[++i].ToString();
							string umlaut = hex2dec(hex);
							htmlString.Append("&#" + umlaut + ";");
							int umlautCode = int.Parse(umlaut);
							plainTextString.Append((char) umlautCode);
							continue;
						}
						if (@"\{}".IndexOf(c) == -1) //check for escape sequence
						{
							//no escape sequence->keyword

							#region keywords

							int kwstart = i;
							while (++i < len && " {\\\r\n};".IndexOf(txt[i]) == -1)
							{
//								Debug.WriteLine(i + "test");
							}

							string kw = txt.Substring(kwstart, i - kwstart);
							if (kw == "par")
							{
								if (tab.NewLine)
								{
									htmlString.Append("<br/>");
									plainTextString.Append("\n");
								}
								else
								{
									tab.NewLine = true;
								}
								if (bullets && liOpen)
								{
									liOpen = false;
									htmlString.Append("</li>");
								}
								spacecount = 0;
							}
//							else if (kw == "tab")
//							{
//								tab.Add();
//							}
							else if (kw == "pnlvlblt")
							{
//								htmlString.Append("<li>");
								bullets = true;
							}
							else if (kw == "pard")
							{
								bullets = false;
							}
							else if (kw == "pntext") //skip section {\\pntext\\f1\\'B7\\tab}
							{
								while (txt[i] != '}')
								{
									i++;
								}
							}
							else if (kw == "colortbl")
							{
								//colourtable-> read out cols.
								ArrayList al = new ArrayList();
								i += 2;
								Regex rx = new Regex(@"\\red(\d+)\\green(\d+)\\blue(\d+)");
								while (txt[i] != '}')
								{
									kwstart = i;
									while (txt[++i] != ';')
									{
										;
									}
									Match m = rx.Match(txt, kwstart, i - kwstart);
									if (!m.Success)
									{
										throw new Exception("Unexpected error: Could not parse colors");
									}
									al.Add(Color.FromArgb(
									       	int.Parse(m.Groups[1].Value),
									       	int.Parse(m.Groups[2].Value),
									       	int.Parse(m.Groups[3].Value)));
									i++;
								}
								foreach (HtmlType ht in htmltypes)
								{
									if (ht is FontColor)
									{
										((FontColor) ht).Schema = (Color[]) al.ToArray(typeof (Color));
									}
								}
							}
							else if (txt[i] == '{' && (kw.IndexOf("fs") == -1 && kw.IndexOf("cf") == -1))
								//sa nu imi ignore sectiuni de {} dupa anumite tag-uri
							{
								int cnt = 1;
								for (i++; cnt > 0; i++)
								{
									if (txt[i] == '{')
									{
										cnt++;
									}
									else if (txt[i] == '}')
									{
										cnt--;
									}
								}
								i--;
							}
							else
							{
								foreach (HtmlType ht in htmltypes)
								{
									if (ht.CheckChanged(ref kw))
									{
										//tab.Check();
										break;
									}
								}
							}

							if (txt[i] == '\\')
							{
								i--;
							}
							continue;

							#endregion
						}
					}

					tab.Check();

					#region space (one space is used normally (' '), more than one as a collection of  &nbsp )

					if (c == ' ')
					{
						spacecount++;
						continue;
					}
					else if (spacecount > 0)
					{
						if (spacecount == 1)
						{
							htmlString.Append(" ");
							plainTextString.Append(" ");
							spacecount = 0;
						}
						else
						{
							if (spacecount > 100)
							{
								spacecount = 100; // limit the number of consecutive spaces in the text. It might be a bug
							}
							for (; spacecount > 0; spacecount--)
							{
								htmlString.Append(space);
								plainTextString.Append(" ");
							}
						}
					}

					#endregion

					if (bullets && liOpen == false)
					{
						liOpen = true;
						htmlString.Append("<li>");
					}

					ir = Array.IndexOf(ToReplace, c);
					if (ir != -1)
					{
						htmlString.Append(ReplaceWith[ir]);
						plainTextString.Append(" ");
					}
					else
					{
						htmlString.Append(c);
						plainTextString.Append(c);
					}
				}

				#endregion

				if (bullets && liOpen)
				{
					liOpen = false;
					htmlString.Append("</li>");
				}

				//Close all open html-tags
				foreach (HtmlType ht in htmltypes)
				{
					ht.Close();
				}

				//Close all open div tags
				divcount += tab.OpenDivs;
				for (; divcount > 0; divcount--)
				{
					htmlString.Append("</" + block + ">");
				}


				switch (format)
				{
					case Formats.Html:
						txtHTML = htmlString.ToString();
						txtHTML = UmlautsHelper.ReplaceUmlautsForHtml(txtHTML);
						break;
					case Formats.PlainText:
						txtHTML = plainTextString.ToString();
						break;
				}

        if (txtHTML.Length > 70)
        {
            List<char> newTextWithSpaces = new List<char>();
            int ci = 0;
            for (int i = 0; i < txtHTML.Length;i++)
            {
              if (txtHTML[i] != ' ') ci++;
              else ci = 0;

              if(ci > 69)
              {
                newTextWithSpaces.Add(' ');
                ci = 0;
              }
              newTextWithSpaces.Add(txtHTML[i]);
            }
          txtHTML = new string(newTextWithSpaces.ToArray());
        }

			  return txtHTML;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message + "\n\n" + ex.StackTrace);
				return "";
			}
		}

		public static string Text2Rft(string plainText)
		{
			string firstPart =
				"{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Tahoma;}}\r\n{\\colortbl ;\\red0\\green0\\blue0;}\r\n\\viewkind4\\uc1\\pard\\cf1\\f0\\fs20 ";
			string secondPart = "\\cf0\\par\r\n}\r\n\0";
			return firstPart + plainText + secondPart;
		}
	}
}
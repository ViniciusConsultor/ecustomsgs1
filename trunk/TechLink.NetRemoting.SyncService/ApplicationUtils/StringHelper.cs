using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace ApplicationUtils.Utils
{
	/// <summary>
	/// Summary description for StringHelper.
	/// </summary>
	public static class StringHelper
	{
		public static char[] WordsSeparator = " /\\+-?".ToCharArray();
		public const string WRAPPING_SEPARATOR = "\r\n";
		private const int numberOfAdditionNo = 4;
		//returns the positions of the found occurences
		public static int[] FindStringInText(string text, string findText, bool matchCase, bool matchWholeWord)
		{
			ArrayList foundIndexes = new ArrayList();

			int startIdx = 0;
			string smallCapsText = text.ToLower();
			string smallCapsFindText = findText.ToLower();
			while (startIdx < text.Length)
			{
				int idx = smallCapsText.IndexOf(smallCapsFindText, startIdx);
				if (idx == -1)
					break;

				startIdx = idx + findText.Length;

				if (matchCase)
				{
					if (findText != text.Substring(idx, findText.Length))
						continue;
				}

				if (matchWholeWord)
				{
					if (idx > 0)
					{
						if (text[idx - 1].ToString().IndexOfAny(WordsSeparator) != 0)
							continue;
					}

					if (startIdx < text.Length - 1)
					{
						if (text[startIdx].ToString().IndexOfAny(WordsSeparator) != 0)
							continue;
					}
				}

				foundIndexes.Add(idx);
			}

			return (int[]) foundIndexes.ToArray(typeof (int));
		}

		#region text wrapping stastic methods

		/// <summary>
		/// Wraps the text.
		/// </summary>
		/// <param name="textToWrap">The text to wrap.</param>
		/// <param name="maxChars">The max chars on a line.</param>
		/// <param name="separator">The separator.</param>
		/// <returns>wrapped text</returns>
		public static string WrapText(string textToWrap, int maxChars, string separator)
		{
			if (textToWrap.Length < maxChars)
			{
				return textToWrap;
			}
			string[] words = textToWrap.Split(new char[] {' '});
			StringBuilder sentence = new StringBuilder("");
			StringBuilder phrase = new StringBuilder("");
			foreach (string word in words)
			{
				if (phrase.Length == 0 || phrase.Length + word.Length + 1 > maxChars)
				{
					if (sentence.Length > 0)
					{
						sentence.Append(separator);
					}
					sentence.Append(phrase);
					if (word.Length > maxChars)
					{
						StringBuilder sb = DevideString(word, maxChars, separator);
						phrase = sb;
					}
					else
					{
						phrase = new StringBuilder(word);
					}
				}
				else
				{
					phrase.Append(" ");
					phrase.Append(word);
				}
			}
			if (sentence.Length > 0)
			{
				sentence.Append(separator);
			}
			sentence.Append(phrase);
			return sentence.ToString();
		}

		/// <summary>
		/// Wraps the text.Use as separator WRAPPING_SEPARATOR witch has value "\r\n"
		/// </summary>
		/// <param name="textToWrap">The text to wrap.</param>
		/// <param name="maxChars">The max chars on a line.</param>
		/// <returns>Wrapped text</returns>
		public static string WrapText(string textToWrap, int maxChars)
		{
			return WrapText(textToWrap, maxChars, WRAPPING_SEPARATOR);
		}

		/// <summary>
		/// Gets the lines list from the wrapped text.
		/// </summary>
		/// <param name="wrappedText">The wrapped text.</param>
		/// <param name="separator">The separator.</param>
		/// <returns></returns>
		public static ArrayList GetLinesList(string wrappedText, string separator)
		{
			ArrayList result = new ArrayList();
			//			wrappedText.Replace(separator,""); 
			string[] lines = wrappedText.Split(separator.ToCharArray());
			foreach (string s in lines)
			{
				if (s.Length > 0)
					result.Add(s);
			}
			return result;
		}

		/// <summary>
		/// Gets the lines list from the wrapped text;Use as separator WRAPPING_SEPARATOR witch has value "\r\n"
		/// </summary>
		/// <param name="wrappedText">The wrapped text.</param>
		/// <returns></returns>
		public static ArrayList GetLinesList(string wrappedText)
		{
			return GetLinesList(wrappedText, WRAPPING_SEPARATOR);
		}

		private static StringBuilder DevideString(string str, int maxChar, string separator)
		{
			StringBuilder sb = new StringBuilder(str.Trim());
			StringBuilder res = new StringBuilder("");
			string line = "";
			while (sb.ToString().Length > 0)
			{
				int m = sb.ToString().Length >= maxChar ? maxChar : sb.ToString().Length;
				line = sb.ToString().Substring(0, m);
				sb.Remove(0, m);
				//				sb = sb.Replace(line.ToString(),string.Empty);
				res.Append(line);
				res.Append(separator);
			}
			res.Remove(res.Length - separator.Length, separator.Length);
			return res;
		}

		//
		//		public static string RestrictLinesNumber(ArrayList linesList,int maxLines,string separator)
		//		{
		//			StringBuilder result = new StringBuilder("");
		//			int i = 1;
		//			foreach (string line in linesList)
		//			{
		//				if(i<=maxLines)
		//				{
		//					result.Append(line);
		//					result.Append(separator); 
		//				}
		//				else
		//				{
		//					break;
		//				}
		//				i++;
		//			}
		//			return result.ToString(); 
		//		}
		//		public static string RestrictLinesNumber(ArrayList linesList,int maxLines)
		//		{
		//			return RestrictLinesNumber(linesList, maxLines,WRAPPING_SEPARATOR );
		//		}

		#endregion

		/// <summary>
		/// Select a string from strArray that is the most like str
		/// </summary>
		public static string Select(string[] strArray, string str)
		{
			string word = str.ToLower().Trim();
			List<string> wordList = new List<string>();
			string selectedWord = string.Empty;

			foreach (string s in strArray)
			{
				wordList.Add(s.ToLower().Trim());
			}

			List<string> wordsContainingWord = new List<string>();
			foreach (string s in wordList)
			{
				if (s.Contains(word) || word.Contains(s))
				{
					wordsContainingWord.Add(s);
				}
			}

			if (wordsContainingWord.Count == 1)
			{
				selectedWord = wordsContainingWord[0];
			}
			else
			{
				SortedDictionary<int, string> indexes = new SortedDictionary<int, string>();
				foreach (string s in wordsContainingWord)
				{
					int idx = -1;
					if (s.Contains(word))
					{
						idx = s.IndexOf(word);
					}
					else if (word.Contains(s))
					{
						idx = word.IndexOf(s);
					}
					if (!indexes.ContainsKey(idx))
					{
						indexes.Add(idx, s);
					}
					else
					{
						string existent = indexes[idx];

						if (existent.Length - word.Length > s.Length - word.Length)
						{
							indexes[idx] = s;
						}
					}
				}
				if (indexes.Count > 0)
				{
					selectedWord = indexes[0];
				}
				else
				{
				}
			}

			foreach (string originalStr in strArray)
			{
				if (originalStr.ToLower().Trim() == selectedWord)
				{
					selectedWord = originalStr;
				}
			}

			return selectedWord;
		}

		/// <summary>
		/// Returns the most similar string with word from list
		/// </summary>
		/// <param name="list"></param>
		/// <param name="word"></param>
		/// <returns></returns>
		public static string GetTheMostSimilar(ICollection<string> list, string word)
		{
			int minDist=int.MaxValue;
			string similar = string.Empty; 

			foreach (string s in list)
			{
				int d = LevenshteinDistance(s, word);
				if(d < minDist)
				{
					minDist = d;
					similar = s;
				}
			}
			
			return similar;
		}

		/// <summary>
		/// Calculates the degree of similarity between the names of 2 persons. Returns 0 if the names are very similar and int.MaxValue if no similarity.
		/// </summary>
		/// <param name="person1FirstName"></param>
		/// <param name="person1LastName"></param>
		/// <param name="person2FirstName"></param>
		/// <param name="person2LastName"></param>
		/// <returns></returns>
		public static int SimilarityBetweenNames(string person1FirstName,string person1LastName,string person2FirstName,string person2LastName)
		{
			string p1FirstName = person1FirstName.ToLower().Trim();
      string p2FirstName = person2FirstName.ToLower().Trim();
      string p1LastName = person1LastName.ToLower().Trim();
			string p2LastName = person2LastName.ToLower().Trim();

			string p1FullName_variant1 = p1FirstName + p1LastName;
			string p2FullName_variant1 = p2FirstName + p2LastName;
      string p1FullName_variant2 = p1LastName + p1FirstName;
      string p2FullName_variant2 = p2LastName + p2FirstName;

			int[] vals = new int[4];

			int p1FullName_variant1_p2FullName_variant1 = LevenshteinDistance(p1FullName_variant1,p2FullName_variant2);
			if(p1FullName_variant1_p2FullName_variant1 ==0)
			{
				return p1FullName_variant1_p2FullName_variant1;
			}
			vals[0] = p1FullName_variant1_p2FullName_variant1;

			int p1FullName_variant1_p2FullName_variant2 = LevenshteinDistance(p1FullName_variant1,p2FullName_variant2);
			if(p1FullName_variant1_p2FullName_variant2 ==0)
			{
				return p1FullName_variant1_p2FullName_variant2;
			}
			vals[1] = p1FullName_variant1_p2FullName_variant2;

			int p1FullName_variant2_p2FullName_variant1 = LevenshteinDistance(p1FullName_variant2,p2FullName_variant1);
			if(p1FullName_variant2_p2FullName_variant1 ==0)
			{
				return p1FullName_variant2_p2FullName_variant1;
			}

			vals[2] = p1FullName_variant2_p2FullName_variant1;

			int p1FullName_variant2_p2FullName_variant2 = LevenshteinDistance(p1FullName_variant2,p2FullName_variant2);

			if (p1FullName_variant2_p2FullName_variant2 ==0)
			{
				return p1FullName_variant2_p2FullName_variant2;
			}

			vals[3] = p1FullName_variant2_p2FullName_variant2;
      
			int p1FirstName_p2FirstName = LevenshteinDistance(p1FirstName, p2FirstName); ;
      int p1FirstName_p2LastName = LevenshteinDistance(p1FirstName, p2LastName);
      int p1LastName_p2LastName = LevenshteinDistance(p1LastName, p2LastName);
			int p1LastName_p2FirstName = LevenshteinDistance(p1LastName, p2FirstName);

			if(p1FirstName == string.Empty)
			{
				if(p1LastName_p2LastName == 0 || p1LastName_p2FirstName==0)
				{
					return 2;
				}
			}

			if (p1LastName == string.Empty)
			{
				if (p1FirstName_p2FirstName == 0 || p1FirstName_p2LastName == 0)
				{
					return 2;
				}
			}

			if (p2FirstName == string.Empty)
			{
				if (p1FirstName_p2LastName == 0 || p1LastName_p2LastName == 0)
				{
					return 2;
				}
			}

			if (p2LastName == string.Empty)
			{
				if (p1FirstName_p2FirstName == 0 || p1LastName_p2FirstName == 0)
				{
					return 2;
				}
			}

			Array.Sort(vals);

			return vals[0];
			
		}

		public static int LevenshteinDistance(string word1, string word2)
		{
			int[,] d; // matrix
			int n; // length of s
			int m; // length of t
			int i; // iterates through s
			int j; // iterates through t
			char s_i; // ith character of s
			char t_j; // jth character of t
			int cost; // cost

			// Step 1

			n = word1.Length;
			m = word2.Length;
			if (n == 0)
			{
				return m;
			}
			if (m == 0)
			{
				return n;
			}
//            d = new int[n + 1][m + 1]
			d = new int[n + 1,m + 1];


			// Step 2

			for (i = 0; i <= n; i++)
			{
				d[i, 0] = i;
			}

			for (j = 0; j <= m; j++)
			{
				d[0, j] = j;
			}

			// Step 3

			for (i = 1; i <= n; i++)
			{
				s_i = word1[i - 1];

				// Step 4

				for (j = 1; j <= m; j++)
				{
					t_j = word2[j - 1];

					// Step 5

					if (s_i == t_j)
					{
						cost = 0;
					}
					else
					{
						cost = 1;
					}

					// Step 6

					d[i, j] = Minimum(d[i - 1, j] + 1, d[i, j - 1] + 1, d[i - 1, j - 1] + cost);
				}
			}

			// Step 7

			return d[n, m];
		}


		private static int Minimum(int a, int b, int c)
		{
			int mi;
			mi = a;
			if (b < mi)
			{
				mi = b;
			}
			if (c < mi)
			{
				mi = c;
			}
			return mi;
		}

    public static string TryFormat(string str,params object[] args)
    {
      try
      {
        return string.Format(str, args);
      }
      catch
      {
        return str;
      }
    
	}

		public static string EncryptPass(string originString)
		{
			return originString;
		}

		public static string DecryptPass(string encryptedString)
		{
			return encryptedString;
		}

		public static string GetNumberString(object number,byte length)
		{
			if (length == 0) return number.ToString().Trim();
			string str = number.ToString().Trim();
			if(number.ToString().Trim().Length<length)
			{
				for (int i = 0; i < length - number.ToString().Trim().Length; i++)
				{
					str = str.Insert(0, "0");
				}
			}

			return str;
		}

		public static bool IsNumeric(string strTextEntry)
		{
			Regex objNotWholePattern = new Regex("[^0-9]");
			return !objNotWholePattern.IsMatch(strTextEntry)
					 && (strTextEntry != "");
		}

		public static string Standardization(string inputString)
		{
			if (string.IsNullOrEmpty(inputString)) return "";

			string[] str = inputString.Split(' ');
			StringBuilder sb = new StringBuilder();
			foreach (string s in str)
			{
				if(!string.IsNullOrEmpty(s))
				{
					if(sb.ToString().Length>0)
					{
						sb.Append(" ");
					}

					sb.Append(s);
				}
			}
			inputString = sb.ToString();
			return inputString;
			//return Microsoft.VisualBasic.Strings.StrConv(inputString, VbStrConv.ProperCase, 0);
		}

		public static string ProperCase(string inputString)
		{
			inputString = Standardization(inputString);
			return Microsoft.VisualBasic.Strings.StrConv(inputString, VbStrConv.ProperCase, 0);
		}

		public static string  GetCode(string firstLetters)
		{
			firstLetters = firstLetters.PadRight(firstLetters.Length + numberOfAdditionNo - 1, '0');
			firstLetters += "1";

			return firstLetters;
		}

		public static string GetNextCode(string currentCode)
		{
			int intValue = Convert.ToInt32(currentCode.Substring(currentCode.Length - numberOfAdditionNo));
			intValue++;
			string intString = intValue.ToString();

			string firstLetters = currentCode.Substring(0, currentCode.Length - numberOfAdditionNo);
			firstLetters = firstLetters.PadRight(firstLetters.Length + numberOfAdditionNo - intString.Length, '0');
			firstLetters += intValue.ToString();

			return firstLetters;
		}

		public static string ProcessEspecialCharsName(string name)
		{
			name = name.Replace("/$b", "</b>");
			name = name.Replace("$b", "<b>");
      name = name.Replace("$br", "<br>");
			return name;
		}

    private static readonly string[] VietnameseSigns = new string[] 
    {   
        "aAeEoOuUiIdDyY",
        "áàạảãâấầậẩẫăắằặẳẵ",
        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
        "éèẹẻẽêếềệểễ",
        "ÉÈẸẺẼÊẾỀỆỂỄ",
        "óòọỏõôốồộổỗơớờợởỡ",
        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
        "úùụủũưứừựửữ",
        "ÚÙỤỦŨƯỨỪỰỬỮ",
        "íìịỉĩ",
        "ÍÌỊỈĨ",
        "đ",
        "Đ",
        "ýỳỵỷỹ",
        "ÝỲỴỶỸ"
    };

    /// <summary>
    /// Get string id from string. This method return a string with all 2 character first of each words in the string
    /// </summary>
    /// <param name="str"></param>
    /// <param name="isIncludedTime">True if you want to add both date time in to string id</param>
    /// <returns>Get string id from string. This method return a string with all 2 character first of each words in the string</returns>
    public static string GetStringIDFromText(string str, bool isIncludedTime)
    {
      //Tiến hành thay thế , lọc bỏ dấu cho chuỗi
      for (int i = 1; i < VietnameseSigns.Length; i++)
      {
        for (int j = 0; j < VietnameseSigns[i].Length; j++)
          str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
      }
      if (string.IsNullOrEmpty(str))
        return string.Empty;
      string[] arr = str.Split(' ');
      string strStandard = string.Empty;
      foreach (string s in arr)
      {
        if (!string.IsNullOrEmpty(s.Trim()))
        {
          if (s.Trim().Length > 1)
          {
            strStandard += s.Substring(0, 2);
          }
          else if (s.Trim().Length == 1)
          {
            strStandard += s;
          }
        }
      }
      string datetimeAdded = string.Empty;
      if (isIncludedTime)
        datetimeAdded = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() +
                        DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();

      return strStandard.Length > 0 ? strStandard.ToLower() + datetimeAdded : string.Empty;
    }

    public static bool ToBoolean(this string value)
    {
      bool result = false;
      bool.TryParse(value, out result);
      return result;
    }
	}
}
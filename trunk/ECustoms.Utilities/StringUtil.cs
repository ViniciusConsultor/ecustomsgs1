using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ECustoms.Utilities
{
  public class StringUtil
  {
    public static string RemoveAllNonAlphanumericString (string input)
    {
      if(string.IsNullOrEmpty(input))
      {
        return "";
      }
      Regex rgx = new Regex("[^a-zA-Z0-9]");
      string output = rgx.Replace(input, "");
      return output;
    }
  }
}


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ApplicationUtils
{
  public class ValidUtils
  {
    public static bool IsDisplayAsText(object value)
    {
      Type valueType = value.GetType();
      if ((valueType == typeof(string)) || (valueType == typeof(int))
          || (valueType == typeof(Int16)) || (valueType == typeof(Int32))
          || (valueType == typeof(float)) || (valueType == typeof(decimal))
          || (valueType == typeof(double)))
      {
        return true;
      }
      return false;
    }

    public static bool IsImage(object value)
    {
      return value.GetType() == typeof(Bitmap);
    }

  }
}

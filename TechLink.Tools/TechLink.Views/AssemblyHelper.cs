using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TechLink.Views
{
    class AssemblyHelper
    {
        public static string GetCopyright()
        {
            // Get all Copyright attributes on this assembly
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            // If there aren't any Copyright attributes, return an empty string
            if (attributes.Length == 0)
                return "";
            // If there is a Copyright attribute, return its value
            return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
        }
    }
}

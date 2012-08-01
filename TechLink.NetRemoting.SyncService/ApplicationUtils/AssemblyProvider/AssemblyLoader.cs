using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ExceptionHandler;

namespace ApplicationUtils.AssemblyProvider
{
    public class AssemblyLoader
    {
        public static object LoadObjectFormAssembly(string assemblyName, string assemblyNameSpace)
        {
          try
          {
            Assembly dllAsm = Assembly.LoadFile(assemblyName);
            if (dllAsm == null) return null;
            object applicationItem = Activator.CreateInstance(
                AppDomain.CurrentDomain, dllAsm.GetName().FullName, assemblyNameSpace.Trim()).Unwrap();
            return applicationItem;
          }
          catch (Exception ex)
          {
            ProcessException.Handle(ex);
          }
          return null;
            
        }
    }
}

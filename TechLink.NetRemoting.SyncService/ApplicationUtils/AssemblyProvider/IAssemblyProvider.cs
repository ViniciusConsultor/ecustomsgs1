using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationUtils.AssemblyProvider
{
	public interface IAssemblyProvider
	{
		ArrayList GetAssemblyBytes(string assemblyName);
		string GetFileVersion(string assemblyFileName);
		DateTime GetFileDate(string assemblyFileName);
		Hashtable GetAssemblyConfig(string assemblyName);
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientServerExchange.Interfaces
{
	public interface IConfigurationFolders
	{
		string TempFolder { get; set; }
		string CacheFolder { get; set; }
		string BaseFolder { get; set; }
		string GridConfigFolder { get; set; }
		string ReportsFolder { get; set; }
	}
}

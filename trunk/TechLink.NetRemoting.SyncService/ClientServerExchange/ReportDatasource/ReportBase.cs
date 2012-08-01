using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ApplicationUtils.Constants;
using ClientServerExchange.Interfaces;

namespace ClientServerExchange.ReportDatasource
{
	public abstract class ReportBase
	{
		protected IGenericServer GenericServer = null;
		protected Dictionary<string, object> Paramaters = null;

		public ReportBase(IGenericServer genericServer, Dictionary<string,object> paramaters)
		{
			this.GenericServer = genericServer;
			this.Paramaters = paramaters;
		}

		public string LayoutFileName 
		{ 
			get
			{
				if(Paramaters!=null)
				{
					object name = Paramaters[ReportConstants.ReportFileName];
					if (name != null)
						return name.ToString();
				}
				return "";
			}
		}

		public string DatasourceFileName
		{
			get
			{
				if (Paramaters != null)
				{
					object name = Paramaters[ReportConstants.ReportDatasource];
					if (name != null)
						return name.ToString();
				}
				return "";
			}
		}


		public abstract DataSet GatherData();
		

	}
}

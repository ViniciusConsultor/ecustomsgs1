using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECustoms.DAL;
using GenericRemoteServer.General;

namespace ServerPrevalence
{
	public class AccessGenericServer : GenericServer
	{

		public AccessGenericServer(IDataController database)
			: base(database)
		{
		}

		#region Overrides of GenericServer

		public override void Close()
		{
			//DataController.Disconnect();
		}

	  public override void InitSystemOptions()
	  {
      throw new NotImplementedException();
	  }

	  #endregion
	}
}

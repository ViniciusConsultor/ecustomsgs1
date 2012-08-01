using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Threading;
using ApplicationUtils.ErrorReporting;
using ApplicationUtils.Utils;
using ClientServerExchange.Args;
using ClientServerExchange.Delegates;
using ClientServerExchange.Interfaces;
using ECustoms.DAL;
using EnumConstant.Enums;
using ExceptionHandler;
using System.Linq;
using System.Linq.Expressions;

namespace GenericRemoteServer.General
{
  public abstract class GenericServer : MarshalByRefObject, IGenericServer
  {
    public abstract void Close();
    public abstract void InitSystemOptions();

    private IDataController _dataController = null;
    private bool _securityEnabled = false;
    private System.Timers.Timer GCCollectTimer = null;
    public GenericServer(IDataController dataController)
    {
      _dataController = dataController;
      ServerErrorReportingEngine.Instance.NewErrorReport += Instance_NewErrorReport;
      GCCollectTimer = new System.Timers.Timer(1000);
      GCCollectTimer.Elapsed += new System.Timers.ElapsedEventHandler(GCCollectTimer_Elapsed);
    }

    void GCCollectTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
      GC.Collect();
      ((System.Timers.Timer)sender).Stop();
    }

    private void Instance_NewErrorReport(object sender, NewErrorReportEventArgs<ServerErrorReport> e)
    {
      //foreach (UserSessionData session in serverDynamicData.ClientSessionsLogic.Sessions)
      //{
      //  try
      //  {
      //    e.ErrorReport.AditionalInfo.Add(new ErrorReportBase.InfoItem("Session", session.ToString()));
      //  }
      //  catch (Exception e1)
      //  {
      //    Debug.WriteLine(e1);
      //  }

      //  e.ErrorReport.PromovaProfilingData = database.PromovaProfilingData.GetXmlSerializablePromovaProfilingData();
      //}
    }

    public override object InitializeLifetimeService()
    {
      return null;
    }

      public bool SyncUserInfo()
      {
          return false;
      }
  }
}

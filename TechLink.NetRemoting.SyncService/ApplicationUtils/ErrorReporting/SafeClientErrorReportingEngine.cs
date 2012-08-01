using System;
using System.Collections.Generic;

namespace ApplicationUtils.ErrorReporting
{
	internal class SafeClientErrorReportingEngine : IClientErrorReportingEngine
	{
		private readonly IClientErrorReportingEngine instance = null;

		public SafeClientErrorReportingEngine(IClientErrorReportingEngine instance)
		{
			this.instance = instance;
		}

		public static IClientErrorReportingEngine GetSafeInstance(IClientErrorReportingEngine instance)
		{
			return new SafeClientErrorReportingEngine(instance);
		}

		public void Stop()
		{
			try
			{
				instance.Stop();
			}
			catch (Exception e)
			{
#if DEBUG
				throw e;
#endif
			}
		}

		public void Clear()
		{
			try
			{
				instance.Clear();
			}
			catch (Exception e)
			{
#if DEBUG
				throw e;
#endif
			}
		}

		public ErrorReportBase CreateErrorReport()
		{
			try
			{
				return instance.CreateErrorReport();
			}
			catch (Exception e)
			{
#if DEBUG
				throw e;
#else 
				return new ErrorReportBase();
#endif
			}
		}

		public void SendReports()
		{
			try
			{
				instance.SendReports();
			}
			catch (Exception e)
			{
#if DEBUG
				throw e;
#endif
			}
		}

		public List<ErrorReportBase> ErrorReportsList
		{
			get
			{
				try
				{
					return instance.ErrorReportsList;
				}
				catch (Exception e)
				{
#if DEBUG
										throw e;
#else		
					return new List<ErrorReportBase>();
#endif
				}

			}
		}

		#region IClientErrorReportingEngine Members

		public bool DisableErrorSending
		{
			get
			{
				try
				{
					return instance.DisableErrorSending;
				}
				catch (Exception e)
				{
#if DEBUG
					throw e;
#else
					return false;
#endif
				}
				
			}
			set
			{
				try
				{
					instance.DisableErrorSending = value;
				}
				catch (Exception e)
				{
#if DEBUG
					throw e;
#endif
				}
			}
		}

		#endregion

		public event EventHandler ErrorReportAvailable
		{
			add
			{
				try
				{
					instance.ErrorReportAvailable += value;
				}
				catch (Exception e)
				{
#if DEBUG
					throw e;
#endif
				}
			}
			remove
			{
				try
				{
					instance.ErrorReportAvailable -= value;
				}
				catch (Exception e)
				{
#if DEBUG
					throw e;
#endif
				}
			}
		}

		public event EventHandler<NewErrorReportEventArgs<ErrorReportBase>> NewErrorReport
		{
			add
			{
				try
				{
					instance.NewErrorReport += value;
				}
				catch (Exception e)
				{
#if DEBUG
					throw e;
#endif
				}
			}
			remove
			{
				try
				{
					instance.NewErrorReport -= value;
				}
				catch (Exception e)
				{
#if DEBUG
					throw e;
#endif
				}
			}
		}
	}
}
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationUtils.ErrorReporting
{
	[Serializable]
	public class ReportProcessingTicket
	{
		private string reportHashcode;
		private DateTime dateSent;
		private bool hasSnapshot = false;
		private bool isSent = false;
		private bool inProcessing = false;
		private string packageName;
		
		public ReportProcessingTicket()
		{
		}

		public ReportProcessingTicket(string reportHashcode, bool hasSnapshot)
		{
			this.reportHashcode = reportHashcode;
			this.hasSnapshot = hasSnapshot;
		}

		public string PackageName
		{
			get
			{
				return packageName;
			}
			set
			{
				packageName = value;
			}
		}

		public bool IsSent
		{
			get
			{
				return isSent;
			}
			set
			{
				isSent = value;
			}
		}

		public bool InProcessing
		{
			get
			{
				return inProcessing;
			}
			set
			{
				inProcessing = value;
			}
		}

		public string ReportHashcode
		{
			get
			{
				return reportHashcode;
			}
			set
			{
				reportHashcode = value;
			}
		}

		public DateTime DateSent
		{
			get
			{
				return dateSent;
			}
			set
			{
				dateSent = value;
			}
		}

		public bool HasSnapshot
		{
			get
			{
				return hasSnapshot;
			}
			set
			{
				hasSnapshot = value;
			}
		}
	}
}

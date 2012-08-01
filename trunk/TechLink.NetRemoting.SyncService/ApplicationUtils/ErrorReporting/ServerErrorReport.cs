using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ApplicationUtils.Profiling;
using ApplicationUtils.Utils;

namespace ApplicationUtils.ErrorReporting
{
    public class ServerErrorReport : ErrorReportBase
    {
        private string lastSnapshot = string.Empty;
        private List<string> commandLogs = new List<string>();
        private ErrorReportBase clientErrorReport = null;
        private string errorLocation = "Server";
        private XmlSerializablePromovaProfilingData promovaProfilingData;


        public XmlSerializablePromovaProfilingData PromovaProfilingData
        {
            get { return promovaProfilingData; }
            set { promovaProfilingData = value; }
        }

        [XmlIgnore]
        private List<DirectoryInfo> configFolders = new List<DirectoryInfo>();

        [XmlIgnore]
        private string logsDirectory = string.Empty;

        [XmlIgnore]
        public List<DirectoryInfo> ConfigFolders
        {
            get
            {
                return configFolders;
            }
        }

        [XmlIgnore]
        public string LogsDirectory
        {
            get { return logsDirectory; }
            set { logsDirectory = value; }
        }


        public string ErrorLocation
        {
            get
            {
                return errorLocation;
            }
            set
            {
                errorLocation = value;
            }
        }

        public string LastSnapshot
        {
            get
            {
                return lastSnapshot;
            }
            set
            {
                lastSnapshot = value;
            }
        }

        public List<string> CommandLogs
        {
            get
            {
                return commandLogs;
            }
            set
            {
                commandLogs = value;
            }
        }

        public ErrorReportBase ClientErrorReport
        {
            get
            {
                return clientErrorReport;
            }
            set
            {
                if (value != null)
                {
                    this.errorLocation = "Client";
                }
                else
                {
                    this.errorLocation = "Server";
                }
                clientErrorReport = value;
            }
        }

        public override int GetHashCode()
        {
            if (this.clientErrorReport != null)
            {
                return this.clientErrorReport.GetHashCode();
            }
            else
            {
                return base.GetHashCode();
            }
        }


        [XmlIgnore]
        public string InstallationName
        {
            get
            {
                string name = GetAdditionalItemValue("InstallationName");
                return UmlautsHelper.ReplaceUmlauts(name);
            }
        }

        [XmlIgnore]
        public Version InstallationVersion
        {
            get
            {
                string versionStr = GetAdditionalItemValue("ProductVersion");
                if (!string.IsNullOrEmpty(versionStr))
                {
                    return new Version(versionStr);
                }
                return new Version(0, 0, 0, 0);
            }
        }

    }
}
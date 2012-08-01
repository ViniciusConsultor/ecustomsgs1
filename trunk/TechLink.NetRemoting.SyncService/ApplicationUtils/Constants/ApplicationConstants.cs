using System;

namespace ApplicationUtils.Constants
{
	public class ApplicationConstants
	{
		public static string FakeUserName = "FakeUserName";

		public static string AnUnhandledExceptionHasOccured = "AnUnhandledExceptionHasOccured";
		public static string AskForApplicationRestart = "AskForApplicationRestart";
		public static string NoConnectionToServer = "NoConnectionToServer";
		public static string ServerLoginBlocked = "ServerLoginBlocked";
		public static string DateFormat = "dd.MM.yyyy";
		public static string DateTimeFormat = "dd.MM.yyyy HH:mm";
		public static string FakeUserID = "fake user";
		public static string RootGroupID = "root";

		public static readonly string DebugServerURL = "127.0.0.1";
		public static readonly string DebugServerPORT = "8086";

		public static long ONE_SECOND = (new TimeSpan(0, 0, 1)).Ticks;

		public static char[] GeneralTrimChars = {',', ' '};

		public static string DefaultCulture = "vi-VN";

		public static string VietnamCulture = "vi-VN";
    public static string VietnamCultureKey = "vi";
	}

	public class ReportConstants
	{
		public static string ReportFileName = "ReportFileName";
		public static string ReportDatasource = "ReportDataSet";
	}

  public class SystemConstants
  {
    public static string Folder = "FOLDER";
    public static string File = "FILE";

    public static string GridSkinName_Caramel = "Caramel";
    public static string GridSkinName_Blue = "Blue";
    public static string GridSkinName_Black = "Black";
    public static string GridSkinName_Lilian = "Lilian";
    public static string GridSkinName_iMaginary = "iMaginary";
    public static string GridSkinName_MoneyTwins= "Money Twins";
    public static string GridSkinName_TheAsphaltWorld= "The Asphalt World";
  }
}
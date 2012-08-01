using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace EnumConstant.Enums
{
    public enum ObjectEnum
    {
        [Description("Interacting UserInfo")]
        UserInfomation,
        [Description("Interacting GroupInfo")]
        GroupInformation
    }

    public enum Methology
    {
        Insert,
        Update,
        Delete,
        GetInfo
    }

	public class Groups
	{
		public const string Administrator = "Administrator";
		public const string ClientUser = "ClientUser";
		public const string Guest = "Guest";
	}
}

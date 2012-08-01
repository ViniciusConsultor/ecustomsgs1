using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationUtils.Constants
{
  public class OrderProcessSate
  {
    public const int JustBooked = 1;
    public const int PaidMoney = 2;
    public const int Finished = 3;
    public const int Cancelled = 0;
  }

  public class UserViewerDialogSelected
  {
    public const string None = "None";
    public const string ChangePassword = "ChangePassword";
    public const string ChangePersonalInfo = "ChangePersonalInfo";
  }

	public class ReportParamaterKeys
	{
		public const string SelectedCategoryIdKey = "CategoryId";
		public const string SelectedProductIdKey = "ProductId";
		public const string SelectedTypeIdKey = "TypeId";
		public const string GetExistAmountItemsOnlyKey = "GetExistAmountItemsOnly";

		public const string SelectedDate = "SelectedDate";
	}
}

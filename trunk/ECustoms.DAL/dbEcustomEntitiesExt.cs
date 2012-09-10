using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationUtils.Utils;
using ECustoms.Utilities;

namespace ECustoms.DAL
{
    public partial class dbEcustomEntities
    {
        public void AddObject(string tableName, object obj)
        {

            var fields = DatasourceUtils.GetAllPropertiesNameOfObject(obj);
            if (fields.Contains("BranchId"))
            {
                string str = DatasourceUtils.GetStringProperty(obj, "BranchId");

                if (string.IsNullOrEmpty(str))
                {
                    DatasourceUtils.SetValueOfProperty(obj, "BranchId", FDHelper.RgCodeOfUnit());
                }
            }

            base.AddObject(tableName, obj);
        }
    }
}

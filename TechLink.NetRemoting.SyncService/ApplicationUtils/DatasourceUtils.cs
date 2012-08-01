using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ApplicationUtils.Utils
{
  public class DatasourceUtils
  {
    #region DataSource
    //Cast datasource from dataset or list or collection to IList
    public static IList GetInnerDataSource(object item, string dataMember)
    {
      try
      {
        if (item is DataSet)
        {
          if (dataMember != null)
            return ((IListSource)((DataSet)item).Tables[dataMember].Copy()).GetList();
          else
            return ((IListSource)((DataSet)item).Tables[0].Copy()).GetList();
        }
        else if (item is IListSource)
          return ((IListSource)item).GetList();
        else
          return item as IList;
      }
      catch
      {
        return null;
      }
    }

    public static string GetStringProperty(object o, string property)
    {
      try
      {
        if (o is DataRowView)
        {
          DataRowView drv = (DataRowView)o;
          return drv[property].ToString();
        }

        PropertyInfo objProp = o.GetType().GetProperty(property);
        if (objProp == null)
          return null;

        return (objProp.GetValue(o, null)).ToString();
      }
      catch
      {
        return null;
      }
    }
    #endregion
  }
}

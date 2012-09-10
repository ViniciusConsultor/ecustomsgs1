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

          var returnValue = (objProp.GetValue(o, null));
          return returnValue == null ? string.Empty : returnValue.ToString();
      }
      catch
      {
        return null;
      }
    }

    public static bool SetValueOfProperty(object o, string property, object value)
    {
        try
        {
            if (o is DataRowView)
            {
                DataRowView drv = (DataRowView)o;
                drv[property] = value;
            }

            PropertyInfo objProp = o.GetType().GetProperty(property);
            objProp.SetValue(o, value, null);
        }
        catch
        {
            return false;
        }

        return true;
    }

    public static List<string> GetAllPropertiesNameOfObject(object getObject)
    {
        List<string> cols = new List<string>();
        if (getObject is DataTable)
        {
            DataTable dataTable = getObject as DataTable;

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                cols.Add(dataTable.Columns[i].ColumnName);
            }

            return cols;
        }
        else
        {
            //Check later
            object newObj = null;
            if ( getObject.GetType().IsGenericType && getObject.GetType().GetGenericTypeDefinition() == typeof(List<>))
            {
                IEnumerable list = getObject as IEnumerable;
                IEnumerator tmp = list.GetEnumerator();
                if (tmp.MoveNext())
                    newObj = tmp.Current;
                //IObjectData data = newObj as IObjectData;
            }
            else
            {
                newObj = getObject;
            }

            if (newObj != null)
            {
                PropertyInfo[] propertyInfos = newObj.GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    cols.Add(propertyInfo.Name);
                }
            }
        }
        return cols;
    }
    #endregion
  }
}

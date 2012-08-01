using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ApplicationUtils
{
  public class ObjectUtils
  {
    private static String[] _systemTypes = new String[]{ "SYSTEM.BYTE", "SYSTEM.CHAR", "SYSTEM.DECIMAL", "SYSTEM.DOUBLE", "SYSTEM.INT16", "SYSTEM.INT32", "SYSTEM.INT64",
                                                                                                                "SYSTEM.SBYTE", "SYSTEM.SINGLE", "SYSTEM.UINT16", "SYSTEM.UINT32", "SYSTEM.UINT64", "SYSTEM.DATETIME",
                                                                                                                "SYSTEM.STRING", "SYSTEM.BOOLEAN" };
    public static DataTable ConvertToDataTable(Object[] array)
    {
      PropertyInfo[] properties = array.GetType().GetElementType().GetProperties();
      DataTable dt = CreateDataTable(properties, array[0]);
      dt.TableName = array.GetType().GetElementType().Name;

      if (array.Length != 0)
      {
        foreach (object source in array)
          FillData(properties, dt, null, String.Empty, source);

      }

      return dt;
    }

    public static DataTable ConvertToDataTable(Object source)
    {
      PropertyInfo[] properties = source.GetType().GetProperties();
      DataTable dt = CreateDataTable(properties, source);
      dt.TableName = source.GetType().Name;
      FillData(properties, dt, null, String.Empty, source);
      return dt;
    }

    private static DataTable CreateDataTable(PropertyInfo[] properties, object source)
    {
      DataTable dt = new DataTable();
      CreateColumns(properties, dt, String.Empty, source);
      return dt;
    }

    private static void CreateColumns(PropertyInfo[] properties, DataTable dt, String expandedName, object source)
    {
      DataColumn dc = null;
      PropertyInfo[] nestedProperties = null;
      Object nested = null;

      foreach (PropertyInfo pi in properties)
      {
        if (IsSystemType(pi.PropertyType.ToString()) || pi.PropertyType.IsEnum)
        {
          dc = new DataColumn();
          dc.ColumnName = expandedName + pi.Name;

          if (pi.PropertyType.IsEnum)    // Enums always get the string type because we stuff the enum item name as the value.
            dc.DataType = Type.GetType("System.String");
          else
            dc.DataType = pi.PropertyType;

          dt.Columns.Add(dc);
        }
        else
        {
          if (source != null)
          {
            nested = pi.GetValue(source, null);
            if (nested != null)
            {
              if (pi.GetType().IsArray)
                nestedProperties = nested.GetType().GetElementType().GetProperties();
              else
                nestedProperties = nested.GetType().GetProperties();

              CreateColumns(nestedProperties, dt, pi.Name, nested);
            }
          }
        }
      }
    }

    private static void FillData(PropertyInfo[] properties, DataTable dt, DataRow row, String expandedName, object source)
    {
      DataRow newRow = null;
      PropertyInfo[] nestedProperties = null;
      Object nested = null;

      if (row == null)
        newRow = dt.NewRow();
      else
        newRow = row;

      foreach (PropertyInfo pi in properties)
      {
        if (IsSystemType(pi.PropertyType.ToString()) && pi.GetValue(source, null) != null)
        {
          if (!dt.Columns.Contains(expandedName + pi.Name))
          {
            DataColumn dc = new DataColumn();
            dc.ColumnName = expandedName + pi.Name;

            if (pi.PropertyType.IsEnum)    // Enums always get the string type because we stuff the enum item name as the value.
              dc.DataType = Type.GetType("System.String");
            else
              dc.DataType = pi.PropertyType;

            dt.Columns.Add(dc);
          }
            
          newRow[expandedName + pi.Name] = pi.GetValue(source, null);
        }
        else if (pi.PropertyType.IsEnum)
        {
          int i = 0;
          object itemVal = pi.GetValue(source, null);
          string[] names = Enum.GetNames(itemVal.GetType());

          // Pull the enum text into the column value.
          foreach (object o in Enum.GetValues(itemVal.GetType()))
          {
            if (o.ToString() == itemVal.ToString())
              newRow[expandedName + pi.Name] = names[i];
            i++;
          }


        }
        else
        {
          nested = pi.GetValue(source, null);
          if (nested != null)
          {
            if (pi.GetType().IsArray)
              nestedProperties = nested.GetType().GetElementType().GetProperties();
            else
              nestedProperties = nested.GetType().GetProperties();

            FillData(nestedProperties, dt, newRow, pi.Name, nested);
          }
        }

      }

      if (row == null)
        dt.Rows.Add(newRow);
    }

    private static bool IsSystemType(String type)
    {
      String utype = type.ToUpper();

      foreach (String st in _systemTypes)
      {
        if (utype == st)
          return true;
      }

      return false;
    }


    private class FieldInfo
    {
      public string RelationName;
      public string FieldName;	//source table field name
      public string FieldAlias;	//destination table field name
      public string Aggregate;
    }

    private System.Collections.ArrayList m_FieldInfo; private string m_FieldList;
    public DataSet ds;


    private void ParseFieldList(string FieldList, bool AllowRelation)
    {
      /*
       * This code parses FieldList into FieldInfo objects  and then 
       * adds them to the m_FieldInfo private member
       * 
       * FieldList systax:  [relationname.]fieldname[ alias], ...
      */
      if (m_FieldList == FieldList) return;
      m_FieldInfo = new System.Collections.ArrayList();
      m_FieldList = FieldList;
      FieldInfo Field; string[] FieldParts;
      string[] Fields = FieldList.Split(',');
      int i;
      for (i = 0; i <= Fields.Length - 1; i++)
      {
        Field = new FieldInfo();
        //parse FieldAlias
        FieldParts = Fields[i].Trim().Split(' ');
        switch (FieldParts.Length)
        {
          case 1:
            //to be set at the end of the loop
            break;
          case 2:
            Field.FieldAlias = FieldParts[1];
            break;
          default:
            throw new Exception("Too many spaces in field definition: '" + Fields[i] + "'.");
        }
        //parse FieldName and RelationName
        FieldParts = FieldParts[0].Split('.');
        switch (FieldParts.Length)
        {
          case 1:
            Field.FieldName = FieldParts[0];
            break;
          case 2:
            if (AllowRelation == false)
              throw new Exception("Relation specifiers not permitted in field list: '" + Fields[i] + "'.");
            Field.RelationName = FieldParts[0].Trim();
            Field.FieldName = FieldParts[1].Trim();
            break;
          default:
            throw new Exception("Invalid field definition: " + Fields[i] + "'.");
        }
        if (Field.FieldAlias == null)
          Field.FieldAlias = Field.FieldName;
        m_FieldInfo.Add(Field);
      }
    }

    public DataTable CreateJoinTable(string TableName, DataTable SourceTable, string FieldList)
    {
      /*
       * Creates a table based on fields of another table and related parent tables
       * 
       * FieldList syntax: [relationname.]fieldname[ alias][,[relationname.]fieldname[ alias]]...
      */
      if (FieldList == null)
      {
        throw new ArgumentException("You must specify at least one field in the field list.");
        //return CreateTable(TableName, SourceTable);
      }
      else
      {
        DataTable dt = new DataTable(TableName);
        ParseFieldList(FieldList, true);
        foreach (FieldInfo Field in m_FieldInfo)
        {
          if (Field.RelationName == null)
          {
            DataColumn dc = SourceTable.Columns[Field.FieldName];
            dt.Columns.Add(dc.ColumnName, dc.DataType, dc.Expression);
          }
          else
          {
            DataColumn dc = SourceTable.ParentRelations[Field.RelationName].ParentTable.Columns[Field.FieldName];
            dt.Columns.Add(dc.ColumnName, dc.DataType, dc.Expression);
          }
        }
        if (ds != null)
          ds.Tables.Add(dt);
        return dt;
      }
    }

    public void InsertJoinInto(DataTable DestTable, DataTable SourceTable,
    string FieldList, string RowFilter, string Sort)
    {
      /*
      * Copies the selected rows and columns from SourceTable and inserts them into DestTable
      * FieldList has same format as CreatejoinTable
      */
      if (FieldList == null)
      {
        throw new ArgumentException("You must specify at least one field in the field list.");
        //InsertInto(DestTable, SourceTable, RowFilter, Sort);
      }
      else
      {
        ParseFieldList(FieldList, true);
        DataRow[] Rows = SourceTable.Select(RowFilter, Sort);
        foreach (DataRow SourceRow in Rows)
        {
          DataRow DestRow = DestTable.NewRow();
          foreach (FieldInfo Field in m_FieldInfo)
          {
            if (Field.RelationName == null)
            {
              DestRow[Field.FieldName] = SourceRow[Field.FieldName];
            }
            else
            {
              DataRow ParentRow = SourceRow.GetParentRow(Field.RelationName);
              DestRow[Field.FieldName] = ParentRow[Field.FieldName];
            }
          }
          DestTable.Rows.Add(DestRow);
        }
      }
    }

    public DataTable SelectJoinInto(string TableName, DataTable SourceTable, string FieldList, string RowFilter, string Sort)
    {
      /*
       * Selects sorted, filtered values from one DataTable to another.
       * Allows you to specify relationname.fieldname in the FieldList to include fields from
       *  a parent table. The Sort and Filter only apply to the base table and not to related tables.
      */
      DataTable dt = CreateJoinTable(TableName, SourceTable, FieldList);
      InsertJoinInto(dt, SourceTable, FieldList, RowFilter, Sort);
      return dt;
    }
  }
}

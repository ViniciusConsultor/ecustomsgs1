using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using ApplicationUtils.Utils;
using ECustoms.Utilities;

namespace ECustoms.DAL
{
    public partial class dbEcustomEntities
    {
        /// <summary>
        /// Add an Entity into database with verification
        /// </summary>
        /// <param name="tableName">Name of table need to add the new entity</param>
        /// <param name="obj">The entity add new</param>
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

        /// <summary>
        /// Add an entity into database without verification
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="obj"></param>
        public void AddObjectDirectly(string tableName, object obj)
        {
            (obj as EntityObject).EntityKey = null;
            base.AddObject(tableName, obj);
        }

        /// <summary>
        /// Delete an object from the collection with verification
        /// </summary>
        /// <param name="obj"></param>
        public void DeleteObject(object obj)
        {
            var fields = DatasourceUtils.GetAllPropertiesNameOfObject(obj);
            if (fields.Contains("IsSynced"))
            {
                var str = DatasourceUtils.GetStringProperty(obj, "IsSynced").StringToBoolean();

                if (str)
                {
                    //Delete the object from other database if needed
                }
            }

            base.DeleteObject(obj);
            
        }

        /// <summary>
        /// Delete an entity directy without verify
        /// </summary>
        /// <param name="obj"></param>
        public void DeleteDirectly(object obj)
        {
            base.DeleteObject(obj);
            
        }
    }
}

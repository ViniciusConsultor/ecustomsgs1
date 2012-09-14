using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;

namespace ECustoms.BOL
{
    public interface IDataModelCommand
    {
        /// <summary>
        /// Delete an entity from database with primary keys. Return true if the entity is deleted, false otherwise
        /// </summary>
        /// <param name="itemParams">key values</param>
        /// <returns>Return true if the entity is deleted, false otherwise</returns>
        bool DeleteItem(string[] itemParams);

        /// <summary>
        /// Insert multiple entities into database. Return true of insert successfully, false if otherwise
        /// </summary>
        /// <param name="items">Entoties to insert</param>
        /// <returns>Return true of insert successfully, false if otherwise</returns>
        bool BatchInsert(object[] items);

        /// <summary>
        /// Get all unsynced items from database
        /// </summary>
        /// <returns></returns>
        object[] GetUnSyncedItems();

        /// <summary>
        /// Update a list of items
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        bool UpdatePatch(object[] items);
    }
}

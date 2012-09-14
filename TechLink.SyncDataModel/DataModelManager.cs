using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECustoms.BOL;

namespace TechLink.SyncDataModel
{
    public class DataModelManager
    {
        private static Dictionary<string, IDataModelCommand> ClassDict = null;
        public static void InitClassDictionary()
        {
            ClassDict = new Dictionary<string, IDataModelCommand>();

            ClassDict.Add("tblApplicationObject", new ApplicationObjectFactory());
            ClassDict.Add("tblCheck", new CheckFactory());
            ClassDict.Add("tblCompany", new CompanyFactory());
            ClassDict.Add("tblCustoms", new CustomsFacory());
            ClassDict.Add("tblDeclaration", new DeclarationFactory());
            ClassDict.Add("tblDeclarationLoan", new DeclarationLoanFactory());
            ClassDict.Add("tblDeclarationVehicle", new DeclarationVehicleFactory());
            ClassDict.Add("tblGate", new GateFactory());
            ClassDict.Add("tblGoodsType", new GoodTypeFactory());
            ClassDict.Add("tblGroup", new GroupFactory());
            ClassDict.Add("tblPermission", new PermissionFactory());
            ClassDict.Add("tblPermissionType", new PermissionTypeFactory());
            ClassDict.Add("tblProfileConfig", new ProfileConfigFactory());
            ClassDict.Add("tblRoleInGroup", new RoleInGroupFactory());
            ClassDict.Add("tblType", new TypeFactory());
            ClassDict.Add("tblUser", new UserFactory());
            ClassDict.Add("tblUserGroupPermission", new UserGroupPermissionFactory());
            ClassDict.Add("tblUserInGroup", new UserInGroupFactory());
            ClassDict.Add("tblVehicle", new VehicleFactory());
            ClassDict.Add("tblVehicleCheck", new VehicleCheckFactory());
            ClassDict.Add("tblVehicleFeeSetting", new VehicleFeeSettingFactory());
            ClassDict.Add("tblVehicleType", new VehicleTypeFactory());
            ClassDict.Add("tlbRole", new RoleFactory());
        }

        public static bool DeleteItem(string  tableName, string[] itemParams)
        {
            if(DataModelConst.Tables.Contains(tableName) )
            {
                if(ClassDict==null) InitClassDictionary();

                return ClassDict[tableName].DeleteItem(itemParams);
            }

            return false;
        }

        public static bool InsertItems(string tableName, object [] batchItems)
        {
            if (DataModelConst.Tables.Contains(tableName))
            {
                if (ClassDict == null) InitClassDictionary();

                return ClassDict[tableName].BatchInsert(batchItems);
            }

            return false;
        }

        public static object[] GetUnSyncedItems(string tableName)
        {
            if (DataModelConst.Tables.Contains(tableName))
            {
                if (ClassDict == null) InitClassDictionary();

                return ClassDict[tableName].GetUnSyncedItems();
            }

            return null;
        }

        public static bool UpdateBatchItems(string tableName, object[] items)
        {
            if (DataModelConst.Tables.Contains(tableName))
            {
                if (ClassDict == null) InitClassDictionary();

                return ClassDict[tableName].UpdatePatch(items);
            }

            return false;
        }
    }
}

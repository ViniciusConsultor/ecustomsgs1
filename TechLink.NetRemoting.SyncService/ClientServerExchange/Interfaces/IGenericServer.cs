using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationUtils.AssemblyProvider;
using ECustoms.DAL;

namespace ClientServerExchange.Interfaces
{
	public interface IGenericServer
	{
        //bool StartSync(ClientInfo clientInfo);
        //void StopSync(ClientInfo clientInfo);

        //List<string> Sync_tblUser(List<tblUser> users);
        //List<string> Sync_tblVehicle(List<tblVehicle> vehicles);
        //List<string> Sync_tblDeclaration(List<tblDeclaration> ceclarations);
        //List<string> Sync_tlbRole(List<tlbRole> roles);
        //List<string> Sync_tblRoleInGroup(List<tblRoleInGroup> roleInGroups);
        //List<string> Sync_tblApplicationObject(List<tblApplicationObject> applicationObjects);
        //List<string> Sync_tblCheck(List<tblCheck> checks);
        //List<string> Sync_tblCustoms(List<tblCustom> customses);
        //List<string> Sync_tblDeclarationVehicle(List<tblDeclarationVehicle> declarationVehicles);
        //List<string> Sync_tblGate(List<tblGate> gates);
        //List<string> Sync_tblGoodsType(List<tblGoodsType> goodsTypes);
        //List<string> Sync_tblGroup(List<tblGroup> groups);
        //List<string> Sync_tblPermission(List<tblPermission> permissions);
        //List<string> Sync_tblSettings(List<tblSetting> settings);
        //List<string> Sync_tblUserGroupPermission(List<tblUserGroupPermission> groupPermissions);
        //List<string> Sync_tblVehicleCheck(List<tblVehicleCheck> vehicleChecks);
        //List<string> Sync_tblVehicleFeeSetting(List<tblVehicleFeeSetting> vehicleFeeSettings);
        //List<string> Sync_tblVehicleType(List<tblVehicleType> vehicleTypes);
        //List<string> Sync_tblUserInGroup(List<tblUserInGroup> userInGroups);

	    string StartSync(string branchId, string serial);
	    bool Sync(string token, string tableName, object[] itemsSync);
        void StopSync(string token);
	}
}

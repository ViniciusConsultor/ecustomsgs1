using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClientServerExchange.Args;
using ClientServerExchange.Delegates;
using ClientServerExchange.Interfaces;
using ECustoms.DAL;
using EnumConstant.Enums;
using ExceptionHandler;

namespace ConnectionController
{
    public class ProxyGenericServer : IGenericServer
    {

        private readonly IGenericServer genericServer = null;
        public ProxyGenericServer(IGenericServer genericServer)
        {
            this.genericServer = genericServer;
        }


        #region Implementation of IGenericServer

        public bool StartSync(ClientInfo clientInfo)
        {
            throw new NotImplementedException();
        }

        public void StopSync(ClientInfo clientInfo)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblUser(List<tblUser> users)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblVehicle(List<tblVehicle> vehicles)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblDeclaration(List<tblDeclaration> ceclarations)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tlbRole(List<tlbRole> roles)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblRoleInGroup(List<tblRoleInGroup> roleInGroups)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblApplicationObject(List<tblApplicationObject> applicationObjects)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblCheck(List<tblCheck> checks)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblCustoms(List<tblCustom> customses)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblDeclarationVehicle(List<tblDeclarationVehicle> declarationVehicles)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblGate(List<tblGate> gates)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblGoodsType(List<tblGoodsType> goodsTypes)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblGroup(List<tblGroup> groups)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblPermission(List<tblPermission> permissions)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblSettings(List<tblSetting> settings)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblUserGroupPermission(List<tblUserGroupPermission> groupPermissions)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblVehicleCheck(List<tblVehicleCheck> vehicleChecks)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblVehicleFeeSetting(List<tblVehicleFeeSetting> vehicleFeeSettings)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblVehicleType(List<tblVehicleType> vehicleTypes)
        {
            throw new NotImplementedException();
        }

        public List<string> Sync_tblUserInGroup(List<tblUserInGroup> userInGroups)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

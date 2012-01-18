using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using ECustoms.DAL;

namespace ECustoms.BOL
{
    public class RoleFactory
    {
        private readonly string _dbConnectionString;
        private dbEcustomEntities _db;
        public RoleFactory()
        {
            _dbConnectionString = Utilities.Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true);
            _db = new dbEcustomEntities(_dbConnectionString);

        }

        public void SaveGroup(tblGroup group)
        {
            _db.Connection.Open();
            _db.AddTotblGroups(group);
            _db.SaveChanges();
            _db.Connection.Close();
        }

        public int  UpdateGroup(tblGroup group)
        {
            _db.Connection.Open();
            var objOrginGroup = _db.tblGroups.Where(g => g.GroupID.Equals(group.GroupID)).FirstOrDefault();
            _db.Attach(objOrginGroup);
            _db.ApplyPropertyChanges("tblGroups", group);
            int re = _db.SaveChanges();
            _db.Connection.Close();
            return re;
        }

        public List<tblGroup> GetAllGroups()
        {
            _db.Connection.Open();
            List < tblGroup >  list = _db.tblGroups.ToList();
            _db.Connection.Close();
            return list;
        }

        //public List<tlbRole> GetAllRoles()
        //{
        //  _db.Connection.Open();
        //  List < tlbRole >  list = _db.tlbRoles.ToList();
        //  _db.Connection.Close();
        //  return list;

        //}

        public int DeleteGroup(int groupID)
        {
            _db.Connection.Open();
            var group = _db.tblGroups.Where(g => g.GroupID == groupID).FirstOrDefault();
            _db.DeleteObject(group);
            int re = _db.SaveChanges();
            _db.Connection.Close();
            return re;
        }

        public tblGroup GetGroupById(int groupID)
        {
            throw new NotImplementedException();
        }
    }
}

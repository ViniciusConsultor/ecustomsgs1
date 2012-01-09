using System;
using System.Collections.Generic;
using System.Data;

namespace ECustoms.Utilities
{
    public class UserInfo
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        //public string Permission { get; set; }
        //public int PermissionID { get; set; }
        public bool IsActive { get; set; }
        public List<int> UserPermission { get; set; }

        //public UserType Type
        //{
        //    get
        //    {

        //        if (PermissionID == 1) return UserType.Confirm;
        //        else if (PermissionID == 2) return UserType.Admin;
        //        else return UserType.Input;

        //    }
        //}

        
    }
}

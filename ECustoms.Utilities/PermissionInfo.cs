using System;
using System.Data;

namespace ECustoms.Utilities
{
    public class PermissionInfo
    {
        public int PermissionID { get; set; }
        public string Permission { get; set; }

        #region Methods
        public void CreateFrom(DataRow dr)
        {
            if (dr.Table.Columns.Contains(ConstantInfo.TBL_PERMISSION_PERMISSION_ID) &&
                !dr.IsNull(ConstantInfo.TBL_PERMISSION_PERMISSION_ID))
            {
                this.PermissionID = Convert.ToInt32(dr[ConstantInfo.TBL_PERMISSION_PERMISSION_ID]);
            }

            if (dr.Table.Columns.Contains(ConstantInfo.TBL_PERMISSION_PERMISSION) &&
                !dr.IsNull(ConstantInfo.TBL_PERMISSION_PERMISSION))
            {
                this.Permission = dr[ConstantInfo.TBL_PERMISSION_PERMISSION].ToString();
            }
        }

        #endregion
    }
}

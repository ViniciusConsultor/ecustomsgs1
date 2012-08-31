using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using ECustoms.Utilities;

namespace ECustoms.DAL
{
    public partial class DToKhaiMD: EntityObject
    {
        public string Dvt { get; set; }
        public string TenHang { get; set; }
        public decimal SoLuong { get; set; }
    }
}

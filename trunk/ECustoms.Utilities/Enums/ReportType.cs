using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECustoms.Utilities.Enums
{
    public enum ReportType
    {
        //Sổ theo dõi phương tiện xuất cảnh xe không 
        ExportAndNoItem = 1,
        //Sổ theo dõi phương tiện nhập cảnh xe không 
        ImportAndNoItem = 2,
        //Sổ theo dõi phương tiện chở hàng xuất khẩu
        ExportAndHasItem = 3,
        //Sổ theo dõi phương tiện chở hàng nhập khẩu
        ImportAndHasItem = 4,
        //Sổ theo dõi phương tiện chở hàng đã hoàn thành thủ tục Hải quan vào nội địa
        LocalImportAndHasItem = 5,

    }
}

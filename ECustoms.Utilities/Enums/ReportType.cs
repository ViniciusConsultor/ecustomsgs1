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
        //Sổ theo dõi hàng hóa xuất khẩu chuyển cửa khẩu
        ExportGateTransfer = 6,
        //Sổ theo dõi hàng hóa nhập khẩu chuyển cửa khẩu
        ImportGateTransfer = 7,
        //Sổ theo dõi hàng hóa kinh doanh tạm nhập tái xuất
        TempImportedReExport = 8,
        //Số liệu phương tiện vận chuyển hàng hóa
        VehicleTransportGoods = 9,
    }
}

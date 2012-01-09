using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECustoms.Utilities.Enums
{
    public enum RoleType
    {

        //1-Tạo mới tờ khai
        //2-xóa tờ khai
        //3-cập nhật tờ khai
        //4-Tạo mới phương tiện
        //5-xóa phương tiện
        //6-cập nhật phương tiện
        //7-export tờ khai
        //8-export phương tiện
        //9-Tạo mới người dùng
        //10-xóa người dùng
        //11-cập nhật người dùng
        //12-Đổi mật khẩu
        //13-xác nhận xuất cảnh
        //14-xác nhận nhập cảnh có hàng
        //15-xác nhận nhập cảnh không có hàng
        //16-xác nhận hàng đã vào nội địa
        //17-Tìm kiếm
        //18-In bao cao

        CreateDecleration = 1,
        DeleteDecleration = 2,
        UpdateDecleration = 3,
        CreateVehicle = 4,
        DeleteVehicle = 5,
        UpdateVehicle = 6,
        ExportDecleration = 7,
        ExportVehicle = 8,
        CreateUser = 9,
        DeleteUser = 10,
        UpdateUser = 11,
        ChangePassword = 12,
        ConfirmExport = 13,
        ConfirmImportHasItem = 14,
        ConfirmImportNoItem = 15,
        ConfirmLocalImport = 16,
        Search = 17,
        PrintReport = 18



    }
}

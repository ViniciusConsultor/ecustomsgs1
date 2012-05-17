namespace ECustoms.Utilities
{
    public class ConstantInfo
    {       
        #region Table User
        public const string TBL_USER_USERID = "UserID";
        public const string TBL_USER_NAME = "Name";
        public const string TBL_USER_SEX = "Sex";
        public const string TBL_USER_BIRTHDAY = "Birthday";
        public const string TBL_USER_ADDRESS = "Address";
        public const string TBL_USER_EMAIL = "Email";
        public const string TBL_USER_PHONE_NUMBER = "PhoneNumber";
        public const string TBL_USER_USERNAME = "UserName";
        public const string TBL_USER_PASSWORD = "Password";
        public const string TBL_USER_PERMISSION = "Permission";        
        public const string TBL_USER_IS_ACTIVE = "IsActive";
        #endregion

        #region Table Permission 
        public const string TBL_PERMISSION_PERMISSION_ID = "PermissionID";
        public const string TBL_PERMISSION_PERMISSION = "Permission";
        #endregion

        #region Message
        public const string MESSAGE_LOGIN_FAIL = "Tên truy cập hoặc mật khẩu không đúng.";
        public const string MESSAGE_WELCOME = "Xin chào {0}";
        public const string MESSAGE_USERNAME_EXISTING = "Tên truy cập đã tồn tại.";        
        public const string MESSAGE_BLANK_USERNAME = "Tên truy cập không được trống.";
        public const string MESSAGE_BLANK_PASSWORD = "Mật khẩu không được trống.";
        public const string MESSAGE_COMPARE_PASSWORD = "Mật khẩu và nhập lại nhập khẩu phải giống nhau.";
        public const string MESSAGE_BLANK_EMAIL = "Bạn cần nhập Email.";
        public const string MESSAGE_WRONG_EMAIL = "Địa chỉ Email không dúng.";
        public const string MESSAGE_BLANK_DRIVER = "Tên lái xe không được trống.";
        public const string MESSAGE_INSERT_SUCESSFULLY = "Tạo mới xong.";
        public const string MESSAGE_UPDATE_SUCESSFULLY = "Cập nhật xong.";
        public const string MESSAGE_UPDATE_FAIL = "Cập nhật lỗi.";
        public const string MESSAGE_INSERT_FAIL = "Tạo mới lỗi";
        public const string MESSAGE_ADD_MORE = "Bạn có muốn thêm tiếp?";
        public const string MESSAGE_ADD_DONE = "Thêm xong.";
        public const string MESSAGE_BLANK_DECLARATION_NUMBER = "Số tờ khai không được trống.";
        public const string MESSAGE_TITLE = " :: Chi cuc Hai quan Tan Thanh - Doi giam sat";
        public const string MESSAGE_INCORRECT_PASS = "Mật khẩu cũ chưa đúng!";
        public const string MESSAGE_NO_VEHICLE = "Bạn cần thêm phương tiện.";
        // Group
        public const string MESSAGE_BLANK_NAME = "Tên nhóm không được trống.";
        public const string MESSAGE_GROUP_NAME_EXISTING = "Tên nhóm đã tồn tại.";
        public const string MESSAGE_GROUP_NOT_EXIST = "Nhóm không còn tồn tại, xin kiểm tra lại";
        // User in Group
        public const string MESSAGE_ADD_USER_IN_GROUP_SUCESSFULLY = "Cập nhật thành công.";
        public const string MESSAGE_ADD_USER_IN_GROUP_FAIL = "Cập nhật bị lỗi, xin kiểm tra lại kêt nối mạng";
        #endregion

        //list permission key
        public const int PERMISSON_TAO_MOI_NGUOI_DUNG = 1;
        public const int PERMISSON_TAO_MOI_NHOM_NGUOI_DUNG = 2;
        public const int PERMISSON_CAP_NHAT_NGUOI_DUNG = 3;
        public const int PERMISSON_CAP_NHAT_NHOM_NGUOI_DUNG = 4;
        public const int PERMISSON_XOA_NGUOI_DUNG = 5;
        public const int PERMISSON_XOA_NHOM_NGUOI_DUNG = 6;
        public const int PERMISSON_TAO_MOI_PHUONG_TIEN = 7;
        public const int PERMISSON_CAP_NHAT_PHUONG_TIEN = 8;
        public const int PERMISSON_XOA_PHUONG_TIEN = 9;
        public const int PERMISSON_TAO_MOI_THONG_TIN_DE_NGHI_KIEM_TRA = 10;
        public const int PERMISSON_CAP_NHAT_THONG_TIN_DE_NGHI_KIEM_TRA = 11;
        public const int PERMISSON_XOA_THONG_TIN_DE_NGHI_KIEM_TRA = 12;
        public const int PERMISSON_TAO_TO_KHAI = 13;
        public const int PERMISSON_CAP_NHAT_TO_KHAI = 14;
        public const int PERMISSON_XOA_TO_KHAI = 15;
        public const int PERMISSON_XAC_NHAN_XUAT_CANH = 16;
        public const int PERMISSON_XAC_NHAN_NHAP_CANH = 17;
        public const int PERMISSON_KET_XUAT_DU_LIEU = 18;
        public const int PERMISSON_NHAN_KET_QUA_KIEM_TRA = 19;
        public const int PERMISSON_IN_BAO_CAO = 20;
        public const int PERMISSON_DOI_MAT_KHAU = 21;
        public const int PERMISSON_CAP_NHAT_THOI_GIAN_VAO_NOI_DIA = 22;
        public const int PERMISSON_TRA_HO_SO = 23;
        public const int PERMISSON_EXPORT_HO_SO = 24;
        public const int PERMISSON_XAC_NHAN_HANG_VAO_NOI_DIA = 25;
        public const int PERMISSON_HANG_VAO_BAI = 26;
        public const int PERMISSON_CAP_NHAT_KET_QUA_KIEM_TRA = 27;
        public const int PERMISSON_XOA_KET_QUA_KIEM_TRA = 28;
        public const int PERMISSON_THEM_PHUONG_TIEN_CHO_TO_KHAI_NHAP_CANH = 29;
        public const int PERMISSON_XOA_PHUONG_TIEN_CHO_TO_KHAI_NHAP_CANH = 30;
        public const int PERMISSON_CAP_NHAT_PHUONG_TIEN_CHO_TO_KHAI_NHAP_CANH = 31;
        public const int PERMISSON_THEM_PHUONG_TIEN_CHO_TO_KHAI_XUAT_CANH = 32;
        public const int PERMISSON_XOA_PHUONG_TIEN_CHO_TO_KHAI_XUAT_CANH = 33;
        public const int PERMISSON_CAP_NHAT_PHUONG_TIEN_CHO_TO_KHAI_XUAT_CANH = 34;

        public const int PERMISSON_TRA_CUU_THONG_TIN_TNTX = 35;
        public const int PERMISSON_XAC_NHAN_HOI_BAO_TNTX = 36;
        public const int PERMISSON_BO_XUNG_THONG_TIN_TNTX = 37;
        public const int PERMISSON_IN_BAO_CAO_TNTX = 38;

        public const int PERMISSON_THEM_PT_VAO_BAI_XUAT = 39;

        public const int PERMISSON_THEM_PT_XE_TRUNG_QUOC = 40;


        public const int PERMISSON_TRA_CUU_THONG_TIN_LOAI_PHUONG_TIEN = 41;
        public const int PERMISSON_THEM_MOI_THONG_TIN_LOAI_PHUONG_TIEN = 42;
        public const int PERMISSON_CAP_NHAT_THONG_TIN_LOAI_PHUONG_TIEN = 43;
        public const int PERMISSON_XOA_THONG_TIN_LOAI_PHUONG_TIEN = 44;

        public const int PERMISSON_TRA_CUU_THONG_TIN_THU_PHI_PHUONG_TIEN = 45;
        public const int PERMISSON_XAC_NHAN_THU_PHI_PHUONG_TIEN_XUAT_CANH = 46;
        public const int PERMISSON_XAC_NHAN_THU_PHI_PHUONG_TIEN_NHAP_CANH = 47;
        public const int PERMISSON_XUAT_EXCEL_THONG_TIN_THU_PHI_PHUONG_TIEN = 48;

        public const int PERMISSON_XEM_BAO_CAO_THU_PHI_PHUONG_TIEN = 49;

        public const int PERMISSON_TRA_CUU_THONG_CAU_HINH_TINH_PHI_PHUONG_TIEN = 50;
        public const int PERMISSON_THEM_MOI_THONG_CAU_HINH_TINH_PHI_PHUONG_TIEN = 51;
        public const int PERMISSON_CAP_NHAT_THONG_CAU_HINH_TINH_PHI_PHUONG_TIEN = 52;
        public const int PERMISSON_XOA_THONG_CAU_HINH_TINH_PHI_PHUONG_TIEN = 53;



        #region System

        public const string HashString = "dfkjdk234fda23fdfssf";

        #endregion
    }
}

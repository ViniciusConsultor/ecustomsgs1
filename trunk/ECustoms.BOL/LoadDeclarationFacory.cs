using System.Linq;
using ECustoms.DAL;
using System.Configuration;
using System.Data;
using ECustoms.Utilities;

namespace ECustoms.BOL
{
    public class LoadDeclarationFactory
    {
        public static DToKhaiMD Load(int number, string typeCode, string customCode, int year)
        {
            if (ConfigurationManager.ConnectionStrings["dbEcusDeclaration"] == null) return null;
            var _db = new dbEcusDeclaration(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcusDeclaration"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                var toKhai = _db.DToKhaiMDs.Where(x => x.SoTK == number && x.Ma_LH == typeCode && x.Ma_HQ == customCode && x.NamDK == year).FirstOrDefault();
                if (toKhai == null) return null;
                var hang = _db.DHangMDs.Where(x => x.SoTK == number && x.Ma_LH == typeCode && x.Ma_HQ == customCode && x.NamDK == year).FirstOrDefault();
                if (hang != null)
                {
                    toKhai.TenHang = Converter.TCVN3ToUnicode(hang.Ten_Hang);
                    toKhai.Dvt = _db.SDVTs.Where(x => x.Ma_DVT == hang.Ma_DVT).FirstOrDefault().Ten_DVT;
                    toKhai.SoLuong = hang.Luong;
                }
                return toKhai;
            }
            catch
            {
                return null;
            }
            finally
            {
                _db.Connection.Close();
            }
        }
    }
}

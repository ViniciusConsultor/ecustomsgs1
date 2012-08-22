using System.Linq;
using ECustoms.DAL;
using System.Configuration;
using System.Data;

namespace ECustoms.BOL
{
    public class LoadDeclarationFactory
    {
        public static DToKhaiMD Load(int number, string typeCode, string customCode, int year)
        {
            var _db = new dbEcusDeclaration(ConfigurationManager.ConnectionStrings["dbEcusDeclaration"].ConnectionString);
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                var r = _db.DToKhaiMDs.Where(x => x.SoTK == number && x.Ma_LH == typeCode && x.Ma_HQ == customCode && x.NamDK == year).FirstOrDefault();
                return r;
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

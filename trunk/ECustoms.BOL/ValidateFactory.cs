using System.Linq;
using ECustoms.DAL;
using ECustoms.Utilities;
using System.Configuration;
using System.Data;

namespace ECustoms.BOL
{
    public class ValidateFactory
    {

        public static string[] GetAllTag()
        {
            var _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                return _db.tblValidates.Select(t => t.TagName).ToArray();
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

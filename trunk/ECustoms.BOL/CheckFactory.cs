using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using ECustoms.DAL;
using ECustoms.Utilities;

namespace ECustoms.BOL
{
    public class CheckFactory
    {
        public  const int  DECLARATION_TYPE_EXPORT= 0;
        public  const int DECLARATION_TYPE_IMPORTT = 1;
        public  const int DECLARATION_TYPE_EXPORT_AND_IMPORT = 2;
        public static List<ViewAllCheck> SelectAll()
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            List < ViewAllCheck > list = db.ViewAllChecks.OrderByDescending(g => g.ModifedDate).ToList();
            db.Connection.Close();
            return list;
        }

        public static int Insert(tblCheck check)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            check.CreateDate = CommonFactory.GetCurrentDate();
            check.ModifedDate = CommonFactory.GetCurrentDate();
            db.AddTotblChecks(check);
            int re = db.SaveChanges();
            db.Connection.Close();
            return re;
        }

        public static int Update(tblCheck check)
        {
            check.ModifedDate = CommonFactory.GetCurrentDate();
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var checkOrgin = db.tblChecks.Where(g => g.CheckID == check.CheckID).FirstOrDefault();
            if (checkOrgin == null) return -1;
            db.Attach(checkOrgin);
            db.ApplyPropertyChanges("tblChecks", check);
            int re = db.SaveChanges();
            db.Connection.Close();
            return re;
        }

        public static tblCheck SelectByID(long checkID) {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            tblCheck check = db.tblChecks.Where(g => g.CheckID == checkID).FirstOrDefault();
            db.Connection.Close();
            return check;
        }

        public static int Delete(long checkID)
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var check = db.tblChecks.Where(g => g.CheckID == checkID).FirstOrDefault();
            if (check == null) return -1;
            db.DeleteObject(check);
            int re = db.SaveChanges();
            db.Connection.Close();
            return re;
        }

        public static string GetCheckCode()
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            var check = db.tblChecks.OrderByDescending(g => g.CheckID).FirstOrDefault();
            db.Connection.Close();
            if (check != null)
            {
              return "KT_" + string.Format("{0:00000}", check.CheckID);
            }
            else
            {
              return "KT_" + string.Format("{0:00000}", 1);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using ECustoms.DAL;
using ECustoms.Utilities;

namespace ECustoms.BOL
{
    public class SettingsFactory
    {
        public static tblSetting GetTheLastSetting()
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();
                var settings = from item in _db.tblSettings orderby item.LastSync descending select item;

                return settings.FirstOrDefault();
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

        public static bool UpdateSettings(string  version, DateTime lastSync, int interval, string  syncTime, bool  isStartSync)
        {
            dbEcustomEntities _db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            try
            {
                if (_db.Connection.State == ConnectionState.Closed) _db.Connection.Open();

                var existing = _db.tblSettings.FirstOrDefault(p => p.Version == version);
                if(existing==null)
                {
                    tblSetting setting = new tblSetting();
                    setting.Version = version;
                    setting.LastSync = lastSync;
                    setting.SyncInterval = interval;
                    setting.SyncTime = syncTime;
                    setting.IsStartingSync = isStartSync;
                    _db.AddTotblSettings(setting);

                    return _db.SaveChanges() > 0;
                }
                else
                {
                    //existing.Version = version;
                    existing.LastSync = lastSync;
                    existing.SyncInterval = interval;
                    existing.SyncTime = syncTime;
                    existing.IsStartingSync = isStartSync;

                    return _db.SaveChanges() > 0;
                }
            }
            catch(Exception e)
            {
                return false;
            }
            finally
            {
                _db.Connection.Close();
            }

            return false;
        }
    }
}

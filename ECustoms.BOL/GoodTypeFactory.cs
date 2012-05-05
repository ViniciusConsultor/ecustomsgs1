﻿using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using ECustoms.DAL;
using ECustoms.Utilities;

namespace ECustoms.BOL
{
    public class GoodTypeFactory
    {
        public static List<tblGoodsType> SelectAll()
        {
            var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
            List<tblGoodsType> list = db.tblGoodsTypes.ToList();
            db.Connection.Close();
            return list;
        }
    }
}

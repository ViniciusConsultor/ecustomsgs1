using System.Collections.Generic;
using System.Configuration;
using System.Data.Objects.DataClasses;
using ECustoms.Utilities;
using System.Linq;

namespace ECustoms.DAL
{
    public partial class ViewAllVehicleHasGood: EntityObject
    {
        public List<VehicleNumber> ListVehicleChangeGood { get; set; }
    }
    public partial class ViewAllVehicle : EntityObject
    {
        public string VehicleChangeGoodVN
        {
            get
            {
                if (StatusChangeGood == (byte)Utilities.Enums.VehicleChangeStatus.SangTaiTQ) return string.Empty;
                var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

                var listId = db.tblVehicleChanges.Where(x => x.VehicleFromID == this.VehicleID).Select(x => x.VehicleToID)
                                                .Union(db.tblVehicleChanges.Where(x => x.VehicleToID == this.VehicleID).Select(x => x.VehicleFromID))
                                                .Distinct();
                var listPlateNumber = listId.Select(id => db.tblVehicles.Where(x => x.VehicleID == id).FirstOrDefault().PlateNumber).ToList();
                return listPlateNumber.Aggregate(string.Empty, (current, item) => current + (item + ";")).TrimEnd(';');
            }

        }
        public string VehicleChangeGoodChinese
        {
            get
            {
                if (StatusChangeGood == (byte)Utilities.Enums.VehicleChangeStatus.SangTaiVN) return string.Empty;
                var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

                var listId = db.tblVehicleChanges.Where(x => x.VehicleFromID == this.VehicleID).Select(x => x.VehicleToID)
                                                .Union(db.tblVehicleChanges.Where(x => x.VehicleToID == this.VehicleID).Select(x => x.VehicleFromID))
                                                .Distinct();
                var listPlateNumber = listId.Select(id => db.tblVehicles.Where(x => x.VehicleID == id).FirstOrDefault().PlateNumber).ToList();
                return listPlateNumber.Aggregate(string.Empty, (current, item) => current + (item + ";")).TrimEnd(';');
            }

        }
    }
    public partial class tblVehicle : EntityObject
    {
        public List<VehicleNumber> ListVehicleChangeGood { get; set; }
    }
}

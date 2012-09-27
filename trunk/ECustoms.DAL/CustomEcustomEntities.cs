using System.Collections.Generic;
using System.Configuration;
using System.Data.Objects.DataClasses;
using ECustoms.Utilities;
using System.Linq;

namespace ECustoms.DAL
{
    public partial class ViewAllVehicleHasGood: EntityObject
    {
        private string _vehicleChangeGoodVn;
        private string _vehicleChangeGoodChinese;
        private List<VehicleNumber> _listVehicleChangeGood;
        public List<VehicleNumber> ListVehicleChangeGood
        {
            get
            {
                if (_listVehicleChangeGood != null) return _listVehicleChangeGood;
                if (StatusChangeGood == null) return null;
                var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
                var listId = db.tblVehicleChanges.Where(x => x.VehicleFromID == this.VehicleID).Select(x => x.VehicleToID)
                                                .Union(db.tblVehicleChanges.Where(x => x.VehicleToID == this.VehicleID).Select(x => x.VehicleFromID))
                                                .Distinct();
                _listVehicleChangeGood = listId.Select(id => db.tblVehicles.Where(x => x.VehicleID == id).FirstOrDefault()).ToList().Select(vehicle => new VehicleNumber(vehicle.PlateNumber, vehicle.VehicleID)).ToList();
                return _listVehicleChangeGood;
            }
            set
            {
                _listVehicleChangeGood = value;
                if (StatusChangeGood == (byte) Utilities.Enums.VehicleChangeStatus.SangTaiVN)
                {
                    _vehicleChangeGoodVn = string.Empty;
                    foreach (var vehicleNumber in _listVehicleChangeGood)
                    {
                        _vehicleChangeGoodVn += vehicleNumber.PlateNumber + ";";
                    }
                    _vehicleChangeGoodVn = _vehicleChangeGoodVn.TrimEnd(';');  
                }
                if (StatusChangeGood == (byte) Utilities.Enums.VehicleChangeStatus.SangTaiTQ)
                {
                    _vehicleChangeGoodChinese = string.Empty;
                    foreach (var vehicleNumber in _listVehicleChangeGood)
                    {
                        _vehicleChangeGoodChinese += vehicleNumber.PlateNumber + ";";
                    }
                    _vehicleChangeGoodChinese = _vehicleChangeGoodChinese.TrimEnd(';');
                }
            }
        }

        public string VehicleChangeGoodVn
        {
            get
            {
                if (_vehicleChangeGoodVn != null) return _vehicleChangeGoodVn;
                if (StatusChangeGood == (byte) Utilities.Enums.VehicleChangeStatus.SangTaiVN)
                {
                    _vehicleChangeGoodVn = string.Empty;
                    foreach (var vehicleNumber in ListVehicleChangeGood)
                    {
                        _vehicleChangeGoodVn += vehicleNumber.PlateNumber + ";";
                    }
                    _vehicleChangeGoodVn = _vehicleChangeGoodVn.TrimEnd(';');
                    return _vehicleChangeGoodVn;
                }
                return null;
            }
        }
        public string VehicleChangeGoodChinese
        {
            get
            {
                if (_vehicleChangeGoodChinese != null) return _vehicleChangeGoodChinese;
                if (StatusChangeGood == (byte)Utilities.Enums.VehicleChangeStatus.SangTaiTQ)
                {
                    _vehicleChangeGoodChinese = string.Empty;
                    foreach (var vehicleNumber in ListVehicleChangeGood)
                    {
                        _vehicleChangeGoodChinese += vehicleNumber.PlateNumber + ";";
                    }
                    _vehicleChangeGoodChinese = _vehicleChangeGoodChinese.TrimEnd(';');
                    return _vehicleChangeGoodChinese;
                }
                return null;
            }
        }
    }
    public partial class ViewAllVehicle : EntityObject
    {
        private string _vehicleChangeGoodVn;
        private string _vehicleChangeGoodChinese;
        public string VehicleChangeGoodVn
        {
            get
            {
                if (_vehicleChangeGoodVn != null) return _vehicleChangeGoodVn;
                if (StatusChangeGood == (byte)Utilities.Enums.VehicleChangeStatus.SangTaiVN)
                {
                    var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));
                    var listId = db.tblVehicleChanges.Where(x => x.VehicleFromID == this.VehicleID).Select(x => x.VehicleToID)
                                                    .Union(db.tblVehicleChanges.Where(x => x.VehicleToID == this.VehicleID).Select(x => x.VehicleFromID))
                                                    .Distinct();
                    var listPlateNumber = listId.Select(id => db.tblVehicles.Where(x => x.VehicleID == id).FirstOrDefault().PlateNumber).ToList();
                    _vehicleChangeGoodVn = listPlateNumber.Aggregate(string.Empty, (current, item) => current + (item + ";")).TrimEnd(';');    
                }
                return _vehicleChangeGoodVn;
            }
        }
        public string VehicleChangeGoodChinese
        {
            get
            {
                if (_vehicleChangeGoodChinese != null) return _vehicleChangeGoodChinese;
                if (StatusChangeGood == (byte)Utilities.Enums.VehicleChangeStatus.SangTaiTQ)
                {
                    var db = new dbEcustomEntities(Common.Decrypt(ConfigurationManager.ConnectionStrings["dbEcustomEntities"].ConnectionString, true));

                    var listId = db.tblVehicleChanges.Where(x => x.VehicleFromID == this.VehicleID).Select(x => x.VehicleToID)
                                                    .Union(db.tblVehicleChanges.Where(x => x.VehicleToID == this.VehicleID).Select(x => x.VehicleFromID))
                                                    .Distinct();
                    var listPlateNumber = listId.Select(id => db.tblVehicles.Where(x => x.VehicleID == id).FirstOrDefault().PlateNumber).ToList();
                    _vehicleChangeGoodChinese = listPlateNumber.Aggregate(string.Empty, (current, item) => current + (item + ";")).TrimEnd(';');    
                }
                return _vehicleChangeGoodChinese;

            }
        }
    }
    public partial class tblVehicle : EntityObject
    {
        public List<VehicleNumber> ListVehicleChangeGood { get; set; }
    }
}

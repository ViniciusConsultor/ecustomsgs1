using System;
using System.Collections.Generic;
using Niq.Msd.Base;

namespace ECustoms.DAL
{
    [Serializable]
    public class VehicleNumber : IObjectData
    {
        public VehicleNumber(string plateNumber, long vehicleId)
        {
            PlateNumber = plateNumber;
            VehicleId = vehicleId;
        }

        public string PlateNumber { get; set; }
        public long VehicleId { get; set; }
        public string ToName()
        {
            return PlateNumber;
        }
    }

    public class VehicleNumberComparer : IEqualityComparer<VehicleNumber>
    {
        public bool Equals(VehicleNumber x, VehicleNumber y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;
            return x.VehicleId == y.VehicleId;
        }
        public int GetHashCode(VehicleNumber vehicle)
        {
            if (Object.ReferenceEquals(vehicle, null)) return 0;
            var hashVehicleId = vehicle.VehicleId.GetHashCode();
            var hashPlateNumber = vehicle.PlateNumber.GetHashCode();
            return hashVehicleId ^ hashPlateNumber;
        }
    }
}

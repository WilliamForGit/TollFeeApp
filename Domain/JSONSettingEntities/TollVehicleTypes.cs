using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.JSONSettingEntities
{
    public class TollVehicleTypes
    {
        public List<TollVehicleType>? VehicleTypes { get; set; }
    }

    public class TollVehicleType
    {
        public string? VehicleType { get; set; }
        public bool? isTollFreeVehicle { get; set; }
    }
}

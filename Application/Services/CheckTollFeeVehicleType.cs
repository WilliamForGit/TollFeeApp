using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.JSONSettingEntities;
using Infrastructure.JSONSettingsService;

namespace Application.Services
{
    public static class CheckTollFeeVehicleType
    {
        public static bool IsTollFreeVehicle(string type)
        {
            try
            {
                var tollVehicleTypes = new GetJsonSettingsData<TollVehicleTypes>();
                TollVehicleTypes vehicleTypes = tollVehicleTypes.ReadJsonSettingsData("VehicleType");

                if (vehicleTypes != null && vehicleTypes.VehicleTypes != null)
                {
                    foreach (var vehicleType in vehicleTypes.VehicleTypes)
                    {
                        if (vehicleType.VehicleType.Equals(type) && vehicleType.isTollFreeVehicle == false)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing when checking the vehicle type for toll fee. Error: {ex.Message}");
                return false;
            }
        }
    }
}


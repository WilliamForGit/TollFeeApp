using Domain.JSONSettingEntities;
using Newtonsoft.Json;

namespace Infrastructure.JSONSettingsService
{
    public class GetJsonSettingsData<T>
    {
        public T? ReadJsonSettingsData(string filePathType)
        {
            string jsonFilePath = "";
            try
            {
                switch (filePathType)
                {
                    case "TollFeeDates":
                        jsonFilePath = "JSONSettings\\TollFeeDates.json";
                        break;
                    case "TollFeeTimePoints":
                        jsonFilePath = "JSONSettings\\TollFeeTimePoints.json";
                        break;
                    case "VehicleType":
                        jsonFilePath = "JSONSettings\\TollVehicleTypes.json";
                        break;
                    default:
                        Console.WriteLine($"Error: Invalid filePathType '{filePathType}'.");
                        return default(T);
                }

                if (File.Exists(jsonFilePath))
                {
                    string jsonData = File.ReadAllText(jsonFilePath);

                    // Deserialize the JSON data into the specified type
                    T dataObj = JsonConvert.DeserializeObject<T>(jsonData);

                    if (dataObj != null)
                    {
                        return dataObj;
                    }
                    else
                    {
                        Console.WriteLine($"Error: Failed to deserialize JSON data from {jsonFilePath}.");
                    }
                }
                else
                {
                    Console.WriteLine($"Error: JSON file {jsonFilePath} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred when loading data from the JSON file {jsonFilePath}: {ex.Message}");
            }

            return default(T);
        }
    }
}
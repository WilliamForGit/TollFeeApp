namespace Domain.Entities
{
    public class TollVehicle
    {
        public string? VehicleId { get; set; }

        public string? VehicleType { get; set; }

        public List<DateTime>? VehicleDateTimes { get; set; }
    }
}
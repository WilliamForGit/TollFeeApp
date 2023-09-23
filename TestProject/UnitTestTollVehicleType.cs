using Application.Services;
using Domain.Entities;

namespace TestProject
{
    [TestClass]
    public class UnitTestTollVehicleType
    {
        [TestMethod]
        public void TestTollVehicleType()
        {
            var tollVehicleObj = new TollVehicle
            {
                VehicleId = "ZOP678",
                VehicleType = "Foreign",
                VehicleDateTimes = new List<DateTime>
                {
                    DateTime.Parse("2013-12-25 15:31:00")
                }
            };

            bool result = CheckTollFeeVehicleType.IsTollFreeVehicle(tollVehicleObj.VehicleType);

            Assert.AreEqual(true, result);

            Console.WriteLine($"Unit Test case for {tollVehicleObj.VehicleId} with type {tollVehicleObj.VehicleType}  is toll free vehicle: {result}");
        }
    }
}
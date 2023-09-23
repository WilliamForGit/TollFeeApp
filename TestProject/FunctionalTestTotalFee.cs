global using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.Services;
using Domain.Entities;

namespace TestProject
{
    [TestClass]
    public class FunctionalTestTotalFee
    {
        [TestMethod]
        public void TestTotalFee()
        {
            TollFeeCalculatorService tollFeeCalculator = new();

            TollVehicle tollVehicleObj = new()
            {
                VehicleId = "ABC123",
                VehicleType = "Car"
            };

            //Test for time points in one day
            List<DateTime> timestamps = new List<DateTime>
        {
            DateTime.Parse("2013-09-05 07:30:45"),
            DateTime.Parse("2013-09-05 10:50:00"),
            DateTime.Parse("2013-09-05 11:49:00"),

            DateTime.Parse("2013-09-05 14:30:45"),
            DateTime.Parse("2013-09-05 15:30:45"),

            DateTime.Parse("2013-09-05 16:30:45"),
            DateTime.Parse("2013-09-05 17:30:45"),

            DateTime.Parse("2013-09-05 18:39:00"),
            DateTime.Parse("2013-09-05 23:59:59"),
            DateTime.Parse("2013-09-06 00:00:00")
        };

            tollVehicleObj.VehicleDateTimes = timestamps;

            int result = tollFeeCalculator.CalculateTotalFeeDay(tollVehicleObj);

            Assert.AreEqual(60, result);

            Console.WriteLine($"Function Test case for {tollVehicleObj.VehicleId} with total fee: {result}");
        }
    }
}
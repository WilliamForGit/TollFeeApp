using Application.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class UnitTestNoFeeDay
    {
        [TestMethod]
        public void TestNoFeeDay()
        {
            // Define the vehicle type and timestamps with time points that should not incur a fee
            var tollVehicleObj = new TollVehicle
            {
                VehicleId = "EFH456",
                VehicleType = "Car",
                VehicleDateTimes = new List<DateTime>
                {
                    DateTime.Parse("2013-12-25 15:31:00")
                }
            };

            bool result = CheckTollFreeDate.IsTollFreeDate(tollVehicleObj.VehicleDateTimes.FirstOrDefault());

            Assert.AreEqual(true, result);

            Console.WriteLine($"Unit Test case for {tollVehicleObj.VehicleId} for No fee day {tollVehicleObj.VehicleDateTimes.FirstOrDefault()} is: {result}");
        }
    }
}

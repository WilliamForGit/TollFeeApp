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
    public class UnitTestWithTimePoint
    {
        [TestMethod]
        public void TestTimePointForFee()
        {
            var tollVehicleObj = new TollVehicle
            {
                VehicleId = "QWE789",
                VehicleType = "Car",
                VehicleDateTimes = new List<DateTime>
                {
                    DateTime.Parse("2013-09-05 17:56:00")
                }
            };

            int result = CheckTollFeeByTimeRange.GetTollFeeByTimeRange(tollVehicleObj.VehicleDateTimes.FirstOrDefault());

            Assert.AreEqual(13, result);

            Console.WriteLine($"Unit Test case for {tollVehicleObj.VehicleId} for a timepoint {tollVehicleObj.VehicleDateTimes.FirstOrDefault()} with fee: {result}");
        }
    }
}

using Domain.Entities;
using Domain.JSONSettingEntities;
using Infrastructure.JSONSettingsService;

namespace TestProject
{
    [TestClass]
    public class UnitTestIsFreeMonth
    {
        [TestMethod]
        public void TestFreeMonth()
        {
            var tollVehicleObj = new TollVehicle
            {
                VehicleId = "CDE110",
                VehicleType = "Car",
                VehicleDateTimes = new List<DateTime>
                {
                    DateTime.Parse("2013-07-10 09:50:00")
                }
            };

            var tollFeeDates = new GetJsonSettingsData<YearlyTollFeeDates>();
            YearlyTollFeeDates tollFeeDatesObj = tollFeeDates.ReadJsonSettingsData("TollFeeDates");

            bool isFreeMonth = false;

            if (tollVehicleObj.VehicleDateTimes.FirstOrDefault().Year == tollFeeDatesObj.Year)
            {
                foreach (var tollFeeDate in tollFeeDatesObj.Months)
                {
                    if (tollFeeDate.Month == tollVehicleObj.VehicleDateTimes.FirstOrDefault().Month)
                    {
                        if (tollFeeDate.IsFreeMonth)
                        {
                            isFreeMonth = true;
                        }
                        else
                        {
                            isFreeMonth = false;
                        }
                    }
                }

                Assert.AreEqual(true, isFreeMonth);

                Console.WriteLine($"Unit Test case for {tollVehicleObj.VehicleId} with a timepoint {tollVehicleObj.VehicleDateTimes.FirstOrDefault()} is fee free month: {isFreeMonth}");
            }
        }
    }
}

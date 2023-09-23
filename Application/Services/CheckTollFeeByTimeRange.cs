using Domain.JSONSettingEntities;
using Infrastructure.JSONSettingsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public static class CheckTollFeeByTimeRange
    {
        static readonly List<TollFeeTPRange> tollFeeRanges = new();

        private static void LoadTollFeeData()
        {
            try
            {
                var timePointsData = new GetJsonSettingsData<DayTollFeeTimePoints>();

                DayTollFeeTimePoints tollFeeTRData = timePointsData.ReadJsonSettingsData("TollFeeTimePoints");

                foreach (var timePoint in tollFeeTRData.TollFeeTimePoints)
                {
                    foreach (var timeRangeStr in timePoint.TimePoints)
                    {
                        // Split the time range into start and end points using '-' as the separator.
                        var timeRangeParts = timeRangeStr.Split('-');
                        if (timeRangeParts.Length == 2 &&
                            TimeSpan.TryParse(timeRangeParts[0], out TimeSpan startTime) &&
                            TimeSpan.TryParse(timeRangeParts[1], out TimeSpan endTime))
                        {
                            tollFeeRanges.Add(new TollFeeTPRange
                            {
                                FeeAmount = timePoint.FeeAmount,
                                StartTime = startTime,
                                EndTime = endTime
                            });
                        }
                        else
                        {
                            // Handle invalid time range format.
                            Console.WriteLine($"Invalid time range format: {timeRangeStr}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any other exceptions that may occur during parsing.
                Console.WriteLine($"Error processing time range. Error: {ex.Message}");
            }
        }

        //To calculate the toll fee by time points
        public static int GetTollFeeByTimeRange(DateTime date)
        {
            LoadTollFeeData(); //load the time points of day to list

            var timeOfDay = date.TimeOfDay;

            foreach (var range in tollFeeRanges)
            {
                if (timeOfDay >= range.StartTime && timeOfDay <= range.EndTime)
                {
                    return range.FeeAmount;
                }
            }

            return 0; // Default fee when no matching range is found.
        }
    }


    public class TollFeeTPRange
     {
            public int FeeAmount { get; set; }
            public TimeSpan StartTime { get; set; }
            public TimeSpan EndTime { get; set; }
     }
    
}
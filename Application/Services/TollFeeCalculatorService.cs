using Application.Services.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class TollFeeCalculatorService : ITollFeeCalculatorService
    {
        /**
            * Calculate the total toll fee for one day
            * @param a entity object of the TollVehicle class,which with the VehicleType and Time points under one day
            * @return - the total toll fee for that day     
         */
        public int CalculateTotalFeeDay(TollVehicle tollVehicle)
        {
            int totalFee = 0;

            try
            {
                if (CheckTollFeeVehicleType.IsTollFreeVehicle(tollVehicle.VehicleType))
                    return 0;

                DateTime previousTimestamp = DateTime.MinValue;
                int maxFeeInInterval = 0;

                foreach (DateTime timestamp in tollVehicle.VehicleDateTimes.OrderBy(t => t))
                {
                    int tollFee = CalculateTollFee(timestamp);

                    if ((timestamp - previousTimestamp).TotalMinutes >= 60)
                    {
                        totalFee += maxFeeInInterval;
                        maxFeeInInterval = tollFee;
                    }
                    else
                    {
                        maxFeeInInterval = Math.Max(maxFeeInInterval, tollFee);
                    }

                    previousTimestamp = timestamp;
                }

                // Add the last maximum fee
                totalFee += maxFeeInInterval;

                if (totalFee > 60) totalFee = 60;

                return totalFee;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing when calculate the total fee.  Error: {ex.Message}");
                return -1;
            }
        }

        //count the respective fee by a TimePoint
        private int CalculateTollFee(DateTime date)
        {
            try
            {
                if (CheckTollFreeDate.IsTollFreeDate(date)) return 0;

                int Fee = CheckTollFeeByTimeRange.GetTollFeeByTimeRange(date);
                return Fee;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing when calculate the toll fee.  Error: {ex.Message}");
                return -1;
            }
        }
    }
}
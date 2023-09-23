using Domain.JSONSettingEntities;
using Infrastructure.JSONSettingsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public static class CheckTollFreeDate
    {
        /**
         * To get the data from the dates of one year from JsonSettings ,
         * then to judge the day is free day or not
         */
        public static bool IsTollFreeDate(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

            try
            {
                var tollFeeDates = new GetJsonSettingsData<YearlyTollFeeDates>();
                YearlyTollFeeDates tollFeeDatesObj = tollFeeDates.ReadJsonSettingsData("TollFeeDates");

                if (tollFeeDatesObj == null) return false;

                if (year == tollFeeDatesObj.Year)
                {
                    foreach (var tollFeeDate in tollFeeDatesObj.Months)
                    {
                        if (tollFeeDate.Month == month)
                        {
                            if (tollFeeDate.IsFreeMonth)
                            {
                                return true;
                            }
                            else
                            {
                                if (tollFeeDate.NoFeeDays.Contains(day))  //check the day is list in the 'no fee days'
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing when checking date:  {date.ToString()} is no fee days. Error: {ex.Message}");
            }

            return false;
        }

    }
}

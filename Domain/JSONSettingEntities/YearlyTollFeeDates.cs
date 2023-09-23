using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.JSONSettingEntities
{
    public class YearlyTollFeeDates
    {
        public int Year { get; set; }
        public List<MonthData> Months { get; set; } = new List<MonthData>();
    }

    public class MonthData
    {
        public int Month { get; set; }
        public bool IsFreeMonth { get; set; }
        public List<int> NoFeeDays { get; set; } = new List<int>();
    }
}

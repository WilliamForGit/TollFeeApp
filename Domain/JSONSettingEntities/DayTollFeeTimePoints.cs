using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.JSONSettingEntities
{
    public class DayTollFeeTimePoints
    {
        public List<TollFeeTimePoint>? TollFeeTimePoints { get; set; }
    }

    public class TollFeeTimePoint
    {
        public int FeeAmount { get; set; }
        public List<string>? TimePoints { get; set; }
    }
}

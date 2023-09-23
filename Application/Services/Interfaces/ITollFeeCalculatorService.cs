using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Services.Interfaces
{
    internal interface ITollFeeCalculatorService
    {
        int CalculateTotalFeeDay(TollVehicle tollVehicle);
    }
}

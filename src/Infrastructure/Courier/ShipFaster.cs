using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Domain.DTOs;
using Application.Contracts.Infrastructure.Courier;
using Domain.LogisticsDetails.Dimensions;

namespace Infrastructure.Courier
{
    public class ShipFaster : IShipFaster
    {
        public decimal ParcelGreaterThan10kgLessThanEqual30Kg(double weight)
        {
            decimal price = 0;
            if(weight > Convert.ToDouble(10) &&  weight <= Convert.ToDouble(15))
            {
                price = 16.50m;
            }

            if(weight > Convert.ToDouble(15) &&  weight <= Convert.ToDouble(25))
            {
                price = 36.50m;
            }

            if(weight > Convert.ToDouble(25) &&  weight < Convert.ToDouble(26))
            {
                price = 40m;
            }

            if(weight >= Convert.ToDouble(26))
            {
                var result = (decimal)(weight - Convert.ToDouble(26)) * 0.417m;
                price = result + 40m;
            }

            return price;
        }

        public decimal ParcelLessThanEqual1700Cm(Dimension calculatedDimension)
        {
            decimal price = 0;

            if(calculatedDimension.CalculatedDimension <= Convert.ToDouble(1000))
            {
                price = 11.99m;
            }

            if(calculatedDimension.CalculatedDimension > Convert.ToDouble(1000) &&  calculatedDimension.CalculatedDimension <= Convert.ToDouble(1700))
            {
                price = 21.99m;
            }
            return price;
        }
    }
}
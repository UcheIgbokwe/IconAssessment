using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Domain.DTOs;
using Application.Contracts.Infrastructure.Courier;
using Domain.LogisticsDetails.Dimensions;

namespace Infrastructure.Courier
{
    public class MaltaShip : IMaltaShip
    {
        public decimal ParcelGreaterThanEqual10kg(double weight)
        {
            decimal price = 0;
            if(weight > Convert.ToDouble(10) && weight <= Convert.ToDouble(20))
            {
                price = 16.99m;
            }

            if(weight > Convert.ToDouble(20) &&  weight <= Convert.ToDouble(30))
            {
                price = 33.99m;
            }

            if(weight > Convert.ToDouble(30) &&  weight < Convert.ToDouble(31))
            {
                price = 43.99m;
            }

            if(weight >= Convert.ToDouble(31))
            {
                var result = (decimal)(weight - Convert.ToDouble(31)) * 0.41m;
                price = result + 43.99m;
            }

            return price;
        }

        public decimal ParcelGreaterThanEqual5000Cm(Dimension calculatedDimension)
        {
            decimal price = 0;

            if(calculatedDimension.CalculatedDimension <= Convert.ToDouble(1000))
            {
                price = 9.50m;
            }

            if(calculatedDimension.CalculatedDimension > Convert.ToDouble(1000) &&  calculatedDimension.CalculatedDimension <= Convert.ToDouble(2000))
            {
                price = 19.50m;
            }

            if(calculatedDimension.CalculatedDimension > Convert.ToDouble(2000) &&  calculatedDimension.CalculatedDimension <= Convert.ToDouble(5000))
            {
                price = 48.50m;
            }

            if(calculatedDimension.CalculatedDimension > Convert.ToDouble(5000))
            {
                price = 147.50m;
            }
            return price;
        }
    }
}
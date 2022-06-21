using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Domain.DTOs;
using Application.Contracts.Infrastructure.Courier;
using Domain.LogisticsDetails.Dimensions;

namespace Infrastructure.Courier
{
    public class Cargo4You : ICargo4You
    {
        public decimal ParcelLessThanEqual2000Cm(Dimension calculatedDimension)
        {
            decimal price = 0;

            if(calculatedDimension.CalculatedDimension <= Convert.ToDouble(1000))
            {
                price = 10m;
            }

            if(calculatedDimension.CalculatedDimension > Convert.ToDouble(1000) &&  calculatedDimension.CalculatedDimension <= Convert.ToDouble(2000))
            {
                price = 20m;
            }
            return price;
        }

        public decimal ParcelLessThanEqual20Kg(double weight)
        {
            decimal price = 0;
            if(weight <= Convert.ToDouble(2))
            {
                price = 15m;
            }

            if(weight > Convert.ToDouble(2) &&  weight <= Convert.ToDouble(15))
            {
                price = 18m;
            }

            if(weight > Convert.ToDouble(15) &&  weight <= Convert.ToDouble(20))
            {
                price = 35m;
            }

            return price;
        }
    }
}
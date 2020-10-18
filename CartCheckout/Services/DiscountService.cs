using Microsoft.AspNetCore.Mvc.ViewFeatures;
using PriceCalculator.Interfaces;
using PriceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PriceCalculator.Service
{
    public class DiscountService : IDiscountService
    {
            
        public int CalculateDiscount(List<CartItem> TotalItem)
        {
            throw new NotImplementedException();
        }
       
    }
}

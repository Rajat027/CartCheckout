using PriceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculator.Interfaces
{
    public interface IDiscountService
    {
        public int CalculateDiscount(List<CartItem> TotalItem);
    }
}

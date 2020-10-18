using CartCheckout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartCheckout.Interfaces
{
    public interface IDiscountService
    {
        public int CalculateDiscount(List<CartItem> TotalItem);
    }
}

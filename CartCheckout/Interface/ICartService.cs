using CartCheckout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartCheckout.Interfaces
{
    public interface ICartService
    {
        public int GetProductTotal(List<CartItem> items);
    }
}

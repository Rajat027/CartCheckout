using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculator.Interfaces
{
    public interface IProductService
    {
        public int GetProductPrice(string SKU);

    }
}

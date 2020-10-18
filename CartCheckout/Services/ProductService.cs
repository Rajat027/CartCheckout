using CartCheckout.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartCheckout.Service
{
    public class ProductService : IProductService
    {

        public int GetProductPrice(string SKU)
        {
            switch (SKU)
            {
                case "A":
                    return 50;

                case "B":
                    return 30;

                case "C":
                    return 20;

                case "D":
                    return 15;
            }
            return -1;
        }
    }
}

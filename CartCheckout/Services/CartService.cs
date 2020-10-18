using CartCheckout.Interfaces;
using CartCheckout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace CartCheckout.Service
{
    public class CartService : ICartService
    {
        private readonly IProductService _productService;
        private readonly IDiscountService _discountService;

        public CartService(IProductService productService, IDiscountService discountService)
        {
            _productService = productService;
            _discountService = discountService;
        }

        public int GetProductTotal(List<CartItem> items)
        {
            int totalDiscount = 0;
            int productTotal = 0;
            int productprice = 0;

           
            totalDiscount = _discountService.CalculateDiscount(items);


            foreach (CartItem item in items)
            {
                productprice = _productService.GetProductPrice(item.SKU);
                productTotal = productTotal + (item.count * productprice);
            }

            return productTotal - totalDiscount;
        }
    }
}

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
    public class SingleDiscountService : IDiscountService
    {
        private readonly IPromotionService _promotionService;
        private readonly IProductService _productService;

        public SingleDiscountService(IPromotionService promotionService, IProductService productService)
        {
            _promotionService = promotionService;
            _productService = productService;
        }
        public int CalculateDiscount(List<CartItem> TotalItem)
        {
            int discount = 0;
            int totalDiscount = 0;
            List<SingleProductPromotion> singlepromotions = _promotionService.GetSingleProductPromotions();

            foreach(CartItem item in TotalItem)
            {
                foreach (SingleProductPromotion promotion in singlepromotions)
                {
                    if (promotion.SKU == item.SKU)
                    {
                        discount = (item.count / promotion.Quantity) * (_productService.GetProductPrice(item.SKU) * promotion.Quantity - promotion.PromotionPrice);
                    }
                }
                totalDiscount = totalDiscount + discount;
            }

            return discount;
        }
       
    }
}

using Microsoft.AspNetCore.Mvc.ViewFeatures;
using CartCheckout.Interfaces;
using CartCheckout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CartCheckout.Service
{
    public class DiscountService : IDiscountService
    {
        private readonly IPromotionService _promotionService;
        private readonly IProductService _productService;

        public DiscountService(IPromotionService promotionService, IProductService productService)
        {
            _promotionService = promotionService;
            _productService = productService;
        }
        public int CalculateDiscount(List<CartItem> TotalItem)
        {
            int SingleProductDiscount = 0;
            int MultiProductDiscount = 0;
            foreach (CartItem item in TotalItem)
            {
                SingleProductDiscount = SingleProductDiscount + CalculateSingleProductDiscount(item);
            }

            MultiProductDiscount = CalculateMultiProductDiscount(TotalItem);

            return SingleProductDiscount + MultiProductDiscount;
        }

        private int CalculateMultiProductDiscount(List<CartItem> items)
        {
            int discount = 0;
            int productCount1 = 0;
            int productCount2 = 0;
            List<MultiProductPromotion> multiProductPromotion = _promotionService.GetMultiProductPromotions();

            foreach (MultiProductPromotion promotion in multiProductPromotion)
            {
                foreach (CartItem item in items)
                {
                    if (promotion.SKU[0] == item.SKU)
                    {
                        productCount1 = item.count;
                    }
                    if (promotion.SKU[1] == item.SKU)
                    {
                        productCount2 = item.count;
                    }

                }
                discount = discount + Math.Min(productCount1, productCount2) * 5;
            }
            return discount;
        }

        private int CalculateSingleProductDiscount(CartItem item)
        {
            int discount = 0;
            List<SingleProductPromotion> singlepromotions = _promotionService.GetSingleProductPromotions();

            foreach (SingleProductPromotion promotion in singlepromotions)
            {
                if (promotion.SKU == item.SKU)
                {
                    discount = (item.count / promotion.Quantity) * (_productService.GetProductPrice(item.SKU) * promotion.Quantity - promotion.PromotionPrice);
                    return discount;
                }
            }
            return discount;
        }

    }
}

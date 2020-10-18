using PriceCalculator.Interfaces;
using PriceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartCheckout.Services
{
    public class MultiProductDiscountServices : IDiscountService
    {
        private readonly IPromotionService _promotionService;
        private readonly IProductService _productService;

        public MultiProductDiscountServices(IPromotionService promotionService, IProductService productService)
        {
            _promotionService = promotionService;
            _productService = productService;
        }

        public int CalculateDiscount(List<CartItem> TotalItem)
        {
            int discount = 0;
            int productCount1 = 0;
            int productCount2 = 0;
            int product1Price = 0;
            int product2Price = 0;

            List<MultiProductPromotion> multiProductPromotion = _promotionService.GetMultiProductPromotions();

            foreach (MultiProductPromotion promotion in multiProductPromotion)
            {
                product1Price = _productService.GetProductPrice(promotion.SKU[0]);
                product2Price = _productService.GetProductPrice(promotion.SKU[1]);
                foreach (CartItem item in TotalItem)
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
                discount = discount + Math.Min(productCount1, productCount2) * ((product1Price + product2Price)*promotion.Quantity - promotion.PromotionPrice);
            }
            return discount;
        }
    }
}

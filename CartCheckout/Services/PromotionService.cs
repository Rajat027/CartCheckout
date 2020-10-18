using CartCheckout.Interfaces;
using CartCheckout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartCheckout.Service
{
    public class PromotionsService : IPromotionService
    {
        public List<SingleProductPromotion> GetSingleProductPromotions()
        {
            return new List<SingleProductPromotion>
            {
                new SingleProductPromotion{ PromotionId=1, Quantity=3, SKU="A", PromotionPrice=130 },
                new SingleProductPromotion{ PromotionId=2, Quantity=2, SKU="B", PromotionPrice=45 }
            };
        }

        public List<MultiProductPromotion> GetMultiProductPromotions()
        {
            return new List<MultiProductPromotion>
            {
                new MultiProductPromotion{ PromotionId=1, Quantity=1, SKU=new List<string>{"C","D"}, PromotionPrice=30 }
            };
        }
    }
}

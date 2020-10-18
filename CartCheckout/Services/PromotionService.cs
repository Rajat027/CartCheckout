using PriceCalculator.Interfaces;
using PriceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculator.Service
{
    public class PromotionsService : IPromotionService
    {
        public List<SingleProductPromotion> GetSingleProductPromotions()
        {
            throw new NotImplementedException();
        }

        public List<MultiProductPromotion> GetMultiProductPromotions()
        {
            throw new NotImplementedException();
        }
    }
}

using PriceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculator.Interfaces
{
    public interface IPromotionService
    {
        public List<SingleProductPromotion> GetSingleProductPromotions();
        public List<MultiProductPromotion> GetMultiProductPromotions();

    }
}

using CartCheckout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartCheckout.Interfaces
{
    public interface IPromotionService
    {
        public List<SingleProductPromotion> GetSingleProductPromotions();
        public List<MultiProductPromotion> GetMultiProductPromotions();

    }
}

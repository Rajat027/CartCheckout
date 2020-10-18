using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculator.Models
{
    public class SingleProductPromotion
    {
        public int PromotionId { get; set; }
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public int PromotionPrice {get;set;}
    }
}

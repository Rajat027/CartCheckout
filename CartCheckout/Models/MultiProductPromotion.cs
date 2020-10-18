using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace CartCheckout.Models
{
    public class MultiProductPromotion
    {
        public int PromotionId { get; set; }
        public List<string> SKU { get; set; }
        public int Quantity { get; set; }
        public int PromotionPrice {get;set;}
    }
}

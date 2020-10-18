using Microsoft.VisualStudio.TestTools.UnitTesting;
using CartCheckout.Models;
using CartCheckout.Service;
using System.Collections.Generic;

namespace CartCheckout.Tests
{
    [TestClass]
    public class PromotionServiceTest
    {
        [TestMethod]
        public void PromotionService_GetSingleProductPromotions_ShouldReturnAllSingleProductPromotion()
        {
            var testData = new List<SingleProductPromotion>
            {
                new SingleProductPromotion{ PromotionId=1, Quantity=3, SKU="A", PromotionPrice=130 },
                new SingleProductPromotion{ PromotionId=2, Quantity=2, SKU="B", PromotionPrice=45 }
            };
            var productService = new PromotionsService();
            var result = productService.GetSingleProductPromotions();

            Assert.AreEqual(testData[0].PromotionPrice, result[0].PromotionPrice);
            Assert.AreEqual(testData[1].PromotionPrice, result[1].PromotionPrice);
        }

        [TestMethod]
        public void PromotionService_GetMultiProductPromotions_ShouldReturnAllMultiProductPromotion()
        {
            var testData = new List<MultiProductPromotion>
            {
               new MultiProductPromotion{ PromotionId=1, Quantity=3, SKU=new List<string>{"C","D"}, PromotionPrice=30 }
            };
            var productService = new PromotionsService();
            var result = productService.GetMultiProductPromotions();

            Assert.AreEqual(result[0].PromotionPrice, testData[0].PromotionPrice);
        }
    }
}

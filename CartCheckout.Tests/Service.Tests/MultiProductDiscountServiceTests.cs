using CartCheckout.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PriceCalculator.Interfaces;
using PriceCalculator.Models;
using PriceCalculator.Service;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CartCheckout.Tests
{
    [TestClass]
    public class MultiProductDiscountServiceTests
    {
        private Mock<IPromotionService> mockPromotionService;
        private Mock<IProductService> mockProductService;


        [TestInitialize]
        public void Init()
        {
            mockPromotionService = new Mock<IPromotionService>();
            mockProductService = new Mock<IProductService>();

        }

        [TestMethod]
        public void MultiProductDiscountService_CalculateDiscount_ShouldReturnTotalDiscountForProductCAndD()
        {
            var testInput = new List<CartItem>
            {
                new CartItem {SKU = "C" , count = 5},
                new CartItem  {SKU = "D", count = 4}
            };

            var promotionList = new List<MultiProductPromotion>
            {
                new MultiProductPromotion{ PromotionId=1, Quantity=1, SKU=new List<string>{"C","D"}, PromotionPrice=30 },
            };
            mockProductService.Setup(s => s.GetProductPrice("C")).Returns(20);
            mockProductService.Setup(s => s.GetProductPrice("D")).Returns(15);
            mockPromotionService.Setup(m => m.GetMultiProductPromotions()).Returns(promotionList);

            var productService = new MultiProductDiscountServices(mockPromotionService.Object, mockProductService.Object);
            var result = productService.CalculateDiscount(testInput);

            Assert.AreEqual(20, result);


        }



        [TestMethod]
        public void SingleDiscountService_CalculateDiscount_ShouldZeroDiscountForNoActivePromotions()
        {
            var testInput = new List<CartItem>
            {
                new CartItem {SKU = "C" , count = 5},
                new CartItem  {SKU = "D", count = 4}
            };

            var promotionList = new List<MultiProductPromotion>();

            mockProductService.Setup(s => s.GetProductPrice(It.IsAny<string>())).Returns(30);
            mockPromotionService.Setup(m => m.GetMultiProductPromotions()).Returns(promotionList);

            var productService = new MultiProductDiscountServices(mockPromotionService.Object, mockProductService.Object);
            var result = productService.CalculateDiscount(testInput);

            Assert.AreEqual(0, result);

        }
    }
}

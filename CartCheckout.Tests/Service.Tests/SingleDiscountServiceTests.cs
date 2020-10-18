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
    public class SingleDiscountServiceTests
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
        public void SingleDiscountService_CalculateDiscount_ShouldReturnTotalDiscountForProductA()
        {
            var testInput = new List<CartItem>
            {
                new CartItem {SKU = "A" , count = 5},
                new CartItem  {SKU = "B", count = 4}
            };

            var promotionList = new List<SingleProductPromotion>
            {
                new SingleProductPromotion{ PromotionId=1, Quantity=3, SKU="A", PromotionPrice=130 },
            };
            mockProductService.Setup(s => s.GetProductPrice(It.IsAny<string>())).Returns(50);
            mockPromotionService.Setup(m => m.GetSingleProductPromotions()).Returns(promotionList);

            var productService = new SingleDiscountService(mockPromotionService.Object, mockProductService.Object);
            var result = productService.CalculateDiscount(testInput);

            Assert.AreEqual(20, result);


        }

        [TestMethod]
        public void SingleDiscountService_CalculateDiscount_ShouldReturnTotalDiscountForProductB()
        {
            var testInput = new List<CartItem>
            {
                new CartItem {SKU = "A" , count = 5},
                new CartItem  {SKU = "B", count = 4}
            };

            var promotionList = new List<SingleProductPromotion>
            {
                new SingleProductPromotion{ PromotionId=2, Quantity=2, SKU="B", PromotionPrice=45 },
            };
            mockProductService.Setup(s => s.GetProductPrice(It.IsAny<string>())).Returns(30);
            mockPromotionService.Setup(m => m.GetSingleProductPromotions()).Returns(promotionList);

            var productService = new SingleDiscountService(mockPromotionService.Object, mockProductService.Object);
            var result = productService.CalculateDiscount(testInput);

            Assert.AreEqual(30, result);

        }

        [TestMethod]
        public void SingleDiscountService_CalculateDiscount_ShouldZeroDiscountForNoActivePromotions()
        {
            var testInput = new List<CartItem>
            {
                new CartItem {SKU = "A" , count = 5},
                new CartItem  {SKU = "B", count = 4}
            };

            var promotionList = new List<SingleProductPromotion>();

            mockProductService.Setup(s => s.GetProductPrice(It.IsAny<string>())).Returns(30);
            mockPromotionService.Setup(m => m.GetSingleProductPromotions()).Returns(promotionList);

            var productService = new SingleDiscountService(mockPromotionService.Object, mockProductService.Object);
            var result = productService.CalculateDiscount(testInput);

            Assert.AreEqual(0, result);

        }
    }
}

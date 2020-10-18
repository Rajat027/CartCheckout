using CartCheckout.Interfaces;
using CartCheckout.Models;
using CartCheckout.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace CartCheckout.Tests
{
    [TestClass]
    public class CartServiceTests
    {
        [TestClass]
        public class DiscountServiceTests
        {
            private Mock<IDiscountService> mockDiscountService;
            private Mock<IProductService> mockProductService;


            [TestInitialize]
            public void Init()
            {
                mockDiscountService = new Mock<IDiscountService>();
                mockProductService = new Mock<IProductService>();

            }


            [TestMethod]
            public void CartService_GetProductTotal_ShouldReturnCorrectValueAfterDiscount_WhenDiscountIsApplicable()
            {
                var input = new List<CartItem> 
                {
                 new CartItem {SKU = "A" , count = 5},
                 new CartItem  {SKU ="B", count = 5},
                 new CartItem {SKU = "C" , count = 1}
                };

                int productTotal = 370;

                mockDiscountService.Setup(s => s.CalculateDiscount(It.IsAny<List<CartItem>>())).Returns(50);

                mockProductService.Setup(s => s.GetProductPrice("A")).Returns(50);
                mockProductService.Setup(s => s.GetProductPrice("B")).Returns(30);
                mockProductService.Setup(s => s.GetProductPrice("C")).Returns(20);
                mockProductService.Setup(s => s.GetProductPrice("D")).Returns(15);

                var cartService = new CartService(mockProductService.Object, mockDiscountService.Object);
                int result = cartService.GetProductTotal(input);

                Assert.AreEqual(productTotal, result);

            }

            [TestMethod]
            public void CartService_GetProductTotal_ShouldReturnCorrectValueAfterDiscount_WhenPromotionIsNotApplicable ()
            {
                var input = new List<CartItem>
                {
                 new CartItem {SKU = "A" , count = 1},
                 new CartItem  {SKU ="B", count = 1},
                 new CartItem {SKU = "C" , count = 1}
                };

                int productTotal = 100;

                mockDiscountService.Setup(s => s.CalculateDiscount(It.IsAny<List<CartItem>>())).Returns(0);

                mockProductService.Setup(s => s.GetProductPrice("A")).Returns(50);
                mockProductService.Setup(s => s.GetProductPrice("B")).Returns(30);
                mockProductService.Setup(s => s.GetProductPrice("C")).Returns(20);
                mockProductService.Setup(s => s.GetProductPrice("D")).Returns(15);

                var cartService = new CartService(mockProductService.Object, mockDiscountService.Object);
                int result = cartService.GetProductTotal(input);

                Assert.AreEqual(productTotal, result);

            }
        }
    }
}

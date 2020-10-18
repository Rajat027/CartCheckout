using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriceCalculator.Service;

namespace CartCheckout.Tests
{
    [TestClass]
    public class ProductServiceTest
    {
        [TestMethod]
        public void ProductService_GetProductPrice_ShouldReturnPriceForProductA()
        {
            var productService = new ProductService();
            int result = productService.GetProductPrice("A");

            Assert.AreEqual(result, 50); ;
        }

        [TestMethod]
        public void ProductService_GetProductPrice_ShouldReturnPriceForProductB()
        {
            var productService = new ProductService();
            int result = productService.GetProductPrice("B");

            Assert.AreEqual(result, 30); ;
        }

        [TestMethod]
        public void ProductService_GetProductPrice_ShouldReturnPriceForProductC()
        {
            var productService = new ProductService();
            int result = productService.GetProductPrice("C");

            Assert.AreEqual(result, 20); ;
        }

        [TestMethod]
        public void ProductService_GetProductPrice_ShouldReturnPriceForProductD()
        {
            var productService = new ProductService();
            int result = productService.GetProductPrice("D");

            Assert.AreEqual(result, 15); ;
        }
    }
}

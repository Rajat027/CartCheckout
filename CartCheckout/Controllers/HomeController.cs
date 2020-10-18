using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CartCheckout.Models;
using CartCheckout.Interfaces;

namespace CartCheckout.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICartService _cartService;

        public HomeController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int ProductA, int ProductB, int ProductC, int ProductD)
        {
            List<CartItem> items = new List<CartItem>
            {
                new CartItem {SKU = "A", count = ProductA},
                new CartItem {SKU = "B", count = ProductB},
                new CartItem {SKU = "C", count = ProductC},
                new CartItem {SKU = "D", count = ProductD},
            };
            ViewBag.TotalCost = "Total Cost: " + _cartService.GetProductTotal(items);
            return View();
        }
    }
}

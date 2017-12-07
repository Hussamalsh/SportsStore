using Microsoft.AspNetCore.Mvc;
using SportsStore.Data;
using SportStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private Cart cart;

        public OrderController(IOrderRepository repoService, Cart cartService)
        {
            repository = repoService;
            cart = cartService;
        }

        public ViewResult Checkout() => View(new Order());


        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

        if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();

                SportStore.Data.Models.Order o1 = new SportStore.Data.Models.Order()
                {
                    City = order.City,
                    Country = order.Country,
                    GiftWrap = order.GiftWrap,
                    Line1 = order.Line1,
                    Line2 = order.Line2,
                    Line3 = order.Line3,
                    Name=order.Name,
                    OrderID=order.OrderID,
                    State=order.State,
                    Zip=order.Zip
                };
                
                repository.SaveOrder(o1);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }


        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
    }

}

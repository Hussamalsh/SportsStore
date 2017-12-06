﻿using Microsoft.AspNetCore.Mvc;
using SportsStore.Data.Models;
using SportStore.Infrastructure;
using SportStore.Models;
using SportStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        public CartController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
           var product = repository.Products.Select(p => new Models.Product
            {
                ProductID = p.ProductID,
                Category = p.Category,
                Description = p.Description,
                Name = p.Name,
                Price = p.Price
            }).FirstOrDefault(p => p.ProductID == productId);


            if (product != null)
            {
                Cart cart = GetCart();
                cart.AddItem(product, 1);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromCart(int productId,string returnUrl)
        {
            var product = repository.Products.Select(p => new Models.Product
            {
                ProductID = p.ProductID,
                Category = p.Category,
                Description = p.Description,
                Name = p.Name,
                Price = p.Price
            }).FirstOrDefault(p => p.ProductID == productId);



            if (product != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(product);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }
        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }
    }
}
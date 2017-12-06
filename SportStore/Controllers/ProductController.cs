using Microsoft.AspNetCore.Mvc;
using SportsStore.Data.Models;
using SportStore.Models;
using SportStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int page = 1)        {
            var allproduct = repository.Products;

            var productModel = allproduct.Select(p => new Models.Product
            {
                ProductID = p.ProductID,
                Category = p.Category,
                Description = p.Description,
                Name = p.Name,
                Price = p.Price
            }).ToList();

            var model = new ProductIndexModel()
            {
                Products = productModel.Where(p => category == null || p.Category == category)                                        .OrderBy(p => p.ProductID)
                                       .Skip((page - 1) * PageSize)
                                       .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    repository.Products.Count() :
                    repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };

           return View(model);
        }

    }
}

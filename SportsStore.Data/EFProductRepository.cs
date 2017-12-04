using SportsStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsStore.Data
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext context;
        public EFProductRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Product> Products => context.Products;
    }
}

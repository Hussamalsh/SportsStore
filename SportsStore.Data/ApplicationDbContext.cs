using Microsoft.EntityFrameworkCore;
using SportsStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}

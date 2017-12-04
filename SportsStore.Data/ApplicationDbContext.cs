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
       /* public ApplicationDbContext(DbContextOptions options) : base(options) // take the options and pass to the base class constructor (DbContext)
        {
            // where will you use this class? Could inject directly into controllers, but
            // we already have an abstraction injected into controllers - the interfaces.
            // we should create an interface that can talk to the databse.
        }*/
        public DbSet<Product> Products { get; set; }
    }
}

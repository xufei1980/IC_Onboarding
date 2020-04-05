using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class ICOnBoardingContext: DbContext
    {
        public ICOnBoardingContext()
        {
        }

        public ICOnBoardingContext(DbContextOptions<ICOnBoardingContext> options)
            : base(options)
         {
         }
       

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Store> Store { get; set; }

        public DbSet<Sales> Sales { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using ProductMasterDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMasterDetails.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
           : base(options) { }

        public virtual DbSet<Product> Products { get; set; }
    }
    
}

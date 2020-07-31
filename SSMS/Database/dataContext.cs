using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SSMS.Areas.Admin.Models;
using SSMS.Areas.Customer.Models;
using SSMS.Areas.Manager.Models;
using SSMS.Areas.StockManager.Models;
using SSMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSMS.Database
{
    public class dataContext : IdentityDbContext
    {
        public dataContext(DbContextOptions<dataContext> options)
            : base(options)
        {
        }
        public DbSet<ProductCatagory> ProductCatagory { get; set; }
        public DbSet<EmployeeInfo> EmployeeInfo { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<Designation> Designation { get; set; }
        public DbSet<SalesDetails> SalesDetails { get; set; }
        public DbSet<SalesList> SalesList { get; set; }
        public DbSet<StockDetails> StockDetails { get; set; }
        public DbSet<QuantityInfo> QuantityInfo { get; set; }
        public DbSet<OfflineCustomerInfo> OfflineCustomerInfo { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<QuantityInfo>().HasData(new QuantityInfo
            {
                QuantityId = 1,
                QuantityType="Piece"
            });
            builder.Entity<QuantityInfo>().HasData(new QuantityInfo
            {
                QuantityId = 2,
                QuantityType = "Weight"
            });
            builder.Entity<QuantityInfo>().HasData(new QuantityInfo
            {
                QuantityId = 3,
                QuantityType = "Pair"
            });
        }
    }
}

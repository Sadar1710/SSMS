using SSMS.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSMS.Areas.StockManager.Models
{
    public class StockDetails
    {
        [Key]
        public int StockDetailsId { get; set; }
        public int ProductId { get; set; }
        public ProductDetails ProductDetails { get; set; }
        public int ProductCatagoryId { get; set; }
        public ProductCatagory ProductCatagory { get; set; }
        public int Quantity { get; set; }
        public DateTime StockInDate { get; set; }
        public int PurchasedPrice { get; set; }
        public double AvailableStock { get; set; }
    }
}

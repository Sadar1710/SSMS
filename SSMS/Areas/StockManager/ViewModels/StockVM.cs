using SSMS.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSMS.Areas.StockManager.ViewModels
{
    public class StockVM
    {
        public int Serial { get; set; }
        public int ProductId { get; set; }        
        public string ProductName { get; set; }
        public int ProductCatagoryId { get; set; }
        public string CatagoryName { get; set; }
        public int Quantity { get; set; }
        public DateTime StockInDate { get; set; }
        public int PurchasedPrice { get; set; }
        public double AvailableStock { get; set; }
    }
}

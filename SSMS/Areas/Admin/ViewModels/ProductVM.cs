using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSMS.Areas.Admin.ViewModels
{
    public class ProductVM
    {
        public int Serial { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductCatagoryId { get; set; }
        public string ProductCatagoryName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public IFormFile Photopath { get; set; }
        public string Photo { get; set; }
        public int QuantityId { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSMS.Areas.Admin.Models
{
    public class ProductDetails
    {
        [Key]
        public int ProductId { get; set; }
        public int ProductCatagoryId { get; set; }
        public ProductCatagory ProductCatagory { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Photopath { get; set; }
        public int QuantityId { get; set; }
    }
}

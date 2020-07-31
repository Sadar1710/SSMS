using SSMS.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSMS.Areas.Manager.Models
{
    public class SalesDetails
    {
        [Key]
        public int SalesDetailsId { get; set; }
        public int InvoiceId { get; set; }
        public SalesList SalesList { get; set; }
        public int ProductCatagoryId { get; set; }
        public int ProductId { get; set; }
        public ProductDetails ProductDetails { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}

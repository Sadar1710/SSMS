using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSMS.Areas.Admin.Models
{
    public class ProductCatagory
    {
        [Key]
        public int ProductCatagoryId { get; set; }
        public string ProductCatagoryName { get; set; }
    }
}

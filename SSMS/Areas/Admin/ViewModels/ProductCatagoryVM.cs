using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSMS.Areas.Admin.ViewModels
{
    public class ProductCatagoryVM
    {
        public int Serial { get; set; }
        public int ProductCatagoryId { get; set; }
        [Required]
        public string ProductCatagoryName { get; set; }
    }
}

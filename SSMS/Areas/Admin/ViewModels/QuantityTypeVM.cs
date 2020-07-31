using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSMS.Areas.Admin.ViewModels
{
    public class QuantityTypeVM
    {
        public int Serial { get; set; }
        public int QuantityId { get; set; }
        [Required]
        public string QuantityType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSMS.Areas.Admin.Models
{
    public class QuantityInfo
    {
        [Key]
        public int QuantityId { get; set; }
        public string QuantityType { get; set; }
    }
}

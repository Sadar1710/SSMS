using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSMS.Areas.Customer.Models
{
    public class OfflineCustomerInfo
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int MobileNumber { get; set; }
    }
}

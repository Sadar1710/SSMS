using SSMS.Areas.Admin.Models;
using SSMS.Areas.Customer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSMS.Areas.Manager.Models
{
    public class SalesList
    {
        [Key]
        public int InvoiceId { get; set; }
        public DateTime SalesDate { get; set; }
        public DateTime SalesTime { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeInfo EmployeeInfo { get; set; }
        public int CustomerId { get; set; }
        public OfflineCustomerInfo OfflineCustomerInfo { get; set; }
    }
}

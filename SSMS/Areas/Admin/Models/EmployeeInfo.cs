using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSMS.Areas.Admin.Models
{
    public class EmployeeInfo
    {
        [Key]
        public int EmployeeId { get; set; }
        public int DesignationId { get; set; }
        public Designation Designetion { get; set; }
        public string EmployeeName { get; set; }
        public DateTime JoinDate { get; set; }       
        public int Cell { get; set; }
        public string Email { get; set; }
        public string PhotoPath { get; set; }
    }
}

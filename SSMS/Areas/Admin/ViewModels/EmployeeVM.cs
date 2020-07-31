using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSMS.Areas.Admin.ViewModels
{
    public class EmployeeVM
    {
        public int Serial { get; set; }
        public int EmployeeId { get; set; }
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public DateTime JoinDate { get; set; }
        [Required]
        public int Cell { get; set; }
        [Required]
        public string Email { get; set; }
        public IFormFile PhotoPath { get; set; }
        public string ExistingPhoto { get; set; }
    }
}

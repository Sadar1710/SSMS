using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSMS.Areas.Admin.ViewModels
{
    public class DesignationVM
    {
        public int Serial { get; set; }
        public int DesignationId { get; set; }
        [Required]
        public string DesignationName { get; set; }
    }
}


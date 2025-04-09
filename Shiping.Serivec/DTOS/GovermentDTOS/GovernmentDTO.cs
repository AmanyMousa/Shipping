using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Service.DTOS.GovermentDTOS
{
    public class GovernmentDTO
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Must Enter Goverment")]
        [StringLength(100, ErrorMessage = "Goverment must be less than or equal 100 character")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Must Enter Status")]
        public string Status { get; set; } = "Active"; 
    }
}

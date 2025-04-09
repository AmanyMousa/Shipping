using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Service.DTOS.WightPriceDTO
{
    public class WeightPriceDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Additional price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Additional price must be a positive number")]
        public decimal AdditionalPrice { get; set; }

        [Required(ErrorMessage = "Default weight is required")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Default weight must be greater than zero")]
        public decimal DefaultWeight { get; set; }

        [Required(ErrorMessage = "Default price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Default price must be a positive number")]
        public decimal DefaultPrice { get; set; }
    }
}

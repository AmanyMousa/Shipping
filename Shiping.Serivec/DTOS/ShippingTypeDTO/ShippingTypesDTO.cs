using Shipping.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Service.DTOS.ShippingTypeDTO
{
    public class ShippingTypesDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "type of shipping required")]
        public ShippingTypeOrder Type { get; set; }

        public decimal? Cost { get; set; }

        public int? numberofday { get; set; } = 0;

        public bool IsDeleted { get; set; }
    }
}

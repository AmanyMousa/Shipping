using Shipping.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Service.DTOS.ShippingTypeDTO
{
    public class UpdateShippingTypesDTO
    {
        public ShippingTypeOrder Type { get; set; }
        public decimal Cost { get; set; }

        public int numberofday { get; set; }
        public bool IsDeleted { get; set; }
    }
}

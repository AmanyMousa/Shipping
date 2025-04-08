using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipping.Data.Entities;

namespace Shipping.Service.DTOS.Delivery
{
    public class DeliveryReadDto
    {
        public string UserId { get; set; }
        public SaleTypeEnum SaleType { get; set; }
        public decimal SalePresentage { get; set; }
        public string EmpId { get; set; }
    }

}

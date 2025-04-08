using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipping.Data.Entities;

namespace Shipping.Service.DTOS.Order
{
    public class OrderFilterDto
    {
        public OrderType? OrderType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ClientName { get; set; }
        public string City { get; set; }
    }
}

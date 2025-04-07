using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Service.DTOS.RejectionOrder
{
    public class CreateRejectionOrderDto
    {
        public string Reason { get; set; }
        public int OrderId { get; set; }
    }
}

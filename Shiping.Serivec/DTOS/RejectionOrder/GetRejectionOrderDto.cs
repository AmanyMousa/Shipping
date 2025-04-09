using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Service.DTOS.RejectionOrder
{
    public class GetRejectionOrderDto
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public int OrderId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Service.DTOS.Marchant
{
    public class UpdateMarchantDto
    {
        public string Address { get; set; }
        public decimal Cost_Rejection { get; set; }
        public decimal Bickup { get; set; }
    }
}

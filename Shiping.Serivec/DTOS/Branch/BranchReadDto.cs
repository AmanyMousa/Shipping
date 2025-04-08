using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Service.DTOS.Branch
{
    public class BranchReadDto
    {
        public int Bid { get; set; }
        public string Status { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
    }

}

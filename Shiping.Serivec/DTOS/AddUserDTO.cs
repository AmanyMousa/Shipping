using Shipping.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Serivec.DTOS
{
    public class AddUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
       // public string ? Password { get; } = "Admin@123";
        public DateTime Data { get; set; }
        public string Status { get; set; }
        //public int ? RoleId { get; set; }
    }
}

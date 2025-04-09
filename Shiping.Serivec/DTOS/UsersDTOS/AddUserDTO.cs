using Shipping.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Service.DTOS.UsersDTOS
{
    public class AddUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
<<<<<<< HEAD:Shiping.Serivec/DTOS/AddUserDTO.cs
        // public string ? Password { get; } = "Admin@123";
=======
        public string Password { get; } = "Admin@123";
>>>>>>> a5dbc68d37e694ad3f447273559942ac2ebd434b:Shiping.Serivec/DTOS/UsersDTOS/AddUserDTO.cs
        public DateTime Data { get; set; }
        public string Status { get; set; }
        //public int ? RoleId { get; set; }
    }
}

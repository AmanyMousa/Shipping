using Shipping.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Serivec.Users.DTO
{
    public class UsersDTO
    {
        
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public UserType Type { get; set; }
        public int RoleId
        {
            get; set;
        }
    }
}

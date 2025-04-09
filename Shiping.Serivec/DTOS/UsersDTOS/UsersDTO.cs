using Shipping.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Service.DTOS.UsersDTOS
{
    public class UsersDTO
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }


    }
}

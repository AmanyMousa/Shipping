using Shipping.Data.Entities;
using Shipping.Serivec.Users.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Serivec.Users
{
    public interface IUsers
    {
        Task<bool> AddUser(UserpassDTO userDTO);
        Task<bool> UpdateUser(UsersDTO userDTO);
        Task<bool> DeleteUser(string id);
        Task<UsersDTO> GetUserById(string id);
        Task<List<UsersDTO>> GetAllUsers();
    }

}

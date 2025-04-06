using Shipping.Serivec.Users.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Serivec.Login
{
    public interface ILoginSerivec
    {
        //Task<UsersDTO> RegisterAsync(UserpassDTO request);
        Task<string> LoginAsync(LoginDTO  model);
    }
}

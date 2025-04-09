using Shipping.Serivec.Users;
using Shipping.Service.DTOS.LoginDTOS;
using Shipping.Service.DTOS.UsersDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Serivec.Login
{
    public interface IAccountService
    {
        Task<UsersDTO> LoginAsync(LoginDTO  model);
        Task<String> ForgetPassowrdAsync(string email);
        Task<string> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO);
    }
}

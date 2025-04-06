using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Serivec.EmailService
{
    public interface IEmailService
    {
        Task<string> SendEmailAsync(string Name, string Email, string Token);
    }
}

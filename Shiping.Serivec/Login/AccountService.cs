using Microsoft.Extensions.Configuration;
using Shipping.Data.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Shipping.Serivec.Login;
using Shipping.Serivec.Settings;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Extensions.Options;
using Shipping.Serivec.EmailService;
using Shipping.Service.DTOS.LoginDTOS;
using Shipping.Service.DTOS.UsersDTOS;

namespace Shipping.Services.Login
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly Jwt jwt;
        private readonly IEmailService emailService;
        public AccountService(UserManager<User> userManager, IOptions<Jwt> jwt, IEmailService emailService)
        {
            _userManager = userManager;
            this.jwt = jwt.Value;
            this.emailService = emailService;
        }

       

        public async Task<UsersDTO> LoginAsync(LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                throw new UnauthorizedAccessException("Invalid email or password");
            }
           var JwtToken = await CreateJWTToken(user);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(JwtToken);
            var userDTO = new UsersDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Date = user.Date,
                Status = "Active"
            };
            return userDTO;

        }


        public async Task<string> ForgetPassowrdAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid email");
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await emailService.SendEmailAsync(user.Name, user.Email, token);
            return result;
        }

        public async Task<string> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordDTO.Email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid email");
            }
            var result = await _userManager.ResetPasswordAsync(user, resetPasswordDTO.Token, resetPasswordDTO.Password);
            if (result.Succeeded)
            {
                return "success";
            }
            else
            {
                throw new UnauthorizedAccessException("Failed to reset password");
            }
        }
        private async Task<JwtSecurityToken> CreateJWTToken(User user)
        {
            // Retrieve user claims
            var UserClaims = await _userManager.GetClaimsAsync(user);

            // Retrieve user roles and create role claims
            var Roles = await _userManager.GetRolesAsync(user);
            var RoleClaims = new List<Claim>();

            foreach (var role in Roles)
                RoleClaims.Add(new Claim(ClaimTypes.Role, role));

            
            var claims = new List<Claim>()
     {
         new Claim(ClaimTypes.Name,user.UserName),
         new Claim(ClaimTypes.Email,user.Email),
         new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
     }
            .Union(UserClaims)
            .Union(RoleClaims);

            // Define the security key and signing credentials
            SecurityKey securityKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));

            SigningCredentials signingCredentials =
                new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Create the JWT token
            var JWTSecurityToken = new JwtSecurityToken(
                issuer: jwt.Issuer,
                audience: jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(jwt.durationindays),
                signingCredentials: signingCredentials);
            return JWTSecurityToken;
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Shipping.Serivec.Login;
using Shipping.Service.DTOS.LoginDTOS;
using Shipping.Service.DTOS.UsersDTOS;
using Shipping.Services.Login;

namespace Shipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _loginService;

        public AccountController(IAccountService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            try
            {
                var Result = await _loginService.LoginAsync(model);
                return Ok(Result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpPost("forgetpassword")]
        public async Task<IActionResult> ForgetPassword([FromBody] string email)
        {
            try
            {
                var result = await _loginService.ForgetPassowrdAsync(email);
                if (result == "success")
                {
                    return Ok(new { Message = "Email sent successfully" });
                }
              
                    return BadRequest(new { Message = result });
               
               
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO model)
        {
            try
            {
                var result = await _loginService.ResetPasswordAsync(model);
                if (result == "success")
                {
                    return Ok(new { Message = "Password reset successfully" });
                }
                return BadRequest(new { Message = result });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
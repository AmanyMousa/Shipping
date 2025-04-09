using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Serivec.Users;
using Shipping.Service.DTOS.UsersDTOS;

namespace Shipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsers _userService;
        public UsersController(IUsers users)
        {
            _userService = users;
        }
        [HttpPost("adduser")]

        public async Task<IActionResult> AddUser([FromBody] AddUserDTO userDTO)
        {
            try
            {
                var result = await _userService.AddUser(userDTO);
                if (result)
                {
                    return Ok(new { Message = "User added successfully" });
                }
                return BadRequest(new { Message = "Failed to add user" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpPut("updateuser")]
        public async Task<IActionResult> UpdateUser([FromBody] UsersDTO userDTO)
        {
            try
            {
                var result = await _userService.UpdateUser(userDTO);
                if (result)
                {
                    return Ok(new { Message = "User updated successfully" });
                }
                return BadRequest(new { Message = "Failed to update user" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpDelete("deleteuser/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                var result = await _userService.DeleteUser(id);
                if (result)
                {
                    return Ok(new { Message = "User deleted successfully" });
                }
                return BadRequest(new { Message = "Failed to delete user" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpGet("getuser/{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            try
            {
                var result = await _userService.GetUserById(id);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound(new { Message = "User not found" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpGet("getallusers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var result = await _userService.GetAllUsers();
                if (result != null && result.Count > 0)
                {
                    return Ok(result);
                }
                return NotFound(new { Message = "No users found" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

    }
}

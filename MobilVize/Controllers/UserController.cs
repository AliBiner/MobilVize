using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobilVize.Core.Dtos;
using MobilVize.Core.Entities;
using MobilVize.Core.Services;

namespace MobilVize.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Signup")]
        public async Task<IActionResult> Signup(SignupDto user) {
            if (user == null)
            {
                return Ok();
            }
            else { 
                _userService.Signup(user);
                return Ok();
            }
            
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto) {

            if (dto.Email == "" || dto.Password=="")
            {
                return BadRequest();
            }
            else { 
                var model = await _userService.Login(dto);
                return CreateActionResult(model);
            }
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateUser(UpdateUserDto dto)
        {

            var result = await _userService.UpdateUser(dto);
           return CreateActionResult(result);
            
        }
    }
}

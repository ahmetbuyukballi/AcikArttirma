using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGalaxy_Auction_Business.Abraction;
using MyGalaxy_Auction_Business.Dtos;

namespace MyGalaxy_Auction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        { 
            _userService = userService;

        }
        [HttpPost("Register")]
        public async Task<IActionResult> CreateUser([FromBody] RegisterRequestDtos models)
        {
            var response=await _userService.Register(models);
            if (response.IsSucces == true)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginRequestDtos models)
        {
            var response = await _userService.Login(models);
            if (response.IsSucces == true)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        
    }
}

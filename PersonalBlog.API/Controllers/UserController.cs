using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Application.DTOs;
using PersonalBlog.Application.Interfaces;

namespace PersonalBlog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(AuthRequestDto authRequestDto)
        {
            var token = await _userService.LoginAsyncs(authRequestDto);
            if (!token.Success) return Unauthorized(token.Message);
            return Ok(new { Token = token });
        }


        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterRequestDto registerRequestDto)
        {
            var result = await _userService.RegisterAsyncs(registerRequestDto);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(new { Token = result.Token });
        }
    }
}
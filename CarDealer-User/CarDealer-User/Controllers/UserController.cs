using CarDealer_User.Interfaces;
using CarDealer_User.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace CarDealer_User.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;

        public UserController(IUserRepository userRepository,
            ITokenRepository tokenRepository)
        {
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] User user)
        {
            var result = _userRepository.CreateUser(user);
            return Ok(result);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserCredential userCredential)
        {
            var user = _userRepository.GetUserByCredentials(userCredential);
            if (user is null) return Unauthorized();
            var authenticatedResponse = new AuthenticatedResponse
            {
                Token = _tokenRepository.CreateToken(user)
            };
            return Ok(authenticatedResponse);
        }

        [HttpGet]
        public IActionResult GetuserById()
        {
            var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
            var userid = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var user = _userRepository.GetUserById(Int32.Parse(userid.Value));
            if (user is null) return BadRequest("User does not exist!");
            return Ok(user);
        }

        [HttpGet("{userid}")]
        [Authorize(Roles = "1")]
        public IActionResult GetuserById(int userid)
        {

            var user = _userRepository.GetUserById(userid);
            if (user is null) return BadRequest("User does not exist!");
            return Ok(user);
        }
        [HttpDelete]
        [Authorize(Roles = "1")]
        public IActionResult DeleteUser(int id)
        {
            var result = _userRepository.DeleteUser(id);
            if (!result) return BadRequest("User cannot be found");
            return Ok();
        }
    }

}

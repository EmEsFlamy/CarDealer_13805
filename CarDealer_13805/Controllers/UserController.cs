using CarDealer_13805.Interfaces;
using CarDealer_13805.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer_13805.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserReporsitory _userRepository;

        public UserController(IUserReporsitory userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            _userRepository.CreateUser(user);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetUser([FromQuery] UserCredential userCredential)
        {
            var user = _userRepository.GetUserByCredentials(userCredential);
            if (user is null) return BadRequest("User does not exist!");
            return Ok(user);
        }

        [HttpGet("{id}")]
        public IActionResult GetuserById(int id)
        {
            var user = _userRepository.UserGetUserById(id);
            if (user is null) return BadRequest("User does not exist!");
            return Ok(user);
        }
    }
}

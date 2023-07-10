﻿using CarDealer_13805.Interfaces;
using CarDealer_13805.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CarDealer_13805.Controllers
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

        [HttpGet("{id}")]
        public IActionResult GetuserById(int id)
        {
            var user = _userRepository.GetUserById(id);
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

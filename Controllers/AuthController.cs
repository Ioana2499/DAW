﻿using Playlist_Manager.Helpers;
using Microsoft.AspNetCore.Mvc;
using Playlist_Manager.IServices;
using Playlist_Manager.Models;

namespace Playlist_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(AuthenticationRequest request)
        {
            return Ok(_userService.Register(request));
        }

        [HttpPost("login")]
        public IActionResult Login(AuthenticationRequest request)
        {
            return Ok(_userService.Login(request));
        }

        [HttpGet("isAuth")]
        [Authorize]
        public IActionResult IsAuth()
        {
            return Ok(true);
        }
    }
}

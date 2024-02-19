﻿using DomainRepository.Models;
using General.Response;
using Microsoft.AspNetCore.Mvc;
using UserManagementService.Requests.User;
using UserManagementService.Services.Interfaces;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;


        [HttpPost("register")]
        public async Task<Response<object>> Register(UserRegisterRequest request)
        {
            return await _userService.Register(request);
        }

        [HttpPost("login")]
        public async Task<Response<User>> Login(UserLoginRequest request)
        {
            return await _userService.Login(request);
        }
    }
}
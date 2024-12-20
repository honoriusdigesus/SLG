﻿using Application.DTOs;
using Application.Exceptions.Types;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IEmployeeService _employeeServices;

        public AuthController(IEmployeeService employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLogin userLogin)
        {
            return Ok(await _employeeServices.Login(userLogin.Document, userLogin.Password));
        }

        [HttpPost]
        [Route("Refresh")]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] string token)
        {
            return Ok(await _employeeServices.RefreshToken(token));
        }
    }
}

using Application.DTOs;
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
        public async Task<IActionResult> LoginAsync([FromBody] UserLogin user)
        {
            throw new NotImplementedException();
        }
    }
}

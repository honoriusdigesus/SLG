using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeServices;

        public EmployeeController(IEmployeeService employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync(EmployeeReq employee)
        {
            var createdEmployee = await _employeeServices.CreateAsync(employee);
            return Ok(createdEmployee);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var employees = await _employeeServices.GetAllAsync();
            return Ok(employees);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var employee = await _employeeServices.GetByIdAsync(id);
            return Ok(employee);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deletedEmployee = await _employeeServices.DeleteAsync(id);
            return Ok(deletedEmployee);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, EmployeeReq employee)
        {
            var updatedEmployee = await _employeeServices.UpdateAsync(id, employee);
            return Ok(updatedEmployee);
        }
    }
}

using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoneController : ControllerBase
    {
        private readonly IZoneServices _zoneServices;

        public ZoneController(IZoneServices zoneServices)
        {
            _zoneServices = zoneServices;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync(ZoneReq zone)
        {
            var createdZone = await _zoneServices.CreateAsync(zone);
            return Ok(createdZone);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var zones = await _zoneServices.GetAllAsync();
            return Ok(zones);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var zone = await _zoneServices.GetByIdAsync(id);
            return Ok(zone);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _zoneServices.DeleteAsync(id);
            return Ok(deleted);
        }
    }
}

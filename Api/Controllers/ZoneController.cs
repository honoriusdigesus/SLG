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
    }
}

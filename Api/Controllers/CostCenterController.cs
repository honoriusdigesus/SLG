using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostCenterController : ControllerBase
    {
        private readonly ICostCenterService _costCenterService;

        public CostCenterController(ICostCenterService costCenterService)
        {
            _costCenterService = costCenterService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] CostCenterReq costCenterReq)
        {
            var costCenter = await _costCenterService.CreateAsync(costCenterReq);
            return Ok(costCenter);
        }

        [HttpGet]
        [Route("GetAlls")]
        public async Task<IActionResult> GetAllAsync()
        {
            var costCenters = await _costCenterService.GetAllAsync();
            return Ok(costCenters);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var costCenter = await _costCenterService.GetByIdAsync(id);
            return Ok(costCenter);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var costCenter = await _costCenterService.DeleteAsync(id);
            return Ok(costCenter);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CostCenterReq costCenterReq)
        {
            var costCenter = await _costCenterService.UpdateAsync(id, costCenterReq);
            return Ok(costCenter);
        }
    }
}

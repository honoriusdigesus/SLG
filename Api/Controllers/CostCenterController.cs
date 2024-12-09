﻿using Application.DTOs;
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
    }
}

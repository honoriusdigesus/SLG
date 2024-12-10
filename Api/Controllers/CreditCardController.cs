﻿using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardService _creditCardService;

        public CreditCardController(ICreditCardService creditCardService)
        {
            this._creditCardService = creditCardService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync(CreditCardReq creditCard)
        {
            var createdCreditCard = await _creditCardService.CreateAsync(creditCard);
            return Ok(createdCreditCard);
        }
    }
}
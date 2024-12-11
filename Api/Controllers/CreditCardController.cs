using Application.DTOs;
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

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var creditCards = await _creditCardService.GetAllAsync();
            return Ok(creditCards);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var creditCard = await _creditCardService.GetByIdAsync(id);
            return Ok(creditCard);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deletedCreditCard = await _creditCardService.DeleteAsync(id);
            return Ok(deletedCreditCard);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, CreditCardReq creditCard)
        {
            var updatedCreditCard = await _creditCardService.UpdateAsync(id, creditCard);
            return Ok(updatedCreditCard);
        }

    }
}

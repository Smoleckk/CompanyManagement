using ApiProject.Data;
using ApiProject.Dtos;
using ApiProject.Models;
using ApiProject.Services.BuyerService;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]

    public class BuyerController : ControllerBase
    {
        private readonly IBuyerService _buyerService;

        public BuyerController(IBuyerService buyerService)
        {
            _buyerService = buyerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Buyer>>> GetBuyers()
        {
            var response = await _buyerService.GetBuyers();
            if (!response.Success)
            {
                return NotFound();
            }
            return Ok(response.Data);
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<Buyer>> GetBuyer(int id)
        {
            var response = await _buyerService.GetBuyer(id);
            if (!response.Success)
            {
                return NotFound();
            }
            return Ok(response.Data);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<Buyer>>> DeleteBuyer(int id)
        {
            var response = await _buyerService.DeleteBuyer(id);
            if (!response.Success)
            {
                return NotFound();
            }
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Buyer>>> PostBuyer(BuyerDto buyerDto)
        {
            var response = await _buyerService.PostBuyer(buyerDto);
            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Buyer>>> PutBuyer(Buyer buyer)
        {
            var response = await _buyerService.PutBuyer(buyer);
            if (!response.Success)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}

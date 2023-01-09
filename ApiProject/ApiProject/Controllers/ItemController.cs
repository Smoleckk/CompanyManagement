using ApiProject.Data;
using ApiProject.Dtos;
using ApiProject.Models;
using ApiProject.Services.ItemService;
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

    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Item>>> GetItems()
        {
            var response = await _itemService.GetItems();

            return Ok(response.Data);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var response = await _itemService.GetItem(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response.Data);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<Item>>> DeleteItem(int id)
        {
            var response = await _itemService.DeleteItem(id);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Item>>> PostItem(ItemDto itemDto)
        {
            var response = await _itemService.PostItem(itemDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Item>>> PutItem(Item item)
        {
            var response = await _itemService.PutItem(item);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}

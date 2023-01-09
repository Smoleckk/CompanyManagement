using ApiProject.Dtos;
using ApiProject.Models;
using ApiProject.Services.OrderService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {

            var response = await _orderService.GetOrders();
            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var response = await _orderService.GetOrder(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<Note>>> DeleteOrder(int id)
        {
            var response = await _orderService.DeleteOrder(id);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Order>>> PutOrder(Order order)
        {
            var response = await _orderService.PutOrder(order);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Order>>> PostOrder(OrderDto order)
        {
            var response = await _orderService.PostOrder(order);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}

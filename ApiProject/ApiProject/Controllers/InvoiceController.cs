using ApiProject.Data;
using ApiProject.Dtos;
using ApiProject.Models;
using ApiProject.Services.InvoiceService;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Invoice>>> GetInvoices()
        {
            var response = await _invoiceService.GetInvoices();
            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            var response = await _invoiceService.GetInvoice(id);
            if (!response.Success)
            {
                return NotFound();
            }
            return Ok(response.Data);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<Invoice>>> DeleteInvoice(int id)
        {
            var response = await _invoiceService.DeleteInvoice(id);
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Invoice>>> PostInvoice(InvoiceDto invoiceDto)
        {
            var response = await _invoiceService.PostInvoice(invoiceDto);
            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Invoice>>> PutInvoice(Invoice invoice)
        {
            var response = await _invoiceService.PutInvoice(invoice);
            return Ok(response);
        }
    }
}

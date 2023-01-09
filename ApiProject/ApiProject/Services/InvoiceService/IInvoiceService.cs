using ApiProject.Dtos;
using ApiProject.Models;

namespace ApiProject.Services.InvoiceService
{
    public interface IInvoiceService
    {

        public Task<ServiceResponse<List<Invoice>>> GetInvoices();
        public Task<ServiceResponse<Invoice>> GetInvoice(int id);
        public Task<ServiceResponse<Invoice>> DeleteInvoice(int id);
        public Task<ServiceResponse<Invoice>> PostInvoice(InvoiceDto invoiceDto);
        public Task<ServiceResponse<Invoice>> PutInvoice(Invoice invoice);
    }
}

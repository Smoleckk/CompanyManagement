using ApiProject.Data;
using ApiProject.Dtos;
using ApiProject.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Services.InvoiceService
{
    public class InvoiceService : IInvoiceService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public InvoiceService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<Invoice>>> GetInvoices()
        {
            var response = new ServiceResponse<List<Invoice>>();
            var invoices = await _context.Invoices.Include(d => d.products).ToListAsync();

            if (invoices == null)
            {
                response.Success = false;
                response.Message = "Invoices not found.";
                return response;
            }
            response.Message = "Invoices found successfully.";
            response.Data = invoices;
            return response;
        }
        public async Task<ServiceResponse<Invoice>> GetInvoice(int id)
        {
            var response = new ServiceResponse<Invoice>();

            var invoice = await _context.Invoices.Include(d => d.products).FirstOrDefaultAsync(i => i.id == id);
            if (invoice == null)
            {
                response.Success = false;
                response.Message = "Invoice not found.";
                return response;
            }
            response.Message = "Invoice found successfully.";
            response.Data = invoice;
            return response;
        }
        public async Task<ServiceResponse<Invoice>> DeleteInvoice(int id)
        {
            var response = new ServiceResponse<Invoice>();

            var invoice = await _context.Invoices.Include(d => d.products).FirstOrDefaultAsync(i => i.id == id);
            if (invoice == null)
            {
                response.Success = false;
                response.Message = "Invoices not found, impossible to delete " + id;
                return response;
            }
            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
            response.Data = invoice;
            return response;
        }
        public async Task<ServiceResponse<Invoice>> PostInvoice(InvoiceDto invoiceDto)
        {
            var response = new ServiceResponse<Invoice>();

            var invoice = _mapper.Map<Invoice>(invoiceDto);
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            response.Message = "Invoices added successfully.";
            response.Data = invoice;

            return response;
        }

        public async Task<ServiceResponse<Invoice>> PutInvoice(Invoice invoice)
        {
            var response = new ServiceResponse<Invoice>();

            var sth = _context.Invoices.Include(x => x.products).FirstOrDefault(x => x.id == invoice.id);
            if (sth == null)
            {
                response.Success = false;
                response.Message = "Invoices not found, impossible to update.";
                return response;
            }
            foreach (var item in sth.products)
                _context.Remove(item);

            _context.SaveChanges();
            _context.ChangeTracker.Clear();


            _context.Update(invoice);
            await _context.SaveChangesAsync();

            response.Message = "Invoices update successfully.";
            response.Data = sth;

            return response;
        }
    }
}

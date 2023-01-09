using ApiProject.Data;
using ApiProject.Dtos;
using ApiProject.Models;
using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Services.BuyerService
{
    public class BuyerService : IBuyerService
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public BuyerService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Buyer>> GetBuyer(int id)
        {
            var response = new ServiceResponse<Buyer>();

            var buyer = await _context.Buyers.Include(d => d.Invoices).Include(d => d.Orders).FirstOrDefaultAsync(i => i.id == id);
            if (buyer == null)
            {
                response.Success = false;
                response.Message = "Buyer not found.";
                return response;
            }

            response.Data = buyer;
            return response;
        }

        public async Task<ServiceResponse<List<Buyer>>> GetBuyers()
        {
            var response = new ServiceResponse<List<Buyer>>();

            var buyers = await _context.Buyers.Include(d => d.Invoices).Include(d => d.Orders).ToListAsync();
            //Include(d => d.Invoices)
            if (buyers == null)
            {
                response.Success = false;
                response.Message = "Buyers not found.";
                return response;
            }

            response.Data = buyers;
            return response;

        }
        public async Task<ServiceResponse<Buyer>> DeleteBuyer(int id)
        {
            var response = new ServiceResponse<Buyer>();

            var buyer = await _context.Buyers.FirstOrDefaultAsync(i => i.id == id);
            if (buyer == null)
            {
                response.Success = false;
                response.Message = "Buyer not found, impossible to delete.";
                return response;
            }

            _context.Buyers.Remove(buyer);
            await _context.SaveChangesAsync();

            response.Data = buyer;
            return response;
        }

        public async Task<ServiceResponse<Buyer>> PostBuyer(BuyerDto buyerDto)
        {
            var response = new ServiceResponse<Buyer>();

            var buyer = _mapper.Map<Buyer>(buyerDto);

            _context.Buyers.Add(buyer);
            await _context.SaveChangesAsync();

            response.Data = buyer;
            return response;
        }

        public async Task<ServiceResponse<Buyer>> PutBuyer(Buyer buyer)
        {
            var response = new ServiceResponse<Buyer>();
            //var buyerr = await _context.Buyers.FirstOrDefaultAsync(i => i.id == buyer.id);
            //if (buyerr == null)
            //{
            //    response.Success = false;
            //    response.Message = "Buyer not found, update is impossible.";
            //    return response;
            //}
            _context.Update(buyer);
            await _context.SaveChangesAsync();

            response.Data = buyer;
            return response;
        }
    }
}

using ApiProject.Data;
using ApiProject.Dtos;
using ApiProject.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public OrderService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ServiceResponse<List<Order>>> GetOrders()
        {
            var response = new ServiceResponse<List<Order>>();

            var orders = await _context.Orders.Include(d => d.Products).ToListAsync();
            if (orders == null)
            {
                response.Success = false;
                response.Message = "Orders not found.";
                return response;
            }
            response.Message = "Orders found successfully.";
            response.Data = orders;
            return response;
        }
        public async Task<ServiceResponse<Order>> GetOrder(int id)
        {
            var response = new ServiceResponse<Order>();

            var order = await _context.Orders.Include(d => d.Products).FirstOrDefaultAsync(i => i.OrderId == id);
            if (order == null)
            {
                response.Success = false;
                response.Message = "Order not found.";
                return response;
            }

            response.Message = "Order found successfully.";
            response.Data = order;
            return response;
        }
        public async Task<ServiceResponse<Order>> DeleteOrder(int id)
        {
            var response = new ServiceResponse<Order>();

            var order = await _context.Orders.FirstOrDefaultAsync(i => i.OrderId == id);
            if (order == null)
            {
                response.Success = false;
                response.Message = "Order not found.";
                return response;
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            response.Message = "Delete successfully.";
            response.Data = order;
            return response;
        }
        public async Task<ServiceResponse<Order>> PostOrder(OrderDto orderDto)
        {
            var response = new ServiceResponse<Order>();

            var order = _mapper.Map<Order>(orderDto);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            response.Message = "Item addeed successfully.";
            response.Data = order;
            return response;
        }

        public async Task<ServiceResponse<Order>> PutOrder(Order order)
        {
            var response = new ServiceResponse<Order>();

            var sth = _context.Orders.Include(x => x.Products).FirstOrDefault(x => x.OrderId == order.OrderId);
            if (sth == null)
            {
                response.Success = false;
                response.Message = "Order not found, impossible to update.";
                return response;
            }
            foreach (var item in sth.Products)
                _context.Remove(item);

            _context.SaveChanges();
            _context.ChangeTracker.Clear();


            _context.Update(order);
            await _context.SaveChangesAsync();

            response.Message = "Order updated successfully.";
            response.Data = order;
            return response;
        }
    }
}

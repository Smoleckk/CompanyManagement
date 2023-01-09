using ApiProject.Dtos;
using ApiProject.Models;

namespace ApiProject.Services.OrderService
{
    public interface IOrderService
    {
        public Task<ServiceResponse<List<Order>>> GetOrders();
        public Task<ServiceResponse<Order>> GetOrder(int id);
        public Task<ServiceResponse<Order>> DeleteOrder(int id);
        public Task<ServiceResponse<Order>> PostOrder(OrderDto orderDto);
        public Task<ServiceResponse<Order>> PutOrder(Order order);
    }
}

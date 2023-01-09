using ApiProject.Dtos;
using ApiProject.Models;

namespace ApiProject.Services.BuyerService
{
    public interface IBuyerService
    {
        Task<ServiceResponse<List<Buyer>>> GetBuyers();
        Task<ServiceResponse<Buyer>> GetBuyer(int id);

        Task<ServiceResponse<Buyer>> DeleteBuyer(int id);

        Task<ServiceResponse<Buyer>> PostBuyer(BuyerDto buyerDto);
        Task<ServiceResponse<Buyer>> PutBuyer(Buyer buyer);


    }
}

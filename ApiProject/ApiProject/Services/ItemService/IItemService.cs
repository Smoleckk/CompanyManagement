using ApiProject.Dtos;
using ApiProject.Models;

namespace ApiProject.Services.ItemService
{
    public interface IItemService
    {
        public Task<ServiceResponse<List<Item>>> GetItems();
        public Task<ServiceResponse<Item>> GetItem(int id);
        public Task<ServiceResponse<Item>> DeleteItem(int id);
        public Task<ServiceResponse<Item>> PostItem(ItemDto itemDto);
        public Task<ServiceResponse<Item>> PutItem(Item Item);




    }
}

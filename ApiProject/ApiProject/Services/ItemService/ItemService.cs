using ApiProject.Data;
using ApiProject.Dtos;
using ApiProject.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Services.ItemService
{
    public class ItemService : IItemService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ItemService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<Item>>> GetItems()
        {
            var response = new ServiceResponse<List<Item>>();

            var items = await _context.Items.ToListAsync();
            if (items == null)
            {
                response.Success = false;
                response.Message = "Items not found.";
                return response;
            }
            response.Message = "Items found successfully.";
            response.Data = items;
            return response;
        }
        public async Task<ServiceResponse<Item>> GetItem(int id)
        {
            var response = new ServiceResponse<Item>();

            var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
            if (item == null)
            {
                response.Success = false;
                response.Message = "Item not found.";
                return response;
            }

            response.Message = "Item found successfully.";
            response.Data = item;
            return response;
        }
        public async Task<ServiceResponse<Item>> DeleteItem(int id)
        {
            var response = new ServiceResponse<Item>();

            var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
            if (item == null)
            {
                response.Success = false;
                response.Message = "Item not found to delete.";
                return response;
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            response.Message = "Item delete successfully.";
            response.Data = item;
            return response;
        }
        public async Task<ServiceResponse<Item>> PostItem(ItemDto itemDto)
        {
            var response = new ServiceResponse<Item>();

            var item = _mapper.Map<Item>(itemDto);
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            response.Message = "Item addeed successfully.";
            response.Data = item;
            return response;
        }

        public async Task<ServiceResponse<Item>> PutItem(Item item)
        {
            var response = new ServiceResponse<Item>();
            _context.Update(item);
            await _context.SaveChangesAsync();

            response.Message = "Item updated successfully.";
            response.Data = item;
            return response;
        }
    }
}

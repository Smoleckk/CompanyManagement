using ApiProject.Models;
using AutoMapper;

namespace ApiProject.Dtos
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<InvoiceDto, Invoice>();
            CreateMap<Invoice, Invoice>();
            CreateMap<BuyerDto, Buyer>();
            CreateMap<ItemDto, Item>();
            CreateMap<OrderDto, Order>();

        }
    }
}

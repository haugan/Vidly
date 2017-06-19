using AutoMapper;
using Vidly.Dto;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Customer, CustomerDto>());
            Mapper.Initialize(cfg => cfg.CreateMap<CustomerDto, Customer>());
        }
    }
}
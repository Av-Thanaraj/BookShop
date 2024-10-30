using AutoMapper;
using BookShop.Application.UseCases.Customer.Commands.Create;
using BookShop.Application.UseCases.Property.Queries.GetAll;
using BookShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, GetAllResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<CreateCustomerRequestDto, Customer>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName)).ReverseMap();
        }
    }
}

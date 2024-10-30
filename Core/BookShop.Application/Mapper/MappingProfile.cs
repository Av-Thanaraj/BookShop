using AutoMapper;
using BookShop.Application.UseCases.Customer.Commands.CreateCustomer;
using BookShop.Application.UseCases.Customer.Queries.GetAllCustomers;
using BookShop.Application.UseCases.User.Commands.CreateUser;
using BookShop.Application.UseCases.User.Queries.GetAllUsers;
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
            CreateMap<Customer, GetAllCustomersResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<CreateCustomerRequestDto, Customer>().ReverseMap();

            CreateMap<User, GetAllUsersResponseDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<CreateUserRequestDto, User>().ReverseMap();
        }
    }
}

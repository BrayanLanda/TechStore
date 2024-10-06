using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TechStore.DTOs.CategoryDtos;
using TechStore.DTOs.CustomerDtos;
using TechStore.DTOs.OrderDtos;
using TechStore.DTOs.UserDtos;
using TechStore.Models;

namespace TechStore.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CustomerDto, Customer>();

            CreateMap<OrderDto, Order>();
            CreateMap<OrderItemDto, OrderItem>();

            CreateMap<UserLoginDto, User>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<UserAuthResponseDto, User>();

            CreateMap<CategoryDto, Category>();

            
            CreateMap<UserLoginDto, User>();
        }
    }
}
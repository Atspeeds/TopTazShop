using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTaz.Application.UsersApplication.Dto;
using TopTaz.Domain.OrderAgg;
using TopTaz.Domain.UserAgg;

namespace TopTaz.Infrastrure.AutoMapProfile
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<UserAddress, UserAddressDto>();
            CreateMap<AddUserAddressDto, UserAddress>();
            CreateMap<UserAddress, Address>();
        }
    }
}

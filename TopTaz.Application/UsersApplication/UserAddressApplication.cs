using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TopTaz.Application.ContextACL;
using TopTaz.Application.UsersApplication.Dto;
using TopTaz.Domain.UserAgg;

namespace TopTaz.Application.UsersApplication
{
    public class UserAddressApplication : IUserAddressApplication
    {
        private IDataBaseContext context;
        private IMapper mapper;

        public UserAddressApplication(IDataBaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddAddress(AddUserAddressDto address)
        {
            var data = mapper.Map<UserAddress>(address);
            context.UserAddresses.Add(data);
            context.SaveChanges();

        }

        public List<UserAddressDto> GetAddresses(string userId)
        {
            List<UserAddressDto> userAddress=new List<UserAddressDto>();

            var address = context.UserAddresses
                ?.Where(x => x.UserId == userId).ToList();

            foreach (var item in address)
            {
                userAddress.Add(new UserAddressDto()
                {
                    Id = item.Id,
                    City = item.City,
                    PostalAddress = item.PostalAddress,
                    ReciverName = item.ReciverName,
                    State = item.State,
                    ZipCode = item.ZipCode,

                });


            }

            return userAddress;

        }

    }

}

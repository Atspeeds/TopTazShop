using System.Collections.Generic;
using TopTaz.Application.UsersApplication.Dto;

namespace TopTaz.Application.UsersApplication
{
    public interface IUserAddressApplication
    {
        List<UserAddressDto> GetAddresses(string userId);
        void AddAddress(AddUserAddressDto address);
    }

}

using System.Collections.Generic;
using TopTaz.Application.BasketApplication.Dto;
using TopTaz.Application.UsersApplication.Dto;

namespace ServiceHost.Models.ViewModel.Baskets
{
    public class ShippingPaymentViewModel
    {
        public BasketDto Basket { get; set; }
        public List<UserAddressDto> UserAddresses { get; set; }
    }
}

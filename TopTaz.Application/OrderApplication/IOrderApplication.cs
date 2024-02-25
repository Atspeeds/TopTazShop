using System.Collections.Generic;
using TopTaz.Domain.OrderAgg;

namespace TopTaz.Application.OrderApplication
{
    public interface IOrderApplication
    {
        long CreateOrder(long BasketId, long addressId, PaymentMethod paymentMethod);

    }

}

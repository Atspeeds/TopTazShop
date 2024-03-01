using System;
using TopTaz.Application.PaymentsApplication.Dto;
using TopTaz.Domain.OrderAgg;

namespace TopTaz.Application.PaymentsApplication
{
    public interface IPaymentApplication
    {
        PaymentOfOrderDto PayForOrder(long orderId);
        PaymentDto GetPayment(Guid Id);
        bool VerifyPayment(Guid Id, string Authority, long RefId);

    }
}

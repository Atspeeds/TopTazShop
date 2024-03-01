using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TopTaz.Application.ContextACL;
using TopTaz.Application.PaymentsApplication.Dto;
using TopTaz.Domain.PaymentAgg;

namespace TopTaz.Application.PaymentsApplication
{
    public class PaymentApplication : IPaymentApplication
    {
        private readonly IDataBaseContext _context;

        private readonly IIdentityDatabaseContext _identityContext;

        public PaymentApplication(IDataBaseContext context,
            IIdentityDatabaseContext identityContext)
        {
            _context = context;
            _identityContext = identityContext;
        }

        public PaymentOfOrderDto PayForOrder(long orderId)
        {
            var order = _context.Orders
                   .Include(p => p.OrderItems)
                   .SingleOrDefault(p => p.Id == orderId);
            if (order == null)
                throw new Exception("");
            var payment = _context.Payments.SingleOrDefault(p => p.OrderId == order.Id);

            if (payment == null)
            {
                payment = new Payment(order.TotalPrice(), order.Id);
                _context.Payments.Add(payment);
                _context.SaveChanges();
            }

            return new PaymentOfOrderDto()
            {
                Amount = payment.Amount,
                Id = payment.Id,
                PaymentMethod = order.PaymentMethod,
            };
        }

        public PaymentDto GetPayment(Guid Id)
        {
            var payment = _context.Payments
                 .Include(p => p.Order)
                 .ThenInclude(p => p.OrderItems)
                 .SingleOrDefault(p => p.Id == Id);

            var user = _identityContext.Users.SingleOrDefault(p => p.Id == payment.Order.UserId);

            string description = $"پرداخت سفارش شماره {payment.OrderId} " + Environment.NewLine;
            description += "محصولات" + Environment.NewLine;
            foreach (var item in payment.Order.OrderItems.Select(p => p.ProductName))
            {
                description += $" -{item}";
            }

            PaymentDto paymentDto = new PaymentDto
            {
                Amount = payment.Order.TotalPrice(),
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Userid = user.Id,
                Id = payment.Id,
                Description = description,
            };
            return paymentDto;
        }
        public bool VerifyPayment(Guid Id, string Authority, long RefId)
        {
            var payment = _context.Payments
             .Include(p => p.Order)
             .SingleOrDefault(p => p.Id == Id);

            if (payment == null)
                throw new Exception("payment not found");

            payment.Order.PaymentDone();
            payment.PaymentIsDone(Authority, RefId);

            _context.SaveChanges();
            return true;
        }

    }



}

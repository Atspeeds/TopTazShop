using System;
using TopTaz.Domain.FrameWorkDomain;
using TopTaz.Domain.OrderAgg;

namespace TopTaz.Domain.PaymentAgg
{
    [Auditable]
    public class Payment
    {
        public Guid Id { get; set; }
        public int Amount { get; private set; }
        public bool IsPay { get; private set; } = false;
        public DateTime? DatePay { get; private set; } = null;
        public string Authority { get; private set; }
        public long RefId { get; private set; } = 0;
        public long OrderId { get; private set; }
        public Order Order { get; private set; }
        public Payment(int amount, long orderId)
        {
            Amount = amount;
            OrderId = orderId;
        }

        public void PaymentIsDone(string authority, long refId)
        {
            IsPay = true;
            DatePay = DateTime.Now;
            Authority = authority;
            RefId = refId;
        }
    }
}

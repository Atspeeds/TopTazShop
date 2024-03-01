using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTaz.Domain.OrderAgg;

namespace TopTaz.Application.PaymentsApplication.Dto
{
    public class PaymentOfOrderDto
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}

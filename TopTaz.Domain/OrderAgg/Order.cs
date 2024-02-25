using System;
using System.Collections.Generic;
using System.Linq;
using TopTaz.Domain.FrameWorkDomain;

namespace TopTaz.Domain.OrderAgg
{
    [Auditable]
    public class Order
    {
        public long Id { get; set; }
        public string UserId { get; private set; }
        public DateTime OrderDate { get; private set; } = DateTime.Now;
        public Address Address { get; private set; }

        public PaymentMethod PaymentMethod { get; private set; }
        public PaymentStatus PaymentStatus { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        private readonly List<OrderItem> _orderItems = new List<OrderItem>();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public Order(string userId, Address address, List<OrderItem> orderItems, PaymentMethod paymentMethod)
        {
            UserId = userId;
            Address = address;
            _orderItems = orderItems;
            PaymentMethod = paymentMethod;
        }

        public Order()
        {

        }



        /// <summary>
        /// پرداخت انجام شد
        /// </summary>
        public void PaymentDone()
        {
            PaymentStatus = PaymentStatus.Paid;
        }


        /// <summary>
        /// کالا تحویل داده شد
        /// </summary>
        public void OrderDelivered()
        {
            OrderStatus = OrderStatus.Delivered;
        }

        /// <summary>
        /// ثبت مرجوعی کالا
        /// </summary>
        public void OrderReturned()
        {
            OrderStatus = OrderStatus.Returned;
        }


        /// <summary>
        /// لغو سفارش
        /// </summary>
        public void OrderCancelled()
        {
            OrderStatus = OrderStatus.Cancelled;
        }

        public int TotalPrice()
        {
            return _orderItems.Sum(p => p.UnitPrice * p.Units);
        }

    }

    public class Address
    {
        public string State { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string ReciverName { get; private set; }
        public Address(string city, string state, string zipCode, string postalAddress)
        {
            this.City = city;
            State = state;
            ZipCode = zipCode;
            PostalAddress = postalAddress;
        }
    }



    public enum PaymentMethod
    {
        /// <summary>
        /// پرداخت آنلاین
        /// </summary>
        OnlinePaymnt = 0,
        /// <summary>
        /// پرداخت در محل
        /// </summary>
        PaymentOnTheSpot = 1,
    }

    public enum PaymentStatus
    {
        /// <summary>
        /// منتظر پرداخت
        /// </summary>
        WaitingForPayment = 0,
        /// <summary>
        /// پرداخت انجام شد
        /// </summary>
        Paid = 1,
    }

    public enum OrderStatus
    {

        /// <summary>
        /// در حال پردازش
        /// </summary>
        Processing = 0,
        /// <summary>
        /// تحویل داده شد
        /// </summary>
        Delivered = 1,
        /// <summary>
        /// مرجوعی
        /// </summary>
        Returned = 2,
        /// <summary>
        /// لغو شد
        /// </summary>
        Cancelled = 3,
    }
}

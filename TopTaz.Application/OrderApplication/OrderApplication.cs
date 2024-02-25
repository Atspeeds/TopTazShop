using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TopTaz.Application.ContextACL;
using TopTaz.Domain.OrderAgg;
using TT.FrameWork.Application.Proxy;

namespace TopTaz.Application.OrderApplication
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        UriComposerServiceProxy uriComposerService = new UriComposerServiceProxy();

        public OrderApplication(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public long CreateOrder(long BasketId, long UserAddressId, PaymentMethod paymentMethod)
        {
            var basket = _context.Baskets
                         .Include(p => p.Items)
                         .SingleOrDefault(p => p.Id == BasketId);

            long[] Ids = basket.Items.Select(x => x.CatalogItemId).ToArray();
            var catalogItems = _context.CatalogItems
                .Include(p => p.CatalogItemImages)
                .Where(p => Ids.Contains(p.Id));


            var orderItems = basket.Items.Select(basketItem =>
            {
                var catalogItem = catalogItems.First(c => c.Id == basketItem.CatalogItemId);

                string urlImage = catalogItem?.CatalogItemImages?.FirstOrDefault()?.Src ?? "";

                var orderitem = new OrderItem(catalogItem.Id,
                    catalogItem.Name,
                  uriComposerService
                   .GetComposeImageUri
                   (urlImage),
                    catalogItem.Price, basketItem.Quantity);
                return orderitem;

            }).ToList();

            var userAddress = _context.UserAddresses.SingleOrDefault(p => p.Id == UserAddressId);
            var address = _mapper.Map<Address>(userAddress);
            var order = new Order(basket.BuyerId, address, orderItems, paymentMethod);
            _context.Orders.Add(order);
            _context.Baskets.Remove(basket);
            _context.SaveChanges();
            return order.Id;

        }
    }

}

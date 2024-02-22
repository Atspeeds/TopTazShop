using Microsoft.EntityFrameworkCore;
using System.Linq;
using TopTaz.Application.BasketApplication.Dto;
using TopTaz.Application.CatalogApplication.UriComposer;
using TopTaz.Application.ContextACL;
using TopTaz.Domain.BasketAgg;

namespace TopTaz.Application.BasketApplication.BasketQuery
{
    public class BasketQuery : IBasketQuery
    {
        private readonly IDataBaseContext context;
        private readonly IUriComposerService uriComposerService;

        public BasketQuery(IDataBaseContext context
            , IUriComposerService uriComposerService)
        {
            this.context = context;
            this.uriComposerService = uriComposerService;
        }

        public void AddItemToBasket(long baketId, long catalogItemid, int quantity = 1)
        {
            var basket = context.Baskets.SingleOrDefault(x => x.Id == baketId);
            if (basket == null)
                throw new System.Exception();

            var catalogPrice = context.CatalogItems.Select(x => new { x.Id, x.Price })
                .SingleOrDefault(x => x.Id == catalogItemid).Price;

            basket.AddItem(catalogItemid, quantity, catalogPrice);
            context.SaveChanges();

        }

        public BasketDto GetOrCreateBasketForUser(string BuyerId)
        {
            var basket = context.Baskets
                .Include(p => p.Items)
                .ThenInclude(p => p.CatalogItem)
                .ThenInclude(p => p.CatalogItemImages)
                .SingleOrDefault(p => p.BuyerId == BuyerId);
            if (basket == null)
            {
                return CreateBasketForUser(BuyerId);
            }

            var items = basket.Items.Select(item => new BasketItemDto
            {
                CatalogItemid = item.CatalogItemId,
                Id = item.Id,
                CatalogName = item.CatalogItem.Name,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                ImageUrl = uriComposerService.ComposeImageUri(item?.CatalogItem?
                      .CatalogItemImages?.FirstOrDefault()?.Src ?? ""),

            }).ToList();

            return new BasketDto(basket.Id, basket.BuyerId, items);

        }

        public bool RemoveItemFromBasket(long ItemId)
        {
            var item = context.BasketItems.SingleOrDefault(x => x.Id == ItemId);
            if (item == null)
                return false;

            context.BasketItems.Remove(item);
            context.SaveChanges();

            return true;
        }

        private BasketDto CreateBasketForUser(string BuyerId)
        {
            Domain.BasketAgg.Basket basket = new Domain.BasketAgg.Basket(BuyerId);
            context.Baskets.Add(basket);
            context.SaveChanges();
            return new BasketDto(basket.Id, basket.BuyerId);

        }


        public bool SetQuantities(long itemId, int quantity)
        {
            var item = context.BasketItems.SingleOrDefault(p => p.Id == itemId);
            item.SetQuantity(quantity);
            context.SaveChanges();
            return true;
        }

        public BasketDto GetBasketForUser(string UserId)
        {
            var basket = context.Baskets
              .Include(p => p.Items)
              .ThenInclude(p => p.CatalogItem)
              .ThenInclude(p => p.CatalogItemImages)
              .SingleOrDefault(p => p.BuyerId == UserId);
            if (basket == null)
            {
                return null;
            }
            return new BasketDto
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                Items = basket.Items.Select(item => new BasketItemDto
                {
                    CatalogItemid = item.CatalogItemId,
                    Id = item.Id,
                    CatalogName = item.CatalogItem.Name,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    ImageUrl = uriComposerService.ComposeImageUri(item?.CatalogItem?
                     .CatalogItemImages?.FirstOrDefault()?.Src ?? ""),

                }).ToList(),
            };
        }

        public void TransferBasket(string anonymousId, string UserId)
        {
            var anonymousBasket = context.Baskets
                 .SingleOrDefault(p => p.BuyerId == anonymousId);
            if (anonymousBasket == null) return;
            var userBasket = context.Baskets.SingleOrDefault(p => p.BuyerId == UserId);
            if (userBasket == null)
            {
                userBasket = new Basket(UserId);
                context.Baskets.Add(userBasket);
            }

            foreach (var item in anonymousBasket.Items)
            {
                userBasket.AddItem(item.CatalogItemId, item.Quantity, item.UnitPrice);
            }

            context.Baskets.Remove(anonymousBasket);

            context.SaveChanges();
        }
    }
}

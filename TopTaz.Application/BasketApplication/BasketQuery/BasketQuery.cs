using Microsoft.EntityFrameworkCore;
using System.Linq;
using TopTaz.Application.BasketApplication.Dto;
using TopTaz.Application.CatalogApplication.UriComposer;
using TopTaz.Application.ContextACL;

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
        public BasketDto GetOrCreateBasketForUser(string BuyerId)
        {
            var basket = context.Baskets
                .Include(p => p.Items)
                .ThenInclude(p => p.CatalogItem)
                .ThenInclude(p => p.CatalogItemImages)
                .SingleOrDefault(p => p.BuyerId == BuyerId);
            if (basket == null)
            {
                //سبد خرید را ایجاد کنید
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
    

        private BasketDto CreateBasketForUser(string BuyerId)
        {
            Domain.BasketAgg.Basket basket = new Domain.BasketAgg.Basket(BuyerId);
            context.Baskets.Add(basket);
            context.SaveChanges();
            return new BasketDto(basket.Id, basket.BuyerId);
           
        }


    }
}

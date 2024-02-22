using TopTaz.Application.BasketApplication.Dto;

namespace TopTaz.Application.BasketApplication.BasketQuery
{
    public interface IBasketQuery
    {
        BasketDto GetOrCreateBasketForUser(string BuyerId);
        void AddItemToBasket(long baketId,long catalogItemid,int quantity=1);
        bool RemoveItemFromBasket(long ItemId);
        bool SetQuantities(long itemId, int quantity);
        BasketDto GetBasketForUser(string UserId);
        void TransferBasket(string anonymousId, string UserId);
    }
}

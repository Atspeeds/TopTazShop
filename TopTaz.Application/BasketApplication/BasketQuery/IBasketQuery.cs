using TopTaz.Application.BasketApplication.Dto;

namespace TopTaz.Application.BasketApplication.BasketQuery
{
    public interface IBasketQuery
    {
        BasketDto GetOrCreateBasketForUser(string BuyerId);
    }
}

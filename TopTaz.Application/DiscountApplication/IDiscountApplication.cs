using System.Collections.Generic;
using TopTaz.Application.DiscountApplication.Dto;
using TopTaz.Application.DtoModel;
using TopTaz.Domain.DiscountAgg;
using TopTaz.Domain.UserAgg;

namespace TopTaz.Application.DiscountApplication
{
    public interface IDiscountApplication
    {
        void Create(AddNewDiscountDto command);
        List<CatalogItemDto> SearchCatalog(string SearchKey);
        bool ApplyDiscountInBasket(string CoponCode, long BasketId);
        bool RemoveDiscountFromBasket(long BasketId);
        BaseDto IsDiscountValid(string couponCode, User user);
        void InsertDiscountUsageHistory(long DiscountId, long OrderId);
        DiscountUsageHistory GetDiscountUsageHistoryById(long discountUsageHistoryId);
        PaginatedItemDto<DiscountUsageHistory> GetAllDiscountUsageHistory(long? discountId,
       string? userId, int pageIndex, int pageSize);
    }
    
}

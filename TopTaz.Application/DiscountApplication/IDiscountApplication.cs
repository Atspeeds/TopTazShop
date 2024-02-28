using System.Collections.Generic;
using TopTaz.Application.DiscountApplication.Dto;

namespace TopTaz.Application.DiscountApplication
{
    public interface IDiscountApplication
    {
        void Create(AddNewDiscountDto command);
        List<CatalogItemDto> SearchCatalog(string SearchKey);
    }
    
}

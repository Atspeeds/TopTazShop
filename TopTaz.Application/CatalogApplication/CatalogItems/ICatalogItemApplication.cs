using TopTaz.Application.CatalogApplication.Dtos;
using TopTaz.Application.DtoModel;

namespace TopTaz.Application.CatalogApplication.CatalogItems
{
    public interface ICatalogItemApplication
    {
        BaseDto<long> Create(CatalogItemDto command);
        PaginatedItemDto<CatalogItemsListDto> Get(int page, int pageSize);


    }

}

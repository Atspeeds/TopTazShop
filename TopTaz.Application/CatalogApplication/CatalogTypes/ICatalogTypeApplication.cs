using TopTaz.Application.CatalogApplication.Dtos;
using TopTaz.Application.DtoModel;

namespace TopTaz.Application.CatalogApplication.CatalogTypes
{
    public interface ICatalogTypeApplication
    {
        BaseDto<CatalogTypeDto> Add(CatalogTypeDto catalogType);
        BaseDto Remove(long Id);
        BaseDto<CatalogTypeDto> Edit(CatalogTypeDto catalogType);
        BaseDto<CatalogTypeDto> FindById(long Id);
        PaginatedItemDto<CatalogTypeListDto> GetList(long? parentId, int page, int pageSize);

    }
}

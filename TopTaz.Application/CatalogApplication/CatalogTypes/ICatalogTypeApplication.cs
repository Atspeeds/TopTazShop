using TopTaz.Application.CatalogApplication.Dtos;
using TopTaz.Application.DtoModel;

namespace TopTaz.Application.CatalogApplication.CatalogTypes
{
    public interface ICatalogTypeApplication
    {
        BaseDto<CreateCatalogType> Create(CreateCatalogType command);
        BaseDto Remove(long id);
        BaseDto<EditCatalogType> Edit(EditCatalogType command);
        BaseDto<CatalogTypeViewModel> Get(long id);
        PaginatedItemDto<CatalogTypeViewModel> Get(long? parentid, int pageindex, int pagesize);

    }
}

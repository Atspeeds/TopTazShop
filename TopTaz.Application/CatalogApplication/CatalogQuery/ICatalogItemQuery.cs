using System.Collections.Generic;
using TopTaz.Application.CatalogApplication.Dtos;

namespace TopTaz.Application.CatalogApplication.CatalogQuery
{
    public interface ICatalogItemQuery
    {
        List<CatalogBrandDto> GetBrands();
        List<ListCatalogTypeDto> GetCatalogType();
    }


}

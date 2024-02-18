using System.Collections.Generic;
using System.Linq;
using TopTaz.Application.CatalogApplication.Dtos;
using TopTaz.Application.DtoModel;
using TopTaz.Application.ViewModel;

namespace TopTaz.Application.CatalogApplication.CatalogQuery
{
    public interface ICatalogItemQuery
    {
        List<CatalogBrandDto> GetBrands();
        List<ListCatalogTypeDto> GetCatalogType();
        PaginatedItemDto<CatalogItemViewModel> GetCatalogItems(int page, int pageSize);

        CatalogItemPDPDto GetDetail(long id);
    }

    public class CatalogItemPDPDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public List<string> Images { get; set; }
        public string Description { get; set; }
        public IEnumerable<IGrouping<string, PDPFeaturesDto>> Features { get; set; }
        public List<SimilarCatalogItemDto> SimilarCatalogs { get; set; }

    }

    public class PDPFeaturesDto
    {
        public string Group { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }


    public class SimilarCatalogItemDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Images { get; set; }
    }

}

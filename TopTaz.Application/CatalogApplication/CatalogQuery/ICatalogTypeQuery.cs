using System.Collections.Generic;
using System.Threading.Tasks;
using TopTaz.Application.CatalogApplication.Dtos;

namespace TopTaz.Application.CatalogApplication.CatalogQuery
{
    public interface ICatalogTypeQuery
    {
       public List<MenoItemDto> Get();

    }

}

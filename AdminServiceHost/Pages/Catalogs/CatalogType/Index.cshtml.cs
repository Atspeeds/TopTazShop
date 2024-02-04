using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopTaz.Application.CatalogApplication.CatalogTypes;
using TopTaz.Application.CatalogApplication.Dtos;
using TopTaz.Application.DtoModel;

namespace AdminServiceHost.Pages.Catalogs.CatalogType
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogTypeApplication _catalogTypeApplication;

        public IndexModel(ICatalogTypeApplication catalogTypeApplication)
        {
            _catalogTypeApplication = catalogTypeApplication;
        }

        public PaginatedItemDto<CatalogTypeListDto> CatalogItems;

        public void OnGet(long? parentid, int pageindex, int pagesize=100)
        {
            CatalogItems = _catalogTypeApplication.GetList(parentid, pageindex, pagesize);
           
        }
    }
}

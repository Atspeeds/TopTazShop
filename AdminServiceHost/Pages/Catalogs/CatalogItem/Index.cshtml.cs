using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopTaz.Application.CatalogApplication.CatalogItems;
using TopTaz.Application.CatalogApplication.Dtos;
using TopTaz.Application.DtoModel;

namespace AdminServiceHost.Pages.Catalogs.CatalogItem
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogItemApplication _catalogItemApplication;

        public IndexModel(ICatalogItemApplication catalogItemApplication)
        {
            _catalogItemApplication = catalogItemApplication;
        }

        public PaginatedItemDto<CatalogItemsListDto> CatalogItems;

        public void OnGet(int page=1,int pageSize=100)
        {
            CatalogItems = _catalogItemApplication.Get(page,pageSize);
        }

    }
}

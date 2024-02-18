using Microsoft.AspNetCore.Mvc;
using TopTaz.Application.CatalogApplication.CatalogQuery;

namespace ServiceHost.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICatalogItemQuery _catalogItemQuery;
   
        public ProductController(ICatalogItemQuery catalogItemQuery)
        {
            _catalogItemQuery = catalogItemQuery;
        }

        public IActionResult Index(int page=1,int pagesize=20)
        {
            var model=_catalogItemQuery.GetCatalogItems(page,pagesize);
            return View(model);
        }
        public IActionResult Details(long id)
        {
           var model=_catalogItemQuery.GetDetail(id);
            return View(model);
        }
    }
}

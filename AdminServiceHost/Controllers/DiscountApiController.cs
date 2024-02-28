using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TopTaz.Application.DiscountApplication;

namespace AdminServiceHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountApiController : ControllerBase
    {
        private readonly IDiscountApplication _discountApplication;

        public DiscountApiController(IDiscountApplication discountApplication)
        {
            _discountApplication = discountApplication;
        }

        [HttpGet]
        [Route("GetCatalogItem")]
        public async Task<IActionResult> GetCatalogItem(string term)
        {
            return Ok(_discountApplication.SearchCatalog(term));
        }
    }
}

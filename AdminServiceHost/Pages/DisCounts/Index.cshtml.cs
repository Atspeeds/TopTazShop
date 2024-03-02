using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopTaz.Application.DiscountApplication;
using TopTaz.Application.DiscountApplication.Dto;

namespace AdminServiceHost.Pages.DisCounts
{
    public class IndexModel : PageModel
    {
        private readonly IDiscountApplication _discountApplication;

        public IndexModel(IDiscountApplication discountApplication)
        {
            _discountApplication = discountApplication;
        }


        [BindProperty]
        public AddNewDiscountDto NewDiscountDto { get; set; }

        public void OnGet()
        {
        }

        public void OnGetCreate()
        {
            
        }

        public IActionResult OnPostCreate(AddNewDiscountDto NewDiscountDto)
        {
            _discountApplication.Create(NewDiscountDto);
            return null;
        }

    }
}

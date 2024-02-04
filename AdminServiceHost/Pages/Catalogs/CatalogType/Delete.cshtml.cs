using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using TopTaz.Application.CatalogApplication.CatalogTypes;
using AdminServiceHost.ViewModels.Catalogs;

namespace AdminServiceHost.Pages.Catalogs.CatalogType
{
    public class DeleteModel : PageModel
    {
        private readonly ICatalogTypeApplication catalogTypeService;


        public DeleteModel(ICatalogTypeApplication catalogTypeService)
        {
            this.catalogTypeService = catalogTypeService;
        }

        [BindProperty]
        public CatalogTypeViewModel CatalogType { get; set; } = new CatalogTypeViewModel();
        public List<String> Message { get; set; } = new List<string>();
        public void OnGet(long Id)
        {
            var model = catalogTypeService.FindById(Id);
            if (model.ISsuccess)
                CatalogType = new CatalogTypeViewModel()
                {
                    Id=model.Model.Id,
                    ParentCatalogTypeId= model.Model.ParentCatalogTypeId,
                    Type= model.Model.Type,
                };

            Message = model.Messages;
        }

        public IActionResult OnPost()
        {
            var result = catalogTypeService.Remove(CatalogType.Id);
            Message = result.Messages;
            if (result.ISsuccess)
            {
                return RedirectToPage("index");
            }
            return Page();
        }
    }
}

using AdminServiceHost.ViewModels.Catalogs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using TopTaz.Application.CatalogApplication.CatalogTypes;
using TopTaz.Application.CatalogApplication.Dtos;

namespace AdminServiceHost.Pages.Catalogs.CatalogType
{
    public class CreateModel : PageModel
    {
        private readonly ICatalogTypeApplication catalogTypeService;

        public CreateModel(ICatalogTypeApplication catalogTypeService)
        {
            this.catalogTypeService = catalogTypeService;
        }

        [BindProperty]
        public CatalogTypeViewModel CatalogType { get; set; } = new CatalogTypeViewModel { };
        public List<String> Message { get; set; } = new List<string>();

        public void OnGet(long? parentId)
        {
            CatalogType.ParentCatalogTypeId = parentId;
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var model = new CatalogTypeDto()
            {
                Id = CatalogType.Id,
                Type = CatalogType.Type,
                ParentCatalogTypeId = CatalogType.ParentCatalogTypeId,
            };
            var result = catalogTypeService.Add(model);
            if (result.ISsuccess)
            {
                return RedirectToPage("index", new { parentid = CatalogType.ParentCatalogTypeId });
            }
            Message = result.Messages;
            return Page();
        }

    }
}

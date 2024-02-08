using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using TopTaz.Application.CatalogApplication.CatalogItems;
using TopTaz.Application.CatalogApplication.CatalogQuery;
using TopTaz.Application.CatalogApplication.Dtos;
using TopTaz.Application.DtoModel;
using TopTaz.Domain.CatalogAgg;
using TopTaz.Infrastrure.ExternalApi.ImageServer;

namespace AdminServiceHost.Pages.Catalogs.CatalogItem
{
    public class CreateModel : PageModel
    {
        private readonly ICatalogItemApplication addNewCatalogItemService;
        private readonly ICatalogItemQuery catalogItemService;
        private readonly IImageUploadService imageUploadService;

        public CreateModel(ICatalogItemApplication addNewCatalogItemService
            , ICatalogItemQuery catalogItemService
            , IImageUploadService imageUploadService)
        {
            this.addNewCatalogItemService = addNewCatalogItemService;
            this.catalogItemService = catalogItemService;
            this.imageUploadService = imageUploadService;
        }

        public SelectList Categories { get; set; }
        public SelectList Brands { get; set; }

        [BindProperty]
        public CatalogItemDto Data { get; set; }
        [BindProperty]
        public List<IFormFile> Files { get; set; }


        public void OnGet()
        {
            Categories = new SelectList(catalogItemService.GetCatalogType(), "Id", "Type");
            Brands = new SelectList(catalogItemService.GetBrands(), "Id", "Brand");
        }



        public JsonResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new JsonResult(new BaseDto<int>(0,false, allErrors.Select(p => p.ErrorMessage).ToList()));
            }
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                Files.Add(file);
            }
            List<CatalogItemImageDto> images = new List<CatalogItemImageDto>();
            if (Files.Count > 0)
            {
                //Upload 
                var result = imageUploadService.Upload(Files).Result;
                foreach (var item in result)
                {
                    images.Add(new CatalogItemImageDto { Src = item });
                }
            }
            Data.Images = images;
            var resultService = addNewCatalogItemService.Create(Data);
            return new JsonResult(resultService);
        }
    }
}

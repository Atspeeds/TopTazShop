using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TopTaz.Application.CatalogApplication.Dtos;
using TopTaz.Application.CatalogApplication.Proxy;
using TopTaz.Application.ContextACL;
using TopTaz.Application.DtoModel;
using TopTaz.Application.ViewModel;
using TT.FrameWork.Application;

namespace TopTaz.Application.CatalogApplication.CatalogQuery
{
    public class CatalogItemQuery : ICatalogItemQuery
    {
        private readonly IDataBaseContext _context;
        private IMapper _mapper;
        UriComposerServiceProxy uriComposerService = new UriComposerServiceProxy();
        public CatalogItemQuery(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CatalogBrandDto> GetBrands()
        {
            var brands = _context.CatalogBrands
           .OrderBy(p => p.Brand).Take(500).ToList();

            var data = _mapper.Map<List<CatalogBrandDto>>(brands);
            return data;
        }

        public PaginatedItemDto<CatalogItemViewModel> GetCatalogItems(int page, int pageSize)
        {
            int totalCount = 0;

            var result=_context.CatalogItems
                .Include(x=>x.CatalogItemImages)
                .PagedResult(page, pageSize,out totalCount)
                .Select(x=>new CatalogItemViewModel()
                {
                    Id=x.Id,
                    Name=x.Name,
                    Price=x.Price,
                    Rate=4,
                    Image= uriComposerService
                    .GetComposeImageUri(x.CatalogItemImages.FirstOrDefault().Src),
                    
                })
                .OrderByDescending(x=>x.Id).ToList();

            

            return new PaginatedItemDto<CatalogItemViewModel>(result, page, totalCount, pageSize);

        }

        public List<ListCatalogTypeDto> GetCatalogType()
        {
            var types = _context.CatalogTypes
               .Include(p => p.ParentCatalogType)
               .Include(p => p.ParentCatalogType)
               .ThenInclude(p => p.ParentCatalogType.ParentCatalogType)
                .Include(p => p.ChildCatalogType)
                .Where(p => p.ParentCatalogTypeId != null)
                .Where(p => p.ChildCatalogType.Count == 0)
                 .Select(p => new { p.Id, p.Type, p.ParentCatalogType, p.ChildCatalogType })
                                .ToList()
                .Select(p => new ListCatalogTypeDto
                {
                    Id = p.Id,
                    Type = $"{p?.Type ?? ""} - {p?.ParentCatalogType?.Type ?? ""} - {p?.ParentCatalogType?.ParentCatalogType?.Type ?? ""}"
                }).ToList();
            return types;
        }

        public CatalogItemPDPDto GetDetail(long id)
        {
            var catalogitem = _context.CatalogItems
               .Include(p => p.catalogItemFeatures)
               .Include(p => p.CatalogItemImages)
               .Include(p => p.CatalogType)
               .Include(p => p.CatalogBrand)
               .SingleOrDefault(p => p.Id == id);

            var feature = catalogitem.catalogItemFeatures
                .Select(p => new PDPFeaturesDto
                {
                    Group = p.Group,
                    Key = p.Key,
                    Value = p.Value
                }).ToList()
                .GroupBy(p => p.Group);

            var similarCatalogItems = _context
               .CatalogItems
               .Include(p => p.CatalogItemImages)
               .Where(p => p.CatalogTypeId == catalogitem.CatalogTypeId)
               .Take(10)
               .Select(p => new SimilarCatalogItemDto
               {
                   Id = p.Id,
                   Images = uriComposerService.GetComposeImageUri(p.CatalogItemImages.FirstOrDefault().Src),
                   Price = p.Price,
                   Name = p.Name
               }).ToList();

            return new CatalogItemPDPDto
            {
                Features = feature,
                SimilarCatalogs = similarCatalogItems,
                Id = catalogitem.Id,
                Name = catalogitem.Name,
                Brand = catalogitem.CatalogBrand.Brand,
                Type = catalogitem.CatalogType.Type,
                Price = catalogitem.Price,
                Description = catalogitem.Description,
                Images = catalogitem.CatalogItemImages.Select(p => uriComposerService.GetComposeImageUri(p.Src)).ToList(),

            };

        }

    }


}

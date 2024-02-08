using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TopTaz.Application.CatalogApplication.Dtos;
using TopTaz.Application.ContextACL;

namespace TopTaz.Application.CatalogApplication.CatalogQuery
{
    public class CatalogItemQuery : ICatalogItemQuery
    {
        private readonly IDataBaseContext _context;
        private IMapper _mapper;

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
    }


}

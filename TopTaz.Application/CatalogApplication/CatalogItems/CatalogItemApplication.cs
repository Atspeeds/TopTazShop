using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TopTaz.Application.CatalogApplication.Dtos;
using TopTaz.Application.ContextACL;
using TopTaz.Application.DtoModel;
using TopTaz.Domain.CatalogAgg;
using TT.FrameWork.Application;

namespace TopTaz.Application.CatalogApplication.CatalogItems
{
    public class CatalogItemApplication : ICatalogItemApplication
    {
        private readonly IDataBaseContext _Context;
        private IMapper _mapper;

        public CatalogItemApplication(IDataBaseContext context, IMapper mapper)
        {
            _Context = context;
            _mapper = mapper;
        }

        public BaseDto<long> Create(CatalogItemDto command)
        {
            var catalogMap = _mapper.Map<CatalogItem>(command);

            _Context.CatalogItems.Add(catalogMap);
            _Context.SaveChanges();
            return new BaseDto<long>(catalogMap.Id,true);
        }

        public PaginatedItemDto<CatalogItemsListDto> Get(int page, int pageSize)
        {
            int totalCount = 0;

            var catalogItems = _Context.CatalogItems
                .Include(x=>x.CatalogType)
                .Include(x=>x.CatalogBrand)
                .ToPaged(page, pageSize,out totalCount)
                .OrderByDescending(x=>x.Id).AsQueryable();


            var result = _mapper.ProjectTo<CatalogItemsListDto>(catalogItems).ToList();
            return new PaginatedItemDto<CatalogItemsListDto>(result, page, totalCount, pageSize);

        }
    }
    
}

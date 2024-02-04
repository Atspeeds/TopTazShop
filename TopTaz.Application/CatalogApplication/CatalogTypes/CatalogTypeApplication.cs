using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TopTaz.Application.CatalogApplication.Dtos;
using TopTaz.Application.ContextACL;
using TopTaz.Application.DtoModel;
using TopTaz.Domain.CatalogAgg;
using TT.FrameWork.Application;
using TT.FrameWork.Messages;

namespace TopTaz.Application.CatalogApplication.CatalogTypes
{
    public class CatalogTypeApplication : ICatalogTypeApplication
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;

        public CatalogTypeApplication(IDataBaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public BaseDto<CatalogTypeDto> Add(CatalogTypeDto catalogType)
        {
            var model = mapper.Map<CatalogType>(catalogType);
            context.CatalogTypes.Add(model);
            context.SaveChanges();
            return new BaseDto<CatalogTypeDto>(mapper.Map<CatalogTypeDto>(model), true);

        }

        public BaseDto<CatalogTypeDto> Edit(CatalogTypeDto catalogType)
        {
            var model = context.CatalogTypes.SingleOrDefault(p => p.Id == catalogType.Id);
            mapper.Map(catalogType, model);
            context.SaveChanges();
            return new BaseDto<CatalogTypeDto>(mapper.Map<CatalogTypeDto>(model), true);
        }

        public BaseDto<CatalogTypeDto> FindById(long Id)
        {
            var data = context.CatalogTypes.Find(Id);
            var result = mapper.Map<CatalogTypeDto>(data);
            return new BaseDto<CatalogTypeDto>(result, true);
        }

        public PaginatedItemDto<CatalogTypeListDto> GetList(long? parentId, int page, int pageSize)
        {
            int totalCount = 0;
            var model = context.CatalogTypes
                .Where(p => p.ParentCatalogTypeId == parentId)
                .PagedResult(page, pageSize, out totalCount);
            
            
            
            var result = mapper.ProjectTo<CatalogTypeListDto>(model).ToList();
            return new PaginatedItemDto<CatalogTypeListDto>(result,page,totalCount,pageSize);
        }

        public BaseDto Remove(long Id)
        {
            var catalogType = context.CatalogTypes.Find(Id);
            context.CatalogTypes.Remove(catalogType);
            context.SaveChanges();
            return new BaseDto
            (
             true,
             new List<string> { $"ایتم با موفقیت حذف شد" }
             );
        }
    }
}

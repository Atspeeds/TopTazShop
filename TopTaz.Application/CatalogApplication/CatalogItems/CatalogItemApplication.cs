using AutoMapper;
using TopTaz.Application.CatalogApplication.Dtos;
using TopTaz.Application.ContextACL;
using TopTaz.Application.DtoModel;
using TopTaz.Domain.CatalogAgg;

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
    }
    
}

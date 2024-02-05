using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopTaz.Application.CatalogApplication.Dtos;
using TopTaz.Application.ContextACL;

namespace TopTaz.Application.CatalogApplication.CatalogQuery
{
    public class CatalogTypeQuery : ICatalogTypeQuery
    {
        private IDataBaseContext _context;
        private IMapper _mapper;

        public CatalogTypeQuery(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<MenoItemDto> Get()
        {
            var resualt = _context.CatalogTypes
                .Include(x => x.ParentCatalogType)
                .ToList();
            var data = _mapper.Map<List<MenoItemDto>>(resualt);

            return data;
           
        }
    }

}

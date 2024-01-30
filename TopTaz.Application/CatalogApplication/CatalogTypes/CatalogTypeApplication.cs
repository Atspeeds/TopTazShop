using Amazon.Runtime.Internal;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TopTaz.Application.CatalogApplication.Dtos;
using TopTaz.Application.ContextACL;
using TopTaz.Application.DtoModel;
using TT.FrameWork.Messages;

namespace TopTaz.Application.CatalogApplication.CatalogTypes
{
    public class CatalogTypeApplication : ICatalogTypeApplication
    {
        private readonly IDataBaseContext _Context;
        private IMapper _mapper;
        public CatalogTypeApplication(IDataBaseContext context, IMapper mapper)
        {
            _Context = context;
            _mapper = mapper;
        }

        public BaseDto<CreateCatalogType> Create(CreateCatalogType command)
        {
            throw new System.NotImplementedException();
        }

        public BaseDto<EditCatalogType> Edit(EditCatalogType command)
        {
            throw new System.NotImplementedException();
        }

        public BaseDto<CatalogTypeViewModel> Get(long id)
        {
            var catalogType = _Context.CatalogTypes
                .FirstOrDefault(c => c.Id == id);

           

           var catalogMap= _mapper.Map<CatalogTypeViewModel>(catalogType);


            var resualt = new BaseDto<CatalogTypeViewModel>(catalogMap,true);


            return resualt;
        }

        public PaginatedItemDto<CatalogTypeViewModel> Get(long? parentid, int pageindex, int pagesize)
        {
            throw new System.NotImplementedException();
        }

        public BaseDto Remove(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}

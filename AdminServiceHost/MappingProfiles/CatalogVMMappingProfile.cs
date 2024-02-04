using AdminServiceHost.ViewModels.Catalogs;
using AutoMapper;
using TopTaz.Application.CatalogApplication.Dtos;

namespace AdminServiceHost.MappingProfiles
{
    public class CatalogVMMappingProfile:Profile
    {
        public CatalogVMMappingProfile()
        {
            CreateMap<CatalogTypeDto, CatalogTypeViewModel>().ReverseMap();
        }
    }
}

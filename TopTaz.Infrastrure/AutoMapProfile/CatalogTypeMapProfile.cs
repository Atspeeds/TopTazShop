using AutoMapper;
using TopTaz.Application.CatalogApplication.Dtos;
using TopTaz.Domain.CatalogAgg;

namespace TopTaz.Infrastrure.AutoMapProfile
{
    public class CatalogTypeMapProfile : Profile
    {
        public CatalogTypeMapProfile()
        {
            CreateMap<CatalogType, CatalogTypeViewModel>().ReverseMap();
        }

    }
}

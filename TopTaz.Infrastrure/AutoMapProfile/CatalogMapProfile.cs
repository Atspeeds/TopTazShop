using AutoMapper;
using TopTaz.Application.CatalogApplication.Dtos;
using TopTaz.Domain.CatalogAgg;

namespace TopTaz.Infrastrure.AutoMapProfile
{
    public class CatalogMapProfile : Profile
    {
        public CatalogMapProfile()
        {

            //بهینه تره فقط میره تعداد و از دیتابیس میاره معمولی همه رو لود میکنه رو حافظه  بعد تعداد میده
            CreateMap<CatalogType, CatalogTypeDto>().ReverseMap();

            CreateMap<CatalogType, CatalogTypeListDto>()
                .ForMember(dest => dest.SubTypeCount, option =>
                 option.MapFrom(src => src.ChildCatalogType.Count));


            CreateMap<CatalogType, MenoItemDto>()
               .ForMember(dest => dest.Name, opt =>
                opt.MapFrom(src => src.Type))
               .ForMember(dest => dest.ParentId, opt =>
                opt.MapFrom(src => src.ParentCatalogTypeId))
               .ForMember(dest => dest.SubMenue, opt =>
               opt.MapFrom(src => src.ChildCatalogType));

            CreateMap<CatalogItemFeature, CatalogItemFeatureDto>().ReverseMap();
            CreateMap<CatalogItemImage, CatalogItemImageDto>().ReverseMap();

            CreateMap<CatalogItem, CatalogItemDto>()
               .ForMember(dest => dest.Features, opt =>
               opt.MapFrom(src => src.catalogItemFeatures))
                .ForMember(dest => dest.Images, opt =>
                opt.MapFrom(src => src.CatalogItemImages)).ReverseMap();

            CreateMap<CatalogBrand, CatalogBrandDto>().ReverseMap();
            CreateMap<CatalogType, CatalogTypeDto>().ReverseMap();

        }

    }
}

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

        }

    }
}

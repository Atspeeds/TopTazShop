using FluentValidation;
using System.Collections.Generic;
using TopTaz.Domain.CatalogAgg;

namespace TopTaz.Application.CatalogApplication.Dtos
{
    public class CatalogItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public long CatalogTypeId { get; set; }
        public long CatalogBrandId { get; set; }
        //موجودی انبار
        public int AvailableStock { get; set; }
        //ظرفیت موجودی انبار 
        public int RestockThreshold { get; set; }
        //محدودیت سفارش کالا
        public int MaxStockThreshold { get; set; }

        public List<CatalogItemFeatureDto>Features { get; set; }
        public List<CatalogItemImageDto> Images { get; set; }


    }
    public class AddNewCatalogItemDtoValidator : AbstractValidator<CatalogItemDto>
    {
        public AddNewCatalogItemDtoValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("نام کاتالوگ اجباری است");
            RuleFor(x => x.Name).Length(2, 100);
            RuleFor(x => x.Description).NotNull().WithMessage("توضیحات نمی تواند خالی باشد");
            RuleFor(x => x.AvailableStock).InclusiveBetween(0, int.MaxValue);
            RuleFor(x => x.Price).InclusiveBetween(0, int.MaxValue);
            RuleFor(x => x.Price).NotNull();
        }
    }
}

using System.Collections.Generic;
using TopTaz.Domain.FrameWorkDomain;

namespace TopTaz.Domain.CatalogAgg
{
    [Auditable]
    public class CatalogItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public long CatalogTypeId { get; set; }
        public CatalogType CatalogType { get; set; }
        public long CatalogBrandId { get; set; }
        public CatalogBrand CatalogBrand { get; set; }
        //موجودی انبار
        public int AvailableStock { get; set; }
        //ظرفیت موجودی انبار 
        public int RestockThreshold { get; set; }
        //محدودیت سفارش کالا
        public int MaxStockThreshold { get; set; }

        public ICollection<CatalogItemFeature> catalogItemFeatures { get; set; }
        public ICollection<CatalogItemImage> CatalogItemImages { get; set; }

    }
}

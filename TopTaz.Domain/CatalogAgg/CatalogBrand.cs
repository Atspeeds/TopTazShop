using TopTaz.Domain.FrameWorkDomain;

namespace TopTaz.Domain.CatalogAgg
{
    [Auditable]
    public  class CatalogBrand
    {
        public long Id { get; set; }
        public string Brand { get; set; }
    }
}

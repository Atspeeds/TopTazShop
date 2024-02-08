using TopTaz.Domain.FrameWorkDomain;

namespace TopTaz.Domain.CatalogAgg
{
    [Auditable]
    public class CatalogItemImage
    {
        public long Id { get; set; }
        public string Src { get; set; }
        public long CatalogItemId { get; set; }
        public CatalogItem CatalogItem { get; set; }
    }
}

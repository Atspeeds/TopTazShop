using TopTaz.Domain.FrameWorkDomain;

namespace TopTaz.Domain.CatalogAgg
{
    [Auditable]
    public class CatalogItemFeature
    {
        public long Id { get; set; }
        public string Group { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public long CatalogItemId { get; set; }
        public CatalogItem CatalogItem { get; set; }
    }
}

using System.Collections;
using System.Collections.Generic;
using TopTaz.Domain.FrameWorkDomain;

namespace TopTaz.Domain.CatalogAgg
{
    [Auditable]
    public class CatalogType
    {
        public long Id { get; set; }
        public string Type { get; set; }
        //Relation
        public long? ParentCatalogTypeId { get; set; }
        public CatalogType ParentCatalogType { get; set; }

        public ICollection<CatalogType> ChildCatalogType { get; set; }

    }
}

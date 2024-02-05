using System.Collections.Generic;

namespace TopTaz.Application.CatalogApplication.Dtos
{
    public class MenoItemDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public List<MenoItemDto> SubMenue { get; set; }
    }
}

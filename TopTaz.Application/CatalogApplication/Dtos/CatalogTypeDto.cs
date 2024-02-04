namespace TopTaz.Application.CatalogApplication.Dtos
{
    public class CatalogTypeDto
    {

        public long Id { get; set; }
        public string Type { get; set; }
        public long? ParentCatalogTypeId { get; set; }
    }
}

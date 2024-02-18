namespace TopTaz.Application.CatalogApplication.Dtos
{
    public class CatalogItemsListDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public int MaxStockThreshold { get; set; }
        public int RestockThreshold { get; set; }
        public int AvailableStock { get; set; }
    }
}

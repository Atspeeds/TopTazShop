namespace TopTaz.Application.BasketApplication.Dto
{
    public class BasketItemDto
    {
        public long Id { get; set; }
        public long CatalogItemid { get; set; }
        public string CatalogName { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public int DiscountAmount { get; set; }

    }

}

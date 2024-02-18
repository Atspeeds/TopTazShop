using TopTaz.Domain.CatalogAgg;

namespace TopTaz.Domain.BasketAgg
{
    public class BasketItem
    {
        public int Id { get; set; }
        public int UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public int CatalogItemId { get; private set; }
        public CatalogItem CatalogItem { get; private set; }
        public int BasketId { get; private set; }
        public BasketItem(int catalogItemId, int quantity, int unitPrice)
        {
            CatalogItemId = catalogItemId;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }
    }

}

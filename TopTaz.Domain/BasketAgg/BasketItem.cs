using TopTaz.Domain.CatalogAgg;
using TopTaz.Domain.FrameWorkDomain;

namespace TopTaz.Domain.BasketAgg
{
    [Auditable]
    public class BasketItem
    {
        public long Id { get; set; }
        public int UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public long CatalogItemId { get; private set; }
        public CatalogItem CatalogItem { get; private set; }
        public long BasketId { get; private set; }
        public BasketItem(long catalogItemId, int quantity, int unitPrice)
        {
            CatalogItemId = catalogItemId;
            UnitPrice = unitPrice;
            SetQuantity(quantity);
        }

        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }

}

using TopTaz.Domain.FrameWorkDomain;

namespace TopTaz.Domain.OrderAgg
{
    [Auditable]
    public class OrderItem
    {
        public long Id { get; set; }
        public long CatalogItemId { get; private set; }
        public string ProductName { get; private set; }
        public string PictureUri { get; private set; }
        public int UnitPrice { get; private set; }
        public int Units { get; private set; }
        public OrderItem(long catalogItemId, string productName, string pictureUri, int unitPrice, int units)
        {
            CatalogItemId = catalogItemId;
            ProductName = productName;
            PictureUri = pictureUri;
            UnitPrice = unitPrice;
            Units = units;
        }


        //ef core
        public OrderItem()
        {

        }
    }
}

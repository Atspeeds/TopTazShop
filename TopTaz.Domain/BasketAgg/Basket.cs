using System.Collections.Generic;
using System.Linq;
using TopTaz.Domain.FrameWorkDomain;

namespace TopTaz.Domain.BasketAgg
{
    [Auditable]
    public class Basket
    {
        public long Id { get; set; }
        public string BuyerId { get; private set; }
        private readonly List<BasketItem> _items = new List<BasketItem>();

        public ICollection<BasketItem> Items => _items.AsReadOnly();
        public Basket(string buyerId)
        {
            this.BuyerId = buyerId;
        }

        public void AddItem(long catalogItemId, int quantity, int unitPrice)
        {
            if (!Items.Any(p => p.CatalogItemId == catalogItemId))
            {
                _items.Add(new BasketItem(catalogItemId, quantity, unitPrice));
                return;
            }
            var existingItem = Items.FirstOrDefault(p => p.CatalogItemId == catalogItemId);
            existingItem.AddQuantity(quantity);
        }


    }

}

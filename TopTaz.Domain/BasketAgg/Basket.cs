using System.Collections.Generic;
using System.Linq;
using TopTaz.Domain.DiscountAgg;
using TopTaz.Domain.FrameWorkDomain;

namespace TopTaz.Domain.BasketAgg
{
    [Auditable]
    public class Basket
    {
        public long Id { get; set; }
        public string BuyerId { get; private set; }

        public int DiscountAmount { get; private set; } = 0;
        public Discount AppliedDiscount { get; private set; }
        public long? AppliedDiscountId { get; private set; }


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

        public int TotalPrice()
        {
            int totalPrice = _items.Sum(p => p.UnitPrice * p.Quantity);
            totalPrice -= AppliedDiscount.GetDiscountAmount(totalPrice);
            return totalPrice;
        }

        public int TotalPriceWithOutDiescount()
        {
            int totalPrice = _items.Sum(p => p.UnitPrice * p.Quantity);
            return totalPrice;
        }

        public void ApplyDiscountCode(Discount discount)
        {
            this.AppliedDiscount = discount;
            this.AppliedDiscountId = discount.Id;
            this.DiscountAmount = discount.GetDiscountAmount(TotalPriceWithOutDiescount());
        }

        public void RemoveDescount()
        {
            AppliedDiscount = null;
            AppliedDiscountId = null;
            DiscountAmount = 0;
        }

    }

}

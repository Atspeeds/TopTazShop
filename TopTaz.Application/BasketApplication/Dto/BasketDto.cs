using System.Collections.Generic;
using System.Linq;

namespace TopTaz.Application.BasketApplication.Dto
{
    public class BasketDto
    {
        public long Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();

        public BasketDto()
        {
        }

        public BasketDto(long id, string buyerId, List<BasketItemDto> items)
        {
            Id = id;
            BuyerId = buyerId;
            Items = items;
        }

        public BasketDto(long id, string buyerId)
        {
            Id = id;
            BuyerId = buyerId;
        }
        public int Total()
        {
            if (Items.Count > 0)
            {
                return Items.Sum(p => p.UnitPrice * p.Quantity);
            }
            return 0;
        }

    }

}

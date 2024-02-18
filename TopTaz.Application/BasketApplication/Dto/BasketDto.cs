using System.Collections.Generic;

namespace TopTaz.Application.BasketApplication.Dto
{
    public class BasketDto
    {
        public long Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();

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
    }

}

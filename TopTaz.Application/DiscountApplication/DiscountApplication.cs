using System.Collections.Generic;
using System.Linq;
using TopTaz.Application.ContextACL;
using TopTaz.Application.DiscountApplication.Dto;
using TopTaz.Domain.DiscountAgg;

namespace TopTaz.Application.DiscountApplication
{
    public class DiscountApplication : IDiscountApplication
    {
        private readonly IDataBaseContext _context;

        public DiscountApplication(IDataBaseContext context)
        {
            _context = context;
        }

        public void Create(AddNewDiscountDto command)
        {

            var newdiscount = new Discount()
            {
                Name = command.Name,
                CouponCode = command.CouponCode,
                DiscountAmount = command.DiscountAmount,
                DiscountLimitationId = command.DiscountLimitationId,
                DiscountPercentage = command.DiscountPercentage,
                DiscountTypeId = command.DiscountTypeId,
                EndDate = command.EndDate,
                RequiresCouponCode = command.RequiresCouponCode,
                StartDate = command.StartDate,
                UsePercentage = command.UsePercentage,
            };

            if (command.AppliedToCatalogItem is not null)
            {
                var catalogItems = _context.CatalogItems
                    .Where(x => command.AppliedToCatalogItem
                    .Contains(x.Id)).ToList();
                newdiscount.CatalogItems = catalogItems;
            }

            _context.Discounts.Add(newdiscount);
            _context.SaveChanges();

        }

        public List<CatalogItemDto> SearchCatalog(string SearchKey)
        {
            var query = _context.CatalogItems
                .Select(x => new CatalogItemDto()
                {
                    Id = x.Id,
                    Name = x.Name
                }).AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchKey))
                query = query.Where(x => x.Name.Contains(SearchKey));


            var result = query.OrderByDescending(x => x.Id).ToList();

            return result;

        }

    }

}

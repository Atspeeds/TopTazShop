using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TopTaz.Application.ContextACL;
using TopTaz.Application.DiscountApplication.Dto;
using TopTaz.Application.DtoModel;
using TopTaz.Domain.DiscountAgg;
using TopTaz.Domain.UserAgg;
using TT.FrameWork.Application;

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

        public bool ApplyDiscountInBasket(string CoponCode, long BasketId)
        {
            var basket = _context.Baskets
                .Include(p => p.Items)
                .Include(p => p.AppliedDiscount)
                .FirstOrDefault(p => p.Id == BasketId);

            var discount = _context.Discounts.Where(p => p.CouponCode.Equals(CoponCode))
                .FirstOrDefault();

            basket.ApplyDiscountCode(discount);
            _context.SaveChanges();
            return true;
        }
        public BaseDto IsDiscountValid(string couponCode, User user)
        {
            var discount = _context.Discounts
                .Where(p => p.CouponCode.Equals(couponCode)).FirstOrDefault();
            if (discount == null)
            {
                return new BaseDto(iSsuccess: false,
                    messages: new List<string> { "کد تخفیف معتبر نمی باشد" });
            }

            var now = DateTime.UtcNow;
            if (discount.StartDate.HasValue)
            {
                var startDate = DateTime.SpecifyKind(discount.StartDate.Value, DateTimeKind.Utc);
                if (startDate.CompareTo(now) > 0)
                    return new BaseDto(false, new List<string>
                    { "هنوز زمان استفاده از این کد تخفیف فرا نرسیده است" });
            }
            if (discount.EndDate.HasValue)
            {
                var endDate = DateTime.SpecifyKind(discount.EndDate.Value, DateTimeKind.Utc);
                if (endDate.CompareTo(now) < 0)
                    return new BaseDto(false, new List<string> { "کد تخفیف منقضی شده است" });
            }

            var checkLimit = CheckDiscountLimitations(discount, user);

            if (checkLimit.ISsuccess == false)
                return checkLimit;
            return new BaseDto(true, null);

        }

        private BaseDto CheckDiscountLimitations(Discount discount, User user)
        {
            switch (discount.DiscountLimitation)
            {
                case DiscountLimitationType.Unlimited:
                    {
                        return new BaseDto(true, null);
                    }
                case DiscountLimitationType.NTimesOnly:
                    {
                        var totalUsage = GetAllDiscountUsageHistory(discount.Id, null, 0, 1).Models.Count();
                        if (totalUsage < discount.LimitationTimes)
                        {
                            return new BaseDto(true, null);

                        }
                        else
                        {
                            return new BaseDto(false, new List<string> { "ظرفیت استفاده از این کد تخفیف تکمیل شده است" });

                        }
                    }
                case DiscountLimitationType.NTimesPerCustomer:
                    {
                        if (user != null)
                        {
                            var totalUsage = GetAllDiscountUsageHistory(discount.Id, user.Id, 0, 1).Models.Count();
                            if (totalUsage < discount.LimitationTimes)
                            {
                                return new BaseDto(true, null);
                            }
                            else
                            {
                                return new BaseDto(false, new List<string> { "تعدادی که شما مجاز به استفاده از این تخفیف بوده اید به پایان رسیده است" });
                            }
                        }
                        else
                        {
                            return new BaseDto(true, null);
                        }
                    }
                default:
                    break;
            }
            return new BaseDto(true, null);

        }

        public bool RemoveDiscountFromBasket(long BasketId)
        {
            var basket = _context.Baskets.Find(BasketId);

            basket.RemoveDescount();
            _context.SaveChanges();
            return true;
        }
        public void InsertDiscountUsageHistory(long DiscountId, long OrderId)
        {
            var order = _context.Orders.Find(OrderId);
            var discount = _context.Discounts.Find(DiscountId);

            DiscountUsageHistory discountUsageHistory = new DiscountUsageHistory()
            {
                CreatedOn = DateTime.Now,
                Discount = discount,
                Order = order,
            };
            _context.DiscountUsageHistories.Add(discountUsageHistory);
            _context.SaveChanges();
        }

        public DiscountUsageHistory GetDiscountUsageHistoryById(long discountUsageHistoryId)
        {
            if (discountUsageHistoryId == 0)
                return null;

            var discountUsage = _context.DiscountUsageHistories.Find(discountUsageHistoryId);
            return discountUsage;
        }


        public PaginatedItemDto<DiscountUsageHistory> GetAllDiscountUsageHistory(long? discountId, string userId, int pageIndex, int pageSize)
        {
            var query = _context.DiscountUsageHistories.AsQueryable();

            if (discountId.HasValue && discountId.Value > 0)
                query = query.Where(p => p.DiscountId == discountId.Value);

            if (!string.IsNullOrEmpty(userId))
                query = query.Where(p => p.Order != null && p.Order.UserId == userId);

            query = query.OrderByDescending(c => c.CreatedOn);
            var pagedItems = query.PagedResult(pageIndex, pageSize, out int rowCount);
            return new PaginatedItemDto<DiscountUsageHistory>(query.ToList(), pageIndex, rowCount,pageSize);
        }
    }

}

using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System;
using System.Threading.Tasks;
using TopTaz.Application.DiscountApplication.Dto;
using MD.PersianDateTime.Standard;

namespace AdminServiceHost.Binders
{
    public class DiscountEntityBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }


            string FieldName = bindingContext.FieldName;


            AddNewDiscountDto discountDto = new AddNewDiscountDto()
            {
                CouponCode = bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discountDto.CouponCode)}").Values.ToString(),


                DiscountAmount = int.Parse(bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discountDto.DiscountAmount)}").Values.ToString()),

                DiscountLimitationId = int.Parse(bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discountDto.DiscountLimitationId)}").Values.ToString()),


                DiscountPercentage = int.Parse(bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discountDto.DiscountLimitationId)}").Values.ToString()),

                DiscountTypeId = int.Parse(bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discountDto.DiscountTypeId)}").Values.ToString()),
                LimitationTimes = int.Parse(bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discountDto.LimitationTimes)}").Values.ToString()),

                UsePercentage = bool.Parse(bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discountDto.UsePercentage)}").FirstValue.ToString()),

                Name = bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discountDto.Name)}").Values.ToString(),

                RequiresCouponCode = bool.Parse(bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discountDto.RequiresCouponCode)}").FirstValue.ToString()),

                EndDate = PersianDateTime.Parse(bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discountDto.EndDate)}").Values.ToString()),

                StartDate = PersianDateTime.Parse(bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discountDto.StartDate)}").Values.ToString()),
            };


            var appliedToCatalogItem = bindingContext.ValueProvider.GetValue("model.appliedToCatalogItem");

            if (!string.IsNullOrEmpty(appliedToCatalogItem.Values))
            {
                discountDto.AppliedToCatalogItem =
                bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discountDto.AppliedToCatalogItem)}")
                .Values.ToString().Split(',').Select(x => long.Parse(x)).ToList();
            }


            bindingContext.Result = ModelBindingResult.Success(discountDto);
            return Task.CompletedTask;
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.Models.ViewModel.Baskets;
using System;
using System.Linq;
using TopTaz.Application.BasketApplication.BasketQuery;
using TopTaz.Application.BasketApplication.Dto;
using TopTaz.Application.OrderApplication;
using TopTaz.Application.PaymentsApplication;
using TopTaz.Application.UsersApplication;
using TopTaz.Domain.OrderAgg;
using TopTaz.Domain.UserAgg;
using TT.FrameWork.Presentations;

namespace ServiceHost.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IBasketQuery _basketQuery;
        private readonly IUserAddressApplication _userAddressApplication;
        private readonly IOrderApplication _orderApplication;
        private readonly IPaymentApplication _paymentApplication;
        private string UserId = null;
        public BasketController(SignInManager<User> signInManager,
            IBasketQuery basketQuery,
            IUserAddressApplication userAddressApplication,
            IOrderApplication orderApplication,
            IPaymentApplication paymentApplication)
        {
            _signInManager = signInManager;
            _basketQuery = basketQuery;
            _userAddressApplication = userAddressApplication;
            _orderApplication = orderApplication;
            _paymentApplication = paymentApplication;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            var data = GetOrSetBasket();
            return View(data);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Index(long CatalogitemId, int quantity = 1)
        {
            var basket = GetOrSetBasket();
            _basketQuery.AddItemToBasket(basket.Id, CatalogitemId, quantity);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RemoveItemFromBasket(long ItemId)
        {
            _basketQuery.RemoveItemFromBasket(ItemId);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult setQuantity(long basketItemId, int quantity)
        {
            return Json(_basketQuery.SetQuantities(basketItemId, quantity));
        }

        [HttpGet]
        public IActionResult ShippingPayment()
        {
            ShippingPaymentViewModel model = new ShippingPaymentViewModel();
            string userId = ClaimUtility.GetUserId(User);
            model.Basket = _basketQuery.GetBasketForUser(userId);
            model.UserAddresses = _userAddressApplication.GetAddresses(userId);
            return View(model);
        }

        [HttpPost]
        public IActionResult ShippingPayment(long Address, PaymentMethod PaymentMethod)
        {
            string userId = ClaimUtility.GetUserId(User);
            var basket = _basketQuery.GetBasketForUser(userId);
            long orderId = _orderApplication.CreateOrder(basket.Id, Address, PaymentMethod);
            if (PaymentMethod == PaymentMethod.OnlinePaymnt)
            {
                //ثبت پرداخت
                var payment = _paymentApplication.PayForOrder(orderId);
                //ارسال به درگاه پرداخت
                return RedirectToAction("Index", "Pay", new { PaymentId = payment.Id });
            }
            else
            {
                //برو به صفحه سفارشات من
                return RedirectToAction("Index", "Orders", new { area = "customers" });
            }
           
        }


        private BasketDto GetOrSetBasket()
        {
            if (_signInManager.IsSignedIn(User))
            {
                UserId = ClaimUtility.GetUserId(User);

                return _basketQuery.GetOrCreateBasketForUser(UserId);
            }
            else
            {
                SetCookiesForBasket();
                return _basketQuery.GetOrCreateBasketForUser(UserId);
            }
        }

        private void SetCookiesForBasket()
        {
            string basketCookieName = "BasketId";
            if (Request.Cookies.ContainsKey(basketCookieName))
            {
                UserId = Request.Cookies[basketCookieName];
            }
            if (UserId != null) return;
            UserId = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions { IsEssential = true };
            cookieOptions.Expires = DateTime.Today.AddYears(2);
            Response.Cookies.Append(basketCookieName, UserId, cookieOptions);


        }

    }
}

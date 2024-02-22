using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TopTaz.Application.BasketApplication.BasketQuery;
using TopTaz.Application.BasketApplication.Dto;
using TopTaz.Domain.UserAgg;
using TT.FrameWork.Presentations;

namespace ServiceHost.Controllers
{
    public class BasketController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IBasketQuery _basketQuery;
        private string UserId = null;
        public BasketController(SignInManager<User> signInManager, IBasketQuery basketQuery)
        {
            _signInManager = signInManager;
            _basketQuery = basketQuery;
        }

        public IActionResult Index()
        {
            var data = GetOrSetBasket();
            return View(data);
        }


        [HttpPost]
        public IActionResult Index(long CatalogitemId, int quantity = 1)
        {
            var basket = GetOrSetBasket();
            _basketQuery.AddItemToBasket(basket.Id, CatalogitemId, quantity);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult RemoveItemFromBasket(long ItemId)
        {
            _basketQuery.RemoveItemFromBasket(ItemId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult setQuantity(long basketItemId, int quantity)
        {
            return Json(_basketQuery.SetQuantities(basketItemId, quantity));
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

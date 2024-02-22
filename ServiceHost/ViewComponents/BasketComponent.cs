using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TopTaz.Application.BasketApplication.BasketQuery;
using TopTaz.Application.BasketApplication.Dto;
using TT.FrameWork.Presentations;

namespace WebSite.EndPoint.Models.ViewComponents
{
    public class BasketComponent : ViewComponent
    {
        private readonly IBasketQuery basketService;
        public BasketComponent(IBasketQuery basketService)
        {
            this.basketService = basketService;
        }
        private ClaimsPrincipal userClaimsPrincipal => ViewContext?.HttpContext?.User;
        public IViewComponentResult Invoke()
        {
            BasketDto basket = null;
            if (User.Identity.IsAuthenticated)
            {
                basket = basketService.GetBasketForUser(ClaimUtility.GetUserId(userClaimsPrincipal));
            }
            else
            {
                string basketCookieName = "BasketId";
                if (Request.Cookies.ContainsKey(basketCookieName))
                {
                    var buyerId = Request.Cookies[basketCookieName];
                    basket = basketService.GetBasketForUser(buyerId);
                }

            }
            return View(viewName: "BasketComponent", model: basket);
        }
    }
}

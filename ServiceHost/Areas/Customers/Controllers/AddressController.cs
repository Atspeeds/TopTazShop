using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TopTaz.Application.UsersApplication;
using TopTaz.Application.UsersApplication.Dto;
using TT.FrameWork.Presentations;

namespace ServiceHost.Areas.Customers.Controllers
{
    [Authorize]
    [Area("Customers")]
    public class AddressController : Controller
    {
        private readonly IUserAddressApplication _userAddressApplication;

        public AddressController(IUserAddressApplication userAddressApplication)
        {
            _userAddressApplication = userAddressApplication;
        }

        public IActionResult Index()
        {
            var model = _userAddressApplication.GetAddresses(ClaimUtility.GetUserId(User));
            return View();
        }
        [HttpGet]
        public IActionResult AddNewAddress()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewAddress(AddUserAddressDto model)
        {
            if (!ModelState.IsValid)
                return View();

            var userClaimid=ClaimUtility.GetUserId(User);
            model.UserId= userClaimid;

            _userAddressApplication.AddAddress(model);

            return RedirectToAction("Index");
        }

    }
}

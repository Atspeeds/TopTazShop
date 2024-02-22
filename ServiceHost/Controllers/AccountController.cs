using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.Models.ViewModel.AccountViewModel;
using TopTaz.Application.BasketApplication.BasketQuery;
using TopTaz.Domain.UserAgg;

namespace ServiceHost.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IBasketQuery _basketQuery;

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager,IBasketQuery basketQuery)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _basketQuery = basketQuery;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModels registerModel)
        {
            if (!ModelState.IsValid) return View(registerModel);

            var users = new User()
            {
                FullName = registerModel.FullName,
                Email = registerModel.Email,
                PhoneNumber = registerModel.PhoneNumber,
            };

            var resualt = _userManager.CreateAsync(users, registerModel.Password).Result;

            if (resualt.Succeeded)
            {
                var user = _userManager.FindByNameAsync(registerModel.Email).Result;

                TransferBasketForuser(user.Id);
                _signInManager.SignInAsync(user, true).Wait();

                return RedirectToAction(nameof(Profile));
            }

            foreach (var item in resualt.Errors)
            {
                ModelState.AddModelError(item.Code, item.Description);
            }


            return View(registerModel);
        }

        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);

            var userFind = _userManager.FindByNameAsync(loginViewModel.Email).Result;
            if (userFind is null)
            {
                ModelState.AddModelError("", "کاربری یافت نشد");
                return View(loginViewModel);
            }

            _signInManager.SignOutAsync();

            var resualt = _signInManager.PasswordSignInAsync(userFind, loginViewModel.Password, loginViewModel.IsPersistent, true).Result;

            if (resualt.Succeeded)
            {
                TransferBasketForuser(userFind.Id);
                return Redirect(loginViewModel.ReturnUrl);
            }

            return View(loginViewModel);

        }


        private void TransferBasketForuser(string userId)
        {
            string cookieName = "BasketId";
            if (Request.Cookies.ContainsKey(cookieName))
            {
                var anonymousId = Request.Cookies[cookieName];
                _basketQuery.TransferBasket(anonymousId, userId);
                Response.Cookies.Delete(cookieName);
            }
        }
    }
}

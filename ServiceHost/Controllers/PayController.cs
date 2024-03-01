//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Newtonsoft.Json;
//using RestSharp;
//using System;
//using System.Threading.Tasks;
//using TopTaz.Application.PaymentsApplication;
//using TT.FrameWork.Presentations;
//using ZarinPal.Class;
//using Dto.Payment;

//namespace ServiceHost.Controllers
//{
//    public class PayController : Controller
//    {
//        private  Payment _payment;
//        private readonly Authority _authority;
//        private readonly Transactions _transactions;


//        private readonly IConfiguration configuration;
//        private readonly IPaymentApplication paymentService;
//        private readonly string merchendId;

//        public PayController(IConfiguration configuration, IPaymentApplication paymentService)
//        {
//            this.configuration = configuration;
//            this.paymentService = paymentService;
//            merchendId = configuration["ZarinpalMerchendId"];


//            var expose = new Expose();
//            _payment = expose.CreatePayment();
//            _authority = expose.CreateAuthority();
//            _transactions = expose.CreateTransactions();

//        }


//        public async Task<IActionResult> Index(Guid PaymentId)
//        {
//            var payment = paymentService.GetPayment(PaymentId);
//            if (payment == null)
//            {
//                return NotFound();
//            }
//            string userId = ClaimUtility.GetUserId(User);
//            if (userId != payment.Userid)
//            {
//                return BadRequest();
//            }
//            string callbackUrl = Url.Action(nameof(Verify), "pay", new { payment.Id }, protocol: Request.Scheme);
//            var resultZarinpalRequest = await _payment.Request(new DtoRequest()
//            {
//                Amount = payment.Amount,
//                CallbackUrl = callbackUrl,
//                Description = payment.Description,
//                Email = payment.Email,
//                MerchantId = merchendId,
//                Mobile = payment.PhoneNumber,
//            }, Payment.Mode.zarinpal
//                );

//            return Redirect($"https://zarinpal.com/pg/StartPay/{resultZarinpalRequest.Authority}");
//        }


//        public IActionResult Verify(Guid Id, string Authority)
//        {
//            string Status = HttpContext.Request.Query["Status"];

//            if (Status != "" && Status.ToString().ToLower() == "ok"
//                && Authority != "")
//            {
//                var payment = paymentService.GetPayment(Id);
//                if (payment == null)
//                {
//                    return NotFound();
//                }

//                var verification = _payment.Verification(new DtoVerification
//                {
//                    Amount = payment.Amount,
//                    Authority = Authority,
//                    MerchantId = merchendId,
//                }, Payment.Mode.zarinpal).Result;

//                var client = "https://www.zarinpal.com/pg/rest/WebGate/PaymentVerification.json";
//                var request = new RestRequest(client,Method.Post);
//                request.AddHeader("Content-Type", "application/json");
//                request.AddParameter("application/json", $"{{\"MerchantID\" :\"{merchendId}\",\"Authority\":\"{Authority}\",\"Amount\":\"{payment.Amount}\"}}", ParameterType.RequestBody);
                
  
//                VerificationPayResultDto verification =
//                    JsonConvert.DeserializeObject<VerificationPayResultDto>(response.Content);

//                if (verification.Status == 100)
//                {
//                    bool verifyResult = paymentService.VerifyPayment(Id, Authority, verification.RefID);
//                    if (verifyResult)
//                    {
//                        return Redirect("/customers/orders");
//                    }
//                    else
//                    {
//                        TempData["message"] = "پرداخت انجام شد اما ثبت نشد";
//                        return RedirectToAction("checkout", "basket");
//                    }
//                }
//                else
//                {
//                    TempData["message"] = "پرداخت شما ناموفق بوده است . لطفا مجددا تلاش نمایید یا در صورت بروز مشکل با مدیریت سایت تماس بگیرید .";
//                    return RedirectToAction("checkout", "basket");
//                }

//            }
//            TempData["message"] = "پرداخت شما ناموفق بوده است .";
//            return RedirectToAction("checkout", "basket");
//        }
//    }
//    public class VerificationPayResultDto
//    {
//        public int Status { get; set; }
//        public long RefID { get; set; }
//    }
//}

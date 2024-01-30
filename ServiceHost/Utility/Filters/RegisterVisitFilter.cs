using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using TopTaz.Application.Dtos;
using TopTaz.Application.VisitorApplication.Dtos;
using TopTaz.Application.VisitorApplication.Visitors;
using UAParser;

namespace ServiceHost.Utility.Filters
{
    public class RegisterVisitFilter : IActionFilter
    {
        private readonly IVisitorApplication _visitorApplication;

        public RegisterVisitFilter(IVisitorApplication visitorApplication)
        {
            _visitorApplication = visitorApplication;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            var cookieVisitorId = context.HttpContext.Request.Cookies["VisitorId"];
         
            try
            {
                var ip = context.HttpContext.Connection.RemoteIpAddress.ToString();
                var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;

                if (actionDescriptor != null)
                {
                    var actionName = actionDescriptor.ActionName;
                    var controllerName = actionDescriptor.ControllerName;
                    var userAgent = context.HttpContext.Request.Headers["User-Agent"];
                    var uaParser = Parser.GetDefault();
                    var clientInfo = uaParser.Parse(userAgent);
                    var referer = context.HttpContext.Request.Headers["Referer"].ToString();
                    var currentUrl = context.HttpContext.Request.Path;
                    var request = context.HttpContext.Request;
                    var visitorId = cookieVisitorId;

                    var visitDto = CreateVisitDto(ip, actionName, controllerName, clientInfo, referer, currentUrl, request, visitorId);
                    _visitorApplication.Create(visitDto);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private CreateVisit CreateVisitDto(string ip, string actionName, string controllerName, ClientInfo clientInfo, string referer, string currentUrl, HttpRequest request, string visitorId)
        {
            return new CreateVisit
            {
                VisitorId = visitorId,
                Browser = new VisitorVersionDto
                {
                    Family = clientInfo.OS.Family,
                    Version = $"{clientInfo.OS.Major}.{clientInfo.OS.Minor}.{clientInfo.OS.Patch}.{clientInfo.OS.PatchMinor}"
                },
                CurrentLink = currentUrl,
                Device = new DeviceDto
                {
                    Brand = clientInfo.Device.Brand,
                    Family = clientInfo.Device.Family,
                    IsSpider = clientInfo.Device.IsSpider,
                    Model = clientInfo.Device.Model,
                },
                Ip = ip,
                Method = request.Method,
                OperationSystem = new VisitorVersionDto()
                {
                    Family = clientInfo.UA.Family,
                    Version = $"{clientInfo.UA.Major}.{clientInfo.UA.Minor}.{clientInfo.UA.Patch}"

                },
                PhysicalPath = $"{controllerName}/{actionName}",
                Protocol = request.Protocol,
                ReferrerLink = referer,
                
            };
        }
    }
}

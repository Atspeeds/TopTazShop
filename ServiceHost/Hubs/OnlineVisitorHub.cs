using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using TopTaz.Application.VisitorApplication.VisitorOnline;

namespace ServiceHost.Hubs
{
    public class OnlineVisitorHub : Hub
    {
        private readonly IVisitorOnlineApplication _visitorOnline;

        public OnlineVisitorHub(IVisitorOnlineApplication visitorOnline)
        {
            _visitorOnline = visitorOnline;
        }


        public override Task OnConnectedAsync()
        {
            string visitorId = Context.GetHttpContext().Request.Cookies["VisitorId"];
            _visitorOnline.Connected(visitorId);
            
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            string visitorId = Context.GetHttpContext().Request.Cookies["VisitorId"];
            _visitorOnline.Disconnected(visitorId);

            return base.OnDisconnectedAsync(exception);
        }


    }
}

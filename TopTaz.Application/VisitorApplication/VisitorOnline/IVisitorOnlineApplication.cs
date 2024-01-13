namespace TopTaz.Application.VisitorApplication.VisitorOnline
{
    public interface IVisitorOnlineApplication
    {
        bool Connected(string visitorId);
        bool Disconnected(string visitorId);
        long GetCountOnline();
    }
}

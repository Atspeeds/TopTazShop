using TopTaz.Application.VisitorApplication.Dtos;

namespace TopTaz.Application.VisitorApplication.Visitors
{
    public interface IVisitorApplication
    {
        bool Create(CreateVisit command);
    }
}

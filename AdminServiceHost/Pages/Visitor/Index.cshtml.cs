using Microsoft.AspNetCore.Mvc.RazorPages;
using TopTaz.Application.ReportsService.VisitorReports;

namespace AdminServiceHost.Pages.Visitor
{

    public class IndexModel : PageModel
    {
        private readonly IVisitorReport _visitorReport;

        public ResultTodayReportDto ResultTodayReport;

        public IndexModel(IVisitorReport visitorReport)
        {
            _visitorReport= visitorReport;

        }
        public void OnGet()
        {
            ResultTodayReport= _visitorReport.GetVisitor();
        }
    }
}

using System.Collections.Generic;

namespace TopTaz.Application.ReportsService.VisitorReports
{
    public class ResultTodayReportDto
    {
        public GeneralStatsDto GeneralStats { get; set; }
        public TodayDto Today { get; set; }
        public List<VisitorsDto> visitors { get; set; }
    }
}

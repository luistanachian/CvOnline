namespace Cv.Models
{
    public class CompanyMonthlyStatisticsModel
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int CountCandidates { get; set; }
        public int CountSearches { get; set; }
        public int CountClient { get; set; }
    }
}

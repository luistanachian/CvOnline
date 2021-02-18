namespace Cv.Models
{
    public class CompanyStatisticsByPeriodModel
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int CountCandidatesCreated { get; set; }
        public int CountCandidatesContracted { get; set; }
        public int CountCandidatesContractedOnClient { get; set; }

        public int CountSearchesCreated { get; set; }
        public int CountSearchesCompleted { get; set; }
        public int CountSearchesCanceledByClient { get; set; }
        public int CountSearchesCanceledByCompany { get; set; }
        public int CountClient { get; set; }
    }
}

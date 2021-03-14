namespace Cv.Models
{
    public class CompanyStatisticsByPeriodItem
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int CandidatesCreated { get; set; }
        public int CandidatesContracted { get; set; }
        public int CandidatesContractedOnClient { get; set; }

        public int SearchesCreated { get; set; }
        public int SearchesCompleted { get; set; }
        public int SearchesCanceledByClient { get; set; }
        public int SearchesCanceledByCompany { get; set; }

        public int ClientCreated { get; set; }
    }
}

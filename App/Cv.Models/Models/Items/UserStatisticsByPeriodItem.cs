namespace Cv.Models.Items
{
    public class UserStatisticsByPeriodItem
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int CandidatesCreated { get; set; }
        public int AssignedSearch { get; set; }
        public int AssignedCandidates { get; set; }
        public int AssignedCandidatesContracted { get; set; }
        public int AssignedCandidatesContractedOnClient { get; set; }
    }
}

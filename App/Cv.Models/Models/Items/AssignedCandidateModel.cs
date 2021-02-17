using System;

namespace Cv.Models.Models.Items
{
    public class AssignedCandidateModel
    {
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public string CandidateId { get; set; }
        public int EstimateAmount { get; set; }
        public string StartEstimateDate { get; set; }
        public string RelocateEstimateDate { get; set; }
        public string Comment { get; set; }
    }
}

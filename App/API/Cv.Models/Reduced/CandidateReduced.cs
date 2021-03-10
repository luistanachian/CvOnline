using Cv.Models.Enums;

namespace Cv.Models
{
    public class CandidateReduced
    {
        public string CandidateId { get; set; }
        public StatusCandiateEnum Status { get; set; }
        public string ClientOrSearchId { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public SeniorityEnum Seniority { get; set; }
    }
}
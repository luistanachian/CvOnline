using Cv.Models.Enums;

namespace Cv.Net5.API.Models
{
    public class CandidateSearch
    {
        public string companyId { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public int countryId { get; set; }
        public int stateId { get; set; }
        public StatusCandiateEnum? status { get; set; }
        public string name { get; set; }
        public string[] skills { get; set; }
    }
}
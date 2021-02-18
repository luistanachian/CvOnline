using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Cv.Models
{
    public class CompanyStatisticsModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string CompanyId { get; set; }
        public int CountCandidatesAvailable { get; set; }
        public int CountCandidatesTaken { get; set; }
        public int CountCandidatesContracted { get; set; }
        public int CountCandidatesContractedOnClient { get; set; }
        public int CountCandidatesBlacklist { get; set; }
        public int CountCandidatesDeleted { get; set; }

        public int CountSearchesActive { get; set; }
        public int CountSearchesPaused { get; set; }
        public int CountSearchesCompleted { get; set; }
        public int CountSearchesCanceledByClient { get; set; }
        public int CountSearchesCanceledByCompany { get; set; }

        public int CountClient { get; set; }
        public int CountClientBlackList { get; set; }
        public int CountClientDeleted { get; set; }
        public List<CompanyMonthlyStatisticsModel> MonthlyStatistics { get; set; }
        public List<CompanyAnnualStatisticsModel> AnnualStatistics { get; set; }
    }
}
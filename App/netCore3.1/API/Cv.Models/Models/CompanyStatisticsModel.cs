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
        public int CandidatesAvailable { get; set; }
        public int CandidatesTaken { get; set; }
        public int CandidatesContracted { get; set; }
        public int CandidatesContractedOnClient { get; set; }
        public int CandidatesBlacklist { get; set; }
        public int CandidatesDeleted { get; set; }

        public int SearchesActive { get; set; }
        public int SearchesPaused { get; set; }
        public int SearchesCompleted { get; set; }
        public int SearchesCanceledByClient { get; set; }
        public int SearchesCanceledByCompany { get; set; }

        public int Client { get; set; }
        public int ClientBlackList { get; set; }
        public int ClientDeleted { get; set; }
        public List<CompanyStatisticsByPeriodItem> StatisticsByPeriod { get; set; }
    }
}
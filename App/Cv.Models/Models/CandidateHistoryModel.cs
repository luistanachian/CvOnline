using Cv.Models.Models.Items;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Cv.Models.Models
{
    public class CandidateHistoryModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string CandidateId { get; set; }
        public List<EventItem> History { get; set; }
    }
}

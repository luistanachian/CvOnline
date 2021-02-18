using Cv.Models.Items;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Cv.Models
{
    public class UserStatisticsModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string UserId { get; set; }
        public List<UserStatisticsByPeriodItem> StatisticsByPeriod { get; set; }
    }
}

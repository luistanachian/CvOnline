using Cv.Models.Items;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Cv.Models
{
    class SearchHistoryModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string SearchId { get; set; }
        public List<EventItem> History { get; set; }
    }
}

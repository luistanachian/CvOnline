using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cv.Models
{
    public class StateModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int id { get; set; }
        public int country_id { get; set; }
        public string name { get; set; }
    }
}
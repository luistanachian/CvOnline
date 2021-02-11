using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cv.Models
{
    public class StateModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string IdState { get; set; }
        [BsonElement("codecountry")]
        public string CodeCountry { get; set; }
        [BsonElement("state")]
        public string State { get; set; }
    }
}

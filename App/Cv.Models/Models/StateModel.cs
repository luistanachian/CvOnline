using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cv.Models
{
    public class StateModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string IdState { get; set; }
        public string CodeCountry { get; set; }
        public string State { get; set; }
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cv.Models
{
    public class CountryModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string CodeCountry { get; set; }
        [BsonElement("country")]
        public string Country { get; set; }
    }
}

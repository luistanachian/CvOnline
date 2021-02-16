using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cv.Models
{
    public class GlobalLanguageModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string CodeLanguage { get; set; }
        public string Language { get; set; }
    }
}
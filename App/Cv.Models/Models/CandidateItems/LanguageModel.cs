using Cv.Models.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace Cv.Models
{
    public class LanguageModel
    {
        [BsonElement("cl")]
        public string CodeLanguage { get; set; }
        [BsonElement("ll")]
        public LevelLanguageEnum Level { get; set; }
    }
}
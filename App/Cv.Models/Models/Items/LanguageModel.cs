using Cv.Models.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace Cv.Models
{
    public class LanguageModel
    {
        public string CodeLanguage { get; set; }
        public LevelLanguageEnum Level { get; set; }
    }
}
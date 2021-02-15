using Cv.Models.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace Cv.Models
{
    public class EducationModel
    {
        [BsonElement("ie")]
        public string Institute { get; set; }
        [BsonElement("et")]
        public EducationTypeEnum EdutationType { get; set; }
        [BsonElement("sd")]
        public string YearEnd { get; set; }
        [BsonElement("ct")]
        public bool Current { get; set; }
        [BsonElement("te")]
        public string Title { get; set; }
        [BsonElement("cc")]
        public string CodeCountry { get; set; }
    }
}

using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Cv.Models
{
    public class TemporaryUserModel
    {
        [BsonElement("us")]
        public string User { get; set; }
        [BsonElement("ps")]
        public string Passeord { get; set; }
        [BsonElement("ed")]
        public DateTime EndDate { get; set; }
        [BsonElement("ec")]
        public int ErrorCounter { get; set; }

        [BsonElement("ep")]
        public bool EditPhoto { get; set; }
        [BsonElement("pd")]
        public bool EditPersonalData { get; set; }
        [BsonElement("er")]
        public bool EditRelocate { get; set; }
        [BsonElement("el")]
        public bool EditLanguages { get; set; }
        [BsonElement("es")]
        public bool EditPortfolios { get; set; }
        [BsonElement("ee")]
        public bool EditEducations { get; set; }
        [BsonElement("we")]
        public bool EditWorkExperiences { get; set; }
        [BsonElement("ws")]
        public bool EditSkills { get; set; }
    }
}

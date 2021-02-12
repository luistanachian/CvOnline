using Cv.Models.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Cv.Models
{
    public class SkillModel
    {
        [BsonElement("sk")]
        public string Skill { get; set; }
        [BsonElement("se")]
        public int Score { get; set; }
        [BsonElement("fu")]
        public FrequencyUsedEnum FrequencyUsed { get; set; }
        public int Years { get; set; }
        [BsonElement("ys")]
        public DateTime? LastUsed { get; set; }
        [BsonElement("ct")]
        public bool Current { get; set; }
    }
}
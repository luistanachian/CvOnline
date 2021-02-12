using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Cv.Models
{
    public class RelocateModel
    {
        [BsonElement("md")]
        public bool Married { get; set; }
        [BsonElement("cn")]
        public int Children { get; set; }
        [BsonElement("pt")]
        public bool Pet { get; set; }
        [BsonElement("ed")]
        public DateTime EstimateDate { get; set; }
        [BsonElement("cs")]
        public string Comments { get; set; }
    }
}

using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Cv.Models
{
    public class WorkExperienceModel
    {
        [BsonElement("rl")]
        public string Role { get; set; }
        [BsonElement("cy")]
        public string Company { get; set; }
        [BsonElement("sd")]
        public string StartDate { get; set; }
        [BsonElement("ed")]
        public string EndDate { get; set; }
        [BsonElement("ct")]
        public bool Current { get; set; }
        [BsonElement("lr")]
        public List<ReferenceModel> ListReferences { get; set; }
        [BsonElement("cs")]
        public List<CommentModel> Comments { get; set; }
    }
}

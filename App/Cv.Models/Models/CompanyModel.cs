using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Cv.Models.Models
{
    class CompanyModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string CompanyId { get; set; }
        [BsonElement("sd")]
        public DateTime StarDate { get; set; }
        [BsonElement("lo")]
        public string Logo { get; set; }
        [BsonElement("ne")]
        public string Name { get; set; }
        [BsonElement("do")]
        public string Document { get; set; }
        [BsonElement("em")]
        public List<string> EMails { get; set; }
        [BsonElement("ps")]
        public List<string> Phones { get; set; }
    }
}
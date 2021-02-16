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
        public DateTime StarDate { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public List<string> EMails { get; set; }
        public List<string> Phones { get; set; }
    }
}
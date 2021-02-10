using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cv.Models
{
    public class CountryModel
    {
        //public string Id { get; set; }
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Code { get; set; }
        [BsonElement("country")]
        public string Country { get; set; }
    }
}

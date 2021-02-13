using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Cv.Models
{
    public class CommentModel
    {
        [BsonElement("dt")]
        public DateTime Date { get; set; }
        [BsonElement("us")]
        public string User { get; set; }
        [BsonElement("ct")]
        public string Comment { get; set; }
    }
}

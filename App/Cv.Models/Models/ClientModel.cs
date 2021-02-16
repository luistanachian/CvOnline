using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Cv.Models.Models
{
    public class ClientModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string ClientId { get; set; }
        [BsonElement("cid")]
        public string CompanyId { get; set; }
        [BsonElement("sd")]
        public DateTime StarDate { get; set; }
        [BsonElement("ld")]
        public DateTime LastUpdate { get; set; }
        [BsonElement("bl")]
        public bool BlackList { get; set; }
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
        [BsonElement("sn")]
        public List<string> ListSocialNetworks { get; set; }
        [BsonElement("cs")]
        public List<CommentModel> Comments { get; set; }
    }
}
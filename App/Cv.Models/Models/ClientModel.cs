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
        public string CompanyId { get; set; }
        public DateTime StarDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool BlackList { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public List<string> EMails { get; set; }
        public List<string> Phones { get; set; }
        public List<string> ListSocialNetworks { get; set; }
        public List<CommentModel> Comments { get; set; }
    }
}
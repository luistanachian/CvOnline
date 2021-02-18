using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cv.Models
{
    public class UserStatisticsModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string UserId { get; set; }
    }
}

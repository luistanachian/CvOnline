using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Cv.Models
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string UserId { get; set; }
        public string CompanyId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Blocked { get; set; }
        public DateTime NextExpirationDate { get; set; }
        public int ErrorCounter { get; set; }
        public UserTypeEnum UserType { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
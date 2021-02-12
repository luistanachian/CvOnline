using Cv.Models.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace Cv.Models
{
    public class ReferenceModel
    {
        [BsonElement("ne")]
        public string Name { get; set; }
        [BsonElement("ln")]
        public string LastName { get; set; }
        [BsonElement("pe")]
        public string Phone { get; set; }
        [BsonElement("em")]
        public string Email { get; set; }
        [BsonElement("re")]
        public string Role { get; set; }
        [BsonElement("rp")]
        public WorkRelationshipEnum WorkRelationship { get; set; }
        [BsonElement("ra")]
        public string ReferenceAnswer  { get; set; }
    }
}

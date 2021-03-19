using Cv.Commons;
using Cv.Models.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cv.Models
{
    public class ClientModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [RegularExpression(RegexConst.Guid)]
        public string ClientId { get; set; }

        [Required]
        [RegularExpression(RegexConst.Guid)]
        public string CompanyId { get; set; }

        public bool BlackList { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Name { get; set; }

        [MinLength(5)]
        [MaxLength(20)]
        public string Document { get; set; }

        [Required]
        public AdressItem Adress { get; set; }

        [MaxLength(5)]
        public List<ContactItem> Contacts { get; set; }

        [MaxLength(5)]
        [Links]
        public List<string> Sites { get; set; }

        public List<CommentItem> Comments { get; set; }
    }
}
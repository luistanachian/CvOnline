using Cv.Models.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Cv.Models
{
    public class ReferenceItem
    {
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Role { get; set; }

        [Required]
        [EnumDataType(typeof(WorkRelationshipEnum))]
        public int WorkRelationship { get; set; }

        [MaxLength(200)]
        public string ReferenceAnswer  { get; set; }
    }
}

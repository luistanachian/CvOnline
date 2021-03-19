using Cv.Commons;
using Cv.Models.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cv.Models
{
    public class CandidateModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [RegularExpression(RegexConst.Guid)]
        public string CandidateId { get; set; }

        [Required]
        [RegularExpression(RegexConst.Guid)]
        public string CompanyId { get; set; }

        [EnumDataType(typeof(StatusCandiateEnum))]
        public int Status { get; set; }

        [RegularExpression(RegexConst.Guid)]
        public string ClientOrSearchId { get; set; }
        
        [Required]
        public PersonalDataItem PersonalData { get; set; }
        
        [Required]
        public AdressItem Adress { get; set; }

        [Required]
        public ProfessionalDataItem ProfessionalData { get; set; }

        [MaxLength(5)]
        public List<LanguageItem> Languages { get; set; }

        [Required]
        [MaxLength(100)]
        public List<SkillItem> Skills { get; set; }

        public List<CommentItem> Comments { get; set; }
    }
}
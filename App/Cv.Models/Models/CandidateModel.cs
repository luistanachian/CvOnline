using Cv.Commons;
using Cv.Models.Attributes;
using Cv.Models.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
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
        [MinLength(5)]
        [MaxLength(100)]
        public string FullName { get; set; }

        [RegularExpression(RegexConst.Date_YYYYMMDD)]
        public string BirthDay { get; set; }

        [RegularExpression(RegexConst.Sex)]
        public string Sex { get; set; }

        [MinLength(5)]
        [MaxLength(20)]
        public string Dni { get; set; }

        [Range(0, 250)]
        public int Nacionality { get; set; }

        [Required]
        public AdressItem Adress { get; set; }

        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        [Phone]
        [MinLength(7)]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string Occupation { get; set; }

        [MaxLength(50)]
        public string Role { get; set; }

        [EnumDataType(typeof(SeniorityEnum))]
        public int Seniority { get; set; }

        [EnumDataType(typeof(WorkModeEnum))]
        public int WorkMode { get; set; }

        public bool Relocate { get; set; }

        [MaxLength(100)]
        public string DependentsOrPets { get; set; }

        [MaxLength(5)]
        [Links]
        public List<string> SocialNetworks { get; set; }

        [MaxLength(5)]
        [Links]
        public List<string> Portfolios { get; set; }

        [MaxLength(5)]
        public List<LanguageItem> Languages { get; set; }

        [MaxLength(20)]
        public List<EducationItem> Educations { get; set; }

        [MaxLength(20)]
        public List<WorkExperienceItem> WorkExperiences { get; set; }

        [Required]
        [MaxLength(100)]
        public List<SkillItem> Skills { get; set; }

        public List<CommentItem> Comments { get; set; }
    }
}
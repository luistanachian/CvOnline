using Cv.Commons;
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

        [Required]
        [RegularExpression(RegexConst.Guid)]
        public string UserId { get; set; }

        [Required]
        public DateTime StarDate { get; set; }

        [Required]
        public StatusCandiateEnum Status { get; set; }

        [RegularExpression(RegexConst.Guid)]
        public string ClientOrSearchId { get; set; }

        public TemporaryUserItem TemporaryUser { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(RegexConst.Date_YYYYMMDD)]
        public string BirthDay { get; set; }

        public string Sex { get; set; }

        public string Dni { get; set; }

        public string Nacionality { get; set; }

        [Required]
        [Range(1, 250)]
        public int CountryId { get; set; }
        [Range(0, 4892)]
        public int StateId { get; set; }
        [MaxLength(100)]
        public string AdressOne { get; set; }
        [MaxLength(100)]
        public string AdressTwo { get; set; }
        [MaxLength(10)]
        public string PostalCode { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string Occupation { get; set; }
        [MaxLength(50)]
        public string Role { get; set; }
        public SeniorityEnum Seniority { get; set; }
        public WorkModeEnum WorkMode { get; set; }
        public bool Relocate { get; set; }
        public string DependentsOrPets { get; set; }


        //no requeridos


        public string Photo { get; set; }



        //listas
        public List<string> ListSocialNetworks { get; set; }
        public List<LanguageItem> ListLanguages { get; set; }
        public List<string> ListPortfolios { get; set; }
        public List<EducationItem> ListEducations { get; set; }
        public List<WorkExperienceItem> ListWorkExperiences { get; set; }
        public List<SkillItem> ListSkills { get; set; }
        public List<CommentItem> Comments { get; set; }
    }
}
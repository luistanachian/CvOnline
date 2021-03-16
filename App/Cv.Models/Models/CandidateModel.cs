﻿using Cv.Commons;
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

        [Required]
        [EnumDataType(typeof(StatusCandiateEnum))]
        public int Status { get; set; }

        [RegularExpression(RegexConst.Guid)]
        public string ClientOrSearchId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(RegexConst.Date_YYYYMMDD)]
        public string BirthDay { get; set; }

        [RegularExpression(RegexConst.Sex)]
        public string Sex { get; set; }

        [MaxLength(20)]
        public string Dni { get; set; }

        [Range(0, 250)]
        public int Nacionality { get; set; }

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

        [EnumDataType(typeof(SeniorityEnum))]
        public int Seniority { get; set; }

        [EnumDataType(typeof(WorkModeEnum))]
        public int WorkMode { get; set; }

        [Required]
        public bool Relocate { get; set; }

        [MaxLength(100)]
        public string DependentsOrPets { get; set; }


        // listas

        [MaxLength(5)]
        [LinksAttribute]
        public List<string> ListSocialNetworks { get; set; }

        [Required]
        [MaxLength(5)]
        public List<LanguageItem> ListLanguages { get; set; }

        [MaxLength(5)]
        [LinksAttribute]
        public List<string> ListPortfolios { get; set; }
        
        [MaxLength(20)]
        public List<EducationItem> ListEducations { get; set; }

        [MaxLength(20)]
        public List<WorkExperienceItem> ListWorkExperiences { get; set; }

        [Required]
        [MaxLength(100)]
        public List<SkillItem> ListSkills { get; set; }

        [MaxLength(100)]
        [CommentAttribute]
        public List<CommentItem> Comments { get; set; }
    }
}
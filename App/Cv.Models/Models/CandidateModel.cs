using Cv.Models.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Cv.Models
{
    public class CandidateModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string CandidateId { get; set; }
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public DateTime StarDate { get; set; }
        public StatusCandiateEnum Status { get; set; }
        public string ClientOrSearchId { get; set; }
        public TemporaryUserItem TemporaryUser { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string BirthDay { get; set; }
        public string Sex { get; set; }
        public string Dni { get; set; }
        public string Nacionality { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public string AdressOne { get; set; }
        public string AdressTwo { get; set; }
        public string PostalCode { get; set; }
        public List<string> Emails { get; set; }
        public List<string> Phones { get; set; }
        public List<string> ListSocialNetworks { get; set; }
        public string Occupation { get; set; }
        public string Role { get; set; }
        public SeniorityEnum Seniority { get; set; }
        public List<LanguageItem> ListLanguages { get; set; }
        public List<string> ListPortfolios { get; set; }
        public WorkModeEnum WorkMode { get; set; }
        public bool Relocate { get; set; }
        public string DependentsOrPets { get; set; }
        public List<EducationItem> ListEducations { get; set; }
        public List<WorkExperienceItem> ListWorkExperiences { get; set; }
        public List<SkillItem> ListSkills { get; set; }
        public List<CommentItem> Comments { get; set; }
    }
}
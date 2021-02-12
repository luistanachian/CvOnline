using Cv.Models.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cv.Models
{
    public class CandidateModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }


        public string Name { get; set; }
        public string LastName { get; set; }
        public string BirthDay { get; set; }
        public string Sex { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Dni { get; set; }
        public string Nacionality { get; set; }
        public string Occupation { get; set; }
        public string Role { get; set; }
        public SeniorityEnum Seniority { get; set; }
        public EdutationTypeEnum Edutation { get; set; }


        public List<LanguageModel> ListLanguages { get; set; }
        public RelocateModel Relocate { get; set; }


        public List<string> EMail { get; set; }
        public List<string> Phone { get; set; }
        public List<string> ListSocialNetworks { get; set; }
        public List<string> ListPortfolio { get; set; }


        public List<EducationModel> ListEducations { get; set; }
        public List<WorkExperienceModel> ListWorkExperiences { get; set; }
        public List<SkillModel> ListSkills { get; set; }
    }
}
using Cv.Models.Enums;
using Cv.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Cv.Models
{
    public class CandidateModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string BirthDay { get; set; }
        public string Sex { get; set; }
        public string Dni { get; set; }
        public string Nacionality { get; set; }
        public string Occupation { get; set; }
        public string Role { get; set; }
        public AdressModel Adress { get; set; }
        public SeniorityEnum Seniority { get; set; }
        public EducationTypeEnum Education { get; set; }
        public List<LanguageModel> ListLanguages { get; set; }
        public RelocateModel Relocate { get; set; }
        public List<string> EMails { get; set; }
        public List<string> Phones { get; set; }
        public List<string> ListSocialNetworks { get; set; }
        public List<string> ListPortfolios { get; set; }
        public List<EducationModel> ListEducations { get; set; }
        public List<WorkExperienceModel> ListWorkExperiences { get; set; }
        public List<SkillModel> ListSkills { get; set; }
    }
}
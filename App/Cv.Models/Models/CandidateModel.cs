using Cv.Models.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Cv.Models
{
    public class CandidateModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CandidateId { get; set; }
        public string CompanyId { get; set; }
        public StatusCandiateEnum Status { get; set; }
        public TemporaryUserModel TemporaryUser { get; set; }
        public string Photo { get; set; }
        public PersonalDataModel PersonalData { get; set; }
        public RelocateModel Relocate { get; set; }
        public List<LanguageModel> ListLanguages { get; set; }
        public List<string> ListPortfolios { get; set; }
        public List<EducationModel> ListEducations { get; set; }
        public List<WorkExperienceModel> ListWorkExperiences { get; set; }
        public List<SkillModel> ListSkills { get; set; }
        public List<CommentModel> Comments { get; set; }
    }
}
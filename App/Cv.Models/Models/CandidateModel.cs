using Cv.Models.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Cv.Models
{
    public class CandidateModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string CandidateId { get; set; }
        [BsonElement("cid")]
        public string CompanyId { get; set; }
        [BsonElement("st")]
        public StatusCandiateEnum Status { get; set; }
        [BsonElement("us")]
        public TemporaryUserModel TemporaryUser { get; set; }
        [BsonElement("ph")]
        public string Photo { get; set; }
        [BsonElement("pd")]
        public PersonalDataModel PersonalData { get; set; }
        [BsonElement("re")]
        public RelocateModel Relocate { get; set; }
        [BsonElement("le")]
        public List<LanguageModel> ListLanguages { get; set; }
        [BsonElement("po")]
        public List<string> ListPortfolios { get; set; }
        [BsonElement("ed")]
        public List<EducationModel> ListEducations { get; set; }
        [BsonElement("we")]
        public List<WorkExperienceModel> ListWorkExperiences { get; set; }
        [BsonElement("sk")]
        public List<SkillModel> ListSkills { get; set; }
        [BsonElement("co")]
        public List<CommentModel> Comments { get; set; }
    }
}
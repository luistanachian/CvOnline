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
        public string TargetRole { get; set; }

        public string EMail { get; set; }
        public List<string> ListPhones { get; set; }
        public List<string> ListSocialNetworks { get; set; }

        public List<EducationModel> ListEducations { get; set; }
        public List<WorkExperienceModel> ListWorkExperiences { get; set; }
        public List<SkillModel> ListSkills { get; set; }
    }
}
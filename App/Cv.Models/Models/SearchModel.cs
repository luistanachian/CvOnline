using Cv.Models.Enums;
using Cv.Models.Models.Items;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Cv.Models.Models
{
    public class SearchModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string SearchId { get; set; }
        public string ClientId { get; set; }
        public string CompanyId { get; set; }
        public StatusSearchEnum Status { get; set; }
        public int NumberOfEmployees { get; set; }
        public List<SkillRequiredModel>  NecessarySkills { get; set; } //TODO falta
        public List<AssignedCandidateModel> AssignedCandidates { get; set; } //TODO falta
        public List<string> AssignedUsers { get; set; }
    }
}
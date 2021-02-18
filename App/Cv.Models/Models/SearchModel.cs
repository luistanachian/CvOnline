using Cv.Models.Enums;
using Cv.Models.Items;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Cv.Models
{
    public class SearchModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string SearchId { get; set; }
        public string ClientId { get; set; }
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string SearchEndDate { get; set; }
        public string WorkingStartDate { get; set; }
        public StatusSearchEnum Status { get; set; }
        public string Occupation { get; set; }
        public string Role { get; set; }
        public int NumberOfEmployees { get; set; }
        public int EstimateAmount { get; set; }
        public int CurrencyId { get; set; }
        public WorkModeEnum WorkMode { get; set; }
        public bool Relocate { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public string AdressOne { get; set; }
        public string AdressTwo { get; set; }
        public string PostalCode { get; set; }
        public List<SkillRequiredItem>  NecessarySkills { get; set; }
        public List<AssignedCandidateItem> AssignedCandidates { get; set; }
        public List<string> AssignedUsers { get; set; }
        public List<CommentItem> Comments { get; set; }
    }
}
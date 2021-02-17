using Cv.Models.Models.Items;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Cv.Models.Models
{
    public class ClientModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ClientId { get; set; }
        public string CompanyId { get; set; }
        public DateTime StarDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool BlackList { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string AdressOne { get; set; }
        public string AdressTwo { get; set; }
        public string PostalCode { get; set; }
        public List<ContactModel> Contacts { get; set; }
        public List<string> SitesList { get; set; }
        public List<CommentModel> Comments { get; set; }
    }
}
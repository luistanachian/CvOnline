using Cv.Models.Models.Items;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Cv.Models
{
    class CompanyModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CompanyId { get; set; }
        public DateTime StarDate { get; set; }
        public DateTime LastPayDate { get; set; }
        public DateTime NextPayDate { get; set; }
        public string Logo { get; set; }
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
    }
}
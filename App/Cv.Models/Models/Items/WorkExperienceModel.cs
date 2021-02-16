using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Cv.Models
{
    public class WorkExperienceModel
    {
        public string Role { get; set; }
        public string Company { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool Current { get; set; }
        public List<ReferenceModel> ListReferences { get; set; }
        public string Comment { get; set; }
    }
}

using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Cv.Models
{
    public class RelocateModel
    {
        public string RelocateDependentsOrPets { get; set; }
        public string RelocateEstimateDate { get; set; }
    }
}

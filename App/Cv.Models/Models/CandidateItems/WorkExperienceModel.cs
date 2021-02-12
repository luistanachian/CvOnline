using Cv.Models;
using System;
using System.Collections.Generic;

namespace Cv.Models
{
    public class WorkExperienceModel
    {
        public string Role { get; set; }
        public string Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Current { get; set; }
        public List<ReferenceModel> ListReferences { get; set; }
        public string Comments { get; set; }
    }
}

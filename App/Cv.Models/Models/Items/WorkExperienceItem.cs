using System.Collections.Generic;

namespace Cv.Models
{
    public class WorkExperienceItem
    {
        public string Role { get; set; }
        public string Company { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool Current { get; set; }
        public List<ReferenceItem> ListReferences { get; set; }
        public string Comment { get; set; }
    }
}

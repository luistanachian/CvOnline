using Cv.Models.Enums;

namespace Cv.Models
{
    public class EducationItem
    {
        public string Institute { get; set; }
        public EducationTypeEnum EdutationType { get; set; }
        public string YearEnd { get; set; }
        public bool Current { get; set; }
        public string Title { get; set; }
        public int CountryId { get; set; }
    }
}

using Cv.Models.Enums;

namespace Cv.Models
{
    public class EducationModel
    {
        public string Institute { get; set; }
        public EdutationTypeEnum EdutationType { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Title { get; set; }
        public string CodeCountry { get; set; }
    }
}

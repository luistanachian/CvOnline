using System;

namespace Cv.Models
{
    public class TemporaryUserModel
    {
        public string User { get; set; }
        public string Passeord { get; set; }
        public DateTime EndDate { get; set; }
        public int ErrorCounter { get; set; }
        public bool EditPhoto { get; set; }
        public bool EditPersonalData { get; set; }
        public bool EditRelocate { get; set; }
        public bool EditLanguages { get; set; }
        public bool EditPortfolios { get; set; }
        public bool EditEducations { get; set; }
        public bool EditWorkExperiences { get; set; }
        public bool EditSkills { get; set; }
    }
}

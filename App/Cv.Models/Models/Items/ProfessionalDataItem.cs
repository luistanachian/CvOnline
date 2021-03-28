using Cv.Models.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cv.Models
{
    public class ProfessionalDataItem
    {
        [MaxLength(50)]
        public string Occupation { get; set; }

        [MaxLength(50)]
        public string Role { get; set; }

        [EnumDataType(typeof(SeniorityEnum))]
        public int Seniority { get; set; }

        [EnumDataType(typeof(WorkModeEnum))]
        public int WorkMode { get; set; }

        public bool Relocate { get; set; }

        [MaxLength(5)]
        [Links]
        public List<string> Portfolios { get; set; }


        [MaxLength(20)]
        public List<EducationItem> Educations { get; set; }

        [MaxLength(20)]
        public List<WorkExperienceItem> WorkExperiences { get; set; }

    }
}

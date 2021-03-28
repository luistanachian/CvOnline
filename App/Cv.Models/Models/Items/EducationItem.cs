using Cv.Models.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cv.Models
{
    public class EducationItem
    {
        [Required]
        [MaxLength(50)]
        public string Institute { get; set; }

        [EnumDataType(typeof(EducationTypeEnum))]
        public int EdutationType { get; set; }

        [YearAttribute]
        public int YearEnd { get; set; }

        public bool Current { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Range(0, 250)]
        public int CountryId { get; set; }
    }
}

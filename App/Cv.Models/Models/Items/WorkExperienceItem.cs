using Cv.Commons;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cv.Models
{
    public class WorkExperienceItem
    {
        [Required]
        [MaxLength(50)]
        public string Role { get; set; }

        [Required]
        [MaxLength(50)]
        public string Company { get; set; }

        [Required]
        [RegularExpression(RegexConst.Date_YYYYMM)]
        public string StartDate { get; set; }

        [RegularExpression(RegexConst.Date_YYYYMM)]
        public string EndDate { get; set; }

        [Required]
        public bool Current { get; set; }

        [MaxLength(5)]
        public List<ReferenceItem> ListReferences { get; set; }

        [MaxLength(200)]
        public string Comment { get; set; }
    }
}

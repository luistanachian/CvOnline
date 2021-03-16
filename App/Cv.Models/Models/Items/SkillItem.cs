using Cv.Commons;
using Cv.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Cv.Models
{
    public class SkillItem
    {
        [Required]
        [MaxLength(20)]
        public string Skill { get; set; }

        [Required]
        [Range(1, 10)]
        public int SelfEvaluation { get; set; }

        [Required]
        [EnumDataType(typeof(FrequencyUsedEnum))]
        public int FrequencyUsed { get; set; }

        [Required]
        [Range(0, 11)]
        public int Months { get; set; }

        [Required]
        [Range(0, 40)]
        public int Years { get; set; }

        [Required]
        [RegularExpression(RegexConst.Date_YYYYMM)]
        public string LastUsed { get; set; }
    }
}
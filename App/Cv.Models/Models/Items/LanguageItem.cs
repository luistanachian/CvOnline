using System.ComponentModel.DataAnnotations;

namespace Cv.Models
{
    public class LanguageItem
    {
        [Required]
        [StringLength(2)]
        public string CodeLanguage { get; set; }

        [EnumDataType(typeof(LevelLanguageEnum))]
        public int Level { get; set; }
    }
}
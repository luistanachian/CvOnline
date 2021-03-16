using Cv.Commons;
using Cv.Models.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cv.Models
{
    public class CommentItem
    {
        [Required]
        [FullDateAttribute]
        public DateTime Date { get; set; }

        [Required]
        [RegularExpression(RegexConst.Guid)]
        public string User { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(200)]
        public string Comment { get; set; }
    }
}

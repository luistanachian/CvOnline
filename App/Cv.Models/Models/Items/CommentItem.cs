using Cv.Commons;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cv.Models
{
    public class CommentItem
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        [RegularExpression(RegexConst.Guid)]
        public string User { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}

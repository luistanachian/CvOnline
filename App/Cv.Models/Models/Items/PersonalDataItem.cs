using Cv.Commons;
using Cv.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cv.Models
{
    public class PersonalDataItem
    {
        //[Required]
        //[MinLength(5)]
        //[MaxLength(100)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        [Phone]
        [MinLength(7)]
        public string Phone { get; set; }

        [RegularExpression(RegexConst.Date_YYYYMMDD)]
        public string BirthDay { get; set; }

        [RegularExpression(RegexConst.Sex)]
        public string Sex { get; set; }

        [MinLength(5)]
        [MaxLength(20)]
        public string Dni { get; set; }

        [Range(0, 250)]
        public int Nacionality { get; set; }

        [MaxLength(5)]
        [Links]
        public List<string> SocialNetworks { get; set; }
    }
}

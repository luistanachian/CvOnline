using Cv.Models.Attributes;
using Cv.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cv.Models.Search
{
    public class CandidateSearch
    {
        [Required]
        public string CompanyId { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Page { get; set; }

        [Required]
        [Range(25, 100)]
        public int PageSize { get; set; }

        [Range(0, 250)]
        public int CountryId { get; set; }

        [Range(0, 4892)]
        public int StateId { get; set; }

        [NullableEnumsAttribute(typeof(StatusCandiateEnum))]
        public int? Status { get; set; }

        [MinLength(5)]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public List<string> Skills { get; set; }
    }
}
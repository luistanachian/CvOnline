using System;
using System.ComponentModel.DataAnnotations;

namespace Cv.Models
{
    public class AdressItem
    {
        [Range(1, 250)]
        public int CountryId { get; set; }

        [Range(0, 4892)]
        public int StateId { get; set; }

        [MaxLength(100)]
        public string AdressOne { get; set; }

        [MaxLength(100)]
        public string AdressTwo { get; set; }

        [MaxLength(10)]
        public string PostalCode { get; set; }
    }
}
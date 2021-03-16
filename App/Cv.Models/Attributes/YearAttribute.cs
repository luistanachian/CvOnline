using System;
using System.ComponentModel.DataAnnotations;

namespace Cv.Models.Attributes
{
    public class YearAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var year = value as int?;
            return year != null && year > DateTime.Today.AddYears(-41).Year && year <= DateTime.Today.Year;
        }
    }
}
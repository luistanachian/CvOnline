using System;
using System.ComponentModel.DataAnnotations;

namespace Cv.Models.Attributes
{
    public class FullDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var date = value as DateTime?;
            return date != null && date <= DateTime.Now;
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace Cv.Models.Attributes
{
    public class FullDateNullAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var date = value as DateTime?;
            if (date == null)
                return true;

            return date <= DateTime.Now;
        }
    }
}
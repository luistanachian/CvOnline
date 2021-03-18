using System;
using System.ComponentModel.DataAnnotations;

namespace Cv.Models.Attributes
{
    public class NullableEnumsAttribute : ValidationAttribute
    {
        private Type typeEnum { get; set; }
        public NullableEnumsAttribute(Type type)
        {
            typeEnum = type;
        }
        public override bool IsValid(object value)
        {
            if (value == null) return true;
            return Enum.IsDefined(typeEnum, value); ;
        }
    }
}
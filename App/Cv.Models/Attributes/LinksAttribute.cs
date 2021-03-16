using Cv.Commons;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cv.Models.Attributes
{
    public class LinksAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var list = value as List<string>;
            if (list == null || list.Count == 0) return true;

            return list.All(x => Regex.Match(x, RegexConst.Link).Success);
        }
    }
}
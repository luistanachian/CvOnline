using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Cv.Models.Attributes
{
    public class CommentAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var list = value as List<CommentItem>;
            if (list == null || list.Count == 0) return true;

            return list.All(c => 
                (!string.IsNullOrWhiteSpace(c.User) && c.User.Length > 4 && c.User.Length < 17) ||   
                (!string.IsNullOrWhiteSpace(c.User) && c.User.Length > 4 && c.User.Length < 17));
        }
    }
}
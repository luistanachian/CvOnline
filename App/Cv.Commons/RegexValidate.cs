using System.Linq;
using System.Text.RegularExpressions;

namespace Cv.Commons
{
    public static class Validate
    {
        public static bool Guids(params string[] guids)
        {
            if (guids.Any(x => string.IsNullOrWhiteSpace(x)))
                return false;

            return guids.All(x => Regex.Match(x, RegexConst.Guid).Success);
        }
    }
}

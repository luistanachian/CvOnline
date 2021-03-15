using System;

namespace Cv.Commons
{
    public static class RegexConst
    {
        public const string Guid = @"^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$";
        public const string Date_YYYYMMDD = @"^\d{4}\-(0[1-9]|1[012])\-(0[1-9]|[12][0-9]|3[01])$";
        

    }
}

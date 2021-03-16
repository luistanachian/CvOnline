namespace Cv.Commons
{
    public static class RegexConst
    {
        public const string Guid = @"^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$";
        public const string Date_YYYYMMDD = @"^\d{4}\-(0[1-9]|1[012])\-(0[1-9]|[12][0-9]|3[01])$";
        public const string Date_YYYYMM = @"^\d{4}\-(0[1-9]|1[012])$";
        public const string Date_YYYY = @"^\d{4}$";
        public const string Sex = "M|F|O";
        public const string Link = @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";


    }
}

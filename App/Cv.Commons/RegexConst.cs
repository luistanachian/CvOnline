namespace Cv.Commons
{
    public static class RegexConst
    {
        public const string Guid = @"^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$";
        public const string Date_YYYYMMDD = @"^\d{4}\-(0[1-9]|1[012])\-(0[1-9]|[12][0-9]|3[01])$";
        public const string Date_yyyyMMdd_hhmmss = @"^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2] [0-9]|3[0-1]) (2[0-3]|[01] [0-9]):[0-5] [0-9]:[0-5][0-9]$";
        public const string Date_YYYYMM = @"^\d{4}\-(0[1-9]|1[012])$";
        public const string Date_YYYY = @"^\d{4}$";
        public const string Sex = "M|m|F|f|O|o";
        public const string Link = @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";
        //public const string Mail = @"^(? (")(".+? (?< !\\)"@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";


    }
}

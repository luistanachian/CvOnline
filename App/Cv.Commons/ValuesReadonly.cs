using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cv.Commons
{
    public static class ValuesReadonly
    {
        public const string FormatDate_yyyyMMdd_hhmmss = "yyyy-MM-dd HH:mm:ss";
        public const string FormatDate_yyyyMMdd = "yyyy-MM-dd";
        public const string FormatDate_yyyyMM = "yyyy-MM";
        public const string FormatDate_yyyy = "yyyy";

        public static readonly string Date_yyyyMMdd_hhmmss = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        public static readonly string Date_yyyyMMdd = DateTime.Now.ToString("yyyy-MM-dd");
        public static readonly string Date_yyyyMM = DateTime.Now.ToString("yyyy-MM");
        public static readonly string Date_yyyy = DateTime.Now.ToString("yyyy");
    }
}

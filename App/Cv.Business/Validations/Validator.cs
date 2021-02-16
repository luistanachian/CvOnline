using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cv.Business.Validations
{
    public static class Validator
    {
        public static bool ValidatePredicates<T>(T model, params Predicate<T>[] validations) where T : class
            => validations.ToList().Where(v =>
            {
                return !v(model);
            }).Count() == 0;

        public static bool Object(object obj) => obj != null;

        public static bool Text(string text) =>
            !string.IsNullOrWhiteSpace(text);

        public static bool Text(string text, int minLength, int maxLength, bool nullable = false) =>
            ((nullable && text == null) || Text(text) && text.Length >= minLength && text.Length <= maxLength);

        public static bool Guid(string text) =>
            Text(text) &&
            Regex.Match(text, @"^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$").Success;

        public static bool Email(string email) =>
            Text(email) &&
            Regex.Match(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").Success;

        public static bool Date_YYYYMMDD(string date) =>
            Text(date) &&
            Regex.Match(date, @"^\d{4}\-(0[1-9]|1[012])\-(0[1-9]|[12][0-9]|3[01])$").Success;

        public static bool Number(string number) =>
            Text(number) &&
            Regex.Match(number, @"^\d+$").Success;

        public static bool Phone(string phone) =>
            Text(phone) &&
            Regex.Match(phone, @"^\+(?:[0-9] ?){6,14}[0-9]$").Success;

        public static bool Url(string url) =>
            Text(url) &&
            Regex.Match(url, @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)").Success;

    }
}
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
        public static bool Text(string text, int length) =>
            Text(text) && text.Length == length;

        public static bool Guid(string text) =>
            Text(text) &&
            Regex.Match(text, "^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$").Success;

    }
}
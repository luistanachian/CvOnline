using System;
using System.Linq;

namespace Cv.Business.Validations
{
    public static class ValidateModel<T> where T : class
    {
        public static bool IsOk(T model, params Predicate<T>[] validations)
            => validations.ToList().Where(v =>
            {
                return !v(model);
            }).Count() == 0;
    }
}

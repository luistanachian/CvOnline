using System;

namespace Cv.Business.Validations
{
    public class Vali<T> where T : class
    {
        public Predicate<T> Validate { get; set; }
        public string Error { get; set; }
    }
}

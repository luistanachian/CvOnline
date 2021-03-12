using System.Collections.Generic;

namespace Cv.Business
{
    public class ResultBus<T> where T : notnull
    {
        public ResultBus()
        {
            Result = default;
            Errores = new List<string>();
        }
        public bool Ok { get { return Errores.Count == 0; } }
        public T Result { get; set; }
        public List<string> Errores { get; set; }
        public void AddError(List<string> errores) => Errores.AddRange(errores);
        public void AddError(string error) => Errores.Add(error);
    }
}
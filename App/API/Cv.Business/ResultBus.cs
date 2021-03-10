using System.Collections.Generic;

namespace Cv.Business
{
    public class ResultBus<T> where T : notnull
    {
        public ResultBus()
        {
            Ok = false;
            Result = default;
            Errores = new List<string>();
        }
        public bool Ok { get; set; }
        public T Result { get; set; }
        public List<string> Errores { get; set; }

        public void AddError(List<string> errores)
        {
            Ok = false;
            Errores.AddRange(errores);
        }
        public void AddError(string error)
        {
            Ok = false;
            Errores.Add(error);
        }
    }
}
using System.Collections.Generic;

namespace Cv.Business
{
    public class ResultBus
    {
        public ResultBus()
        {
            Errores = new List<string>();
        }
        public bool Ok { get { return Errores.Count == 0; } }
        public List<string> Errores { get; set; }
        public void AddError(List<string> errores)
        {
            if (errores != null || errores.Count > 0)
                Errores.AddRange(errores);
        }
        public void AddError(string error)
        {
            if (!string.IsNullOrWhiteSpace(error))
                Errores.Add(error);
        }
    }
}
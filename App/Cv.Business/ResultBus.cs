using System.Collections.Generic;

namespace Cv.Business
{
    public class ResultBus<T> where T : notnull
    {
        public bool Ok { get; set; } = true;
        public T Object { get; set; } = default;
        public List<string> Messages { get; set; } = new List<string>();
        public void AddError(string error)
        {
            Ok = false;
            Object = default;
            Messages.Add(error);
        }
    }
}

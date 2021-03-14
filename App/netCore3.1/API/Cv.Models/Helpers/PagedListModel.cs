using System.Collections.Generic;

namespace Cv.Models.Helpers
{
    public class PagedListModel<T> where T : class
    {
        public long Count { get; set; }
        public long Pages { get; set; }
        public List<T> List { get; set; }
    }
}

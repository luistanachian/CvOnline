using System;
using System.Collections.Generic;

namespace Cv.Models
{
    public class TestItem
    {
        public string Description { get; set; }
        public string Url { get; set; }
        public string Result { get; set; }
        public DateTime DateExpiration { get; set; }
        public List<CommentItem> Comments { get; set; }
    }
}

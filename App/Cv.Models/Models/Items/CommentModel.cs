using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Cv.Models
{
    public class CommentModel
    {
        public DateTime Date { get; set; }
        public string User { get; set; }
        public string Comment { get; set; }
    }
}

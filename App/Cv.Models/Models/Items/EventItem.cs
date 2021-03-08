using Cv.Models.Enums;
using System;

namespace Cv.Models.Items
{
    public class EventItem
    {
        public string UserId { get; set; }
        public EventEnum Event { get; set; }
        public DateTime Date { get; set; }
    }
}

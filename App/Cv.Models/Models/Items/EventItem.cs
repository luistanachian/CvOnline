using System;

namespace Cv.Models
{
    public class EventItem
    {
        public EventItem()
        {

        }
        public EventItem(string UserId, EventEnum Event)
        {
            this.UserId = UserId;
            this.Event = Event;
            Date = DateTime.Now;
        }
        public string UserId { get; set; }
        public EventEnum Event { get; set; }
        public DateTime Date { get; set; }
    }
}

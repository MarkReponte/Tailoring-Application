using System;

namespace Dashboard.Classes
{
    public class AppNotification
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public bool IsRead { get; set; }
    }
}
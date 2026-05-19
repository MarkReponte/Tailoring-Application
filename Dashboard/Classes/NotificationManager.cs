using Dashboard.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dashboard.Classes
{
    public static class NotificationManager
    {
        public static List<AppNotification> Notifications = new List<AppNotification>();

        public static event Action? NotificationAdded;
        public static event Action? NotificationChanged;

        public static void AddNotification(string title, string message)
        {
            Notifications.Insert(0, new AppNotification
            {
                Title = title,
                Message = message,
                Time = DateTime.Now,
                IsRead = false
            });

            NotificationAdded?.Invoke();
            NotificationChanged?.Invoke();
        }

        public static int UnreadCount()
        {
            return Notifications.Count(x => !x.IsRead);
        }

        public static void MarkAllAsRead()
        {
            foreach (var item in Notifications)
            {
                item.IsRead = true;
            }

            NotificationChanged?.Invoke();
        }
    }
}

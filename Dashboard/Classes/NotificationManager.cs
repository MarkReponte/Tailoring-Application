using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Dashboard.Classes
{
    public static class NotificationManager
    {
        private static readonly string NotificationFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Tailoring-Application");

        private static readonly string NotificationFile = Path.Combine(NotificationFolder, "notifications.json");

        public static List<AppNotification> Notifications = new List<AppNotification>();

        public static event Action? NotificationAdded;
        public static event Action? NotificationChanged;

        static NotificationManager()
        {
            LoadFromStorage();
        }

        public static void AddNotification(string title, string message)
        {
            Notifications.Insert(0, new AppNotification
            {
                Title = title,
                Message = message,
                Time = DateTime.Now,
                IsRead = false
            });

            SaveToStorage();
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

            SaveToStorage();
            NotificationChanged?.Invoke();
        }

        public static void MarkAsRead(AppNotification notification)
        {
            if (notification.IsRead) return;

            notification.IsRead = true;
            SaveToStorage();
            NotificationChanged?.Invoke();
        }

        private static void LoadFromStorage()
        {
            try
            {
                if (!File.Exists(NotificationFile)) return;

                string json = File.ReadAllText(NotificationFile);
                var saved = JsonSerializer.Deserialize<List<AppNotification>>(json);
                if (saved != null)
                {
                    Notifications = saved;
                }
            }
            catch
            {
                Notifications = new List<AppNotification>();
            }
        }

        private static void SaveToStorage()
        {
            try
            {
                Directory.CreateDirectory(NotificationFolder);
                string json = JsonSerializer.Serialize(Notifications);
                File.WriteAllText(NotificationFile, json);
            }
            catch
            {
                // Notifications are helpful, but they should never block order actions.
            }
        }
    }
}

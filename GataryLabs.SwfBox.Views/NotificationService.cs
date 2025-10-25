using GataryLabs.SwfBox.Views.Abstractions;
using Notification.Wpf;
using System;

namespace GataryLabs.SwfBox.Views
{
    internal class NotificationService : INotificationService
    {
        private const string notificationAreaName = "ContentNotificationArea";

        private INotificationManager notificationManager;

        public NotificationService(INotificationManager notificationManager)
        {
            this.notificationManager = notificationManager;
        }

        public void ClearAll()
        {
            // Suprisingly, this is a workaround.
            notificationManager.Show(" ", notificationAreaName, TimeSpan.FromSeconds(0));
        }

        public void ShowAsToast(string message)
        {
            TextNotification notification = new TextNotification();
            notification.DataContext = message;
            notificationManager.Show(notification, notificationAreaName);
        }

    }
}

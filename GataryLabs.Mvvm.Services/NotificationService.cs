using GataryLabs.Mvvm.Services.Abstractions;
using GataryLabs.SwfBox.Views;
using Notification.Wpf;
using System;

namespace GataryLabs.Mvvm.Services
{
    public class NotificationService : INotificationService
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
            object notification = CreateToastNotification(message);
            notificationManager.Show(notification, notificationAreaName);
        }

        virtual protected object CreateToastNotification(object dataContext)
        {
            TextNotification notification = new TextNotification();
            notification.DataContext = dataContext;
            return notification;
        }
    }
}

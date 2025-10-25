namespace GataryLabs.SwfBox.Views.Abstractions
{
    public interface INotificationService
    {
        void ShowAsToast(string message);
        void ClearAll();
    }
}

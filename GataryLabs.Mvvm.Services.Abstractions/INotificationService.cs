namespace GataryLabs.Mvvm.Services.Abstractions
{
    public interface INotificationService
    {
        void ShowAsToast(string message);
        void ClearAll();
    }
}

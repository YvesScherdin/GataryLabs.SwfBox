namespace GataryLabs.SwfBox.ViewModels.Abstractions
{
    public interface IMainWindowErrorContentViewModel : IMainWindowContentViewModel
    {
        string ErrorTitle { get; set; }

        string ErrorMessage { get; set; }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.SwfBox.ViewModels.Abstractions;

namespace GataryLabs.SwfBox.ViewModels
{
    internal class MainWindowErrorContentViewModel : ObservableObject, IMainWindowErrorContentViewModel
    {
        public string ErrorTitle { get; set; }
        public string ErrorMessage { get; set; }

        public void OnLoaded()
        {
        }

        public void OnUnloaded()
        {
        }
    }
}

using System.Windows.Input;

namespace GataryLabs.SwfBox.ViewModels.Abstractions
{
    public interface IMainWindowViewModel : IViewModel
    {
        public IMainWindowContentViewModel MainContentViewModel { get; }

        public ICommand TestCommand { get; }
    }
}

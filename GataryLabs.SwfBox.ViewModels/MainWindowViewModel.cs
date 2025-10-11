using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GataryLabs.SwfBox.ViewModels
{
    internal class MainWindowViewModel : ObservableObject, IMainWindowViewModel
    {
        private IMainWindowSwfDetailsContentViewModel mainWindowSwfDetailsContentViewModel;

        private IMainWindowContentViewModel mainContentViewModel;

        public IMainWindowContentViewModel MainContentViewModel
        {
            get => mainContentViewModel;
            set
            {
                SetProperty(ref mainContentViewModel, value);
            }
        }

        public ICommand TestCommand { get; init; }

        public MainWindowViewModel(IMainWindowSwfDetailsContentViewModel mainWindowSwfDetailsContentViewModel)
        {
            this.mainWindowSwfDetailsContentViewModel = mainWindowSwfDetailsContentViewModel;

            this.TestCommand = new RelayCommand(DoStuff);
        }

        public void OnLoaded()
        {
            Debug.WriteLine("On loaded - MainWindowViewModel");
        }

        private async void DoStuffAsync()
        {
            await Task.Delay(1000);
        }

        public void OnUnloaded()
        {
            Debug.WriteLine("On unloaded - MainWIndowViewModel");
        }


        private void DoStuff()
        {
            MainContentViewModel = mainContentViewModel == null ? mainWindowSwfDetailsContentViewModel : null;
        }

    }
}

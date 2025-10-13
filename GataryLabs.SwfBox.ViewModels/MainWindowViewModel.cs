using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using System.Diagnostics;

namespace GataryLabs.SwfBox.ViewModels
{
    internal class MainWindowViewModel : ObservableObject, IMainWindowViewModel
    {
        private IMainWindowMenuBarViewModel mainWindowMenuBarViewModel;
        private IMainWindowSwfDetailsContentViewModel mainWindowSwfDetailsContentViewModel;
        private IMainWindowContentViewModel mainContentViewModel;

        public MainWindowViewModel(
            IMainWindowMenuBarViewModel mainWindowMenuBarViewModel,
            IMainWindowSwfDetailsContentViewModel mainWindowSwfDetailsContentViewModel)
        {
            this.mainWindowMenuBarViewModel = mainWindowMenuBarViewModel;
            this.mainWindowSwfDetailsContentViewModel = mainWindowSwfDetailsContentViewModel;
        }

        public IMainWindowContentViewModel MainContentViewModel
        {
            get => mainContentViewModel;
            set
            {
                SetProperty(ref mainContentViewModel, value);
            }
        }

        public IMainWindowMenuBarViewModel MenuBarViewModel => mainWindowMenuBarViewModel;

        public void OnLoaded()
        {
            Debug.WriteLine("On loaded - MainWindowViewModel");

            MainContentViewModel = mainWindowSwfDetailsContentViewModel;
        }

        public void OnUnloaded()
        {
            Debug.WriteLine("On unloaded - MainWIndowViewModel");
        }
    }
}

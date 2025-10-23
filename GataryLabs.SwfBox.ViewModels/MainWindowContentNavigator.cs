using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.SwfBox.ViewModels.Abstractions;

namespace GataryLabs.SwfBox.ViewModels
{
    internal class MainWindowContentNavigator : ObservableObject, IMainWindowContentNavigator
    {
        private IMainWindowSwfDetailsContentViewModel mainWindowSwfDetailsContentViewModel;
        private IMainWindowOverviewContentViewModel mainWindowOverviewContentViewModel;
        private IMainWindowContentViewModel mainContentViewModel;

        public MainWindowContentNavigator(
            IMainWindowSwfDetailsContentViewModel mainWindowSwfDetailsContentViewModel,
            IMainWindowOverviewContentViewModel mainWindowOverviewContentViewModel)
        {
            this.mainWindowSwfDetailsContentViewModel = mainWindowSwfDetailsContentViewModel;
            this.mainWindowOverviewContentViewModel = mainWindowOverviewContentViewModel;
        }

        public IMainWindowContentViewModel ContentViewModel
        {
            get => mainContentViewModel;
            set => SetProperty(ref mainContentViewModel, value);
        }

        public IMainWindowSwfDetailsContentViewModel SwfDetailsContentViewModel => mainWindowSwfDetailsContentViewModel;
        public IMainWindowOverviewContentViewModel OverviewContentViewModel => mainWindowOverviewContentViewModel;
    }
}

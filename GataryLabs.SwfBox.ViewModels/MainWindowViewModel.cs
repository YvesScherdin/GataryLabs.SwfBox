using CommunityToolkit.Mvvm.ComponentModel;
using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.ViewModels.Utils;
using System.Diagnostics;

namespace GataryLabs.SwfBox.ViewModels
{
    internal class MainWindowViewModel : ObservableObject, IMainWindowViewModel
    {
        private readonly IMainWindowMenuBarViewModel mainWindowMenuBarViewModel;
        private readonly LazyInstance<IMainWindowContentNavigator> contentNavigatorLazy;

        public MainWindowViewModel(
            IMainWindowMenuBarViewModel mainWindowMenuBarViewModel,
            LazyInstance<IMainWindowContentNavigator> contentNavigatorLazy)
        {
            this.mainWindowMenuBarViewModel = mainWindowMenuBarViewModel;
            this.contentNavigatorLazy = contentNavigatorLazy;
        }

        public IMainWindowMenuBarViewModel MenuBarViewModel => mainWindowMenuBarViewModel;
        public IMainWindowContentNavigator ContentNavigator => contentNavigatorLazy.Value;
        
        public void OnLoaded()
        {
            Debug.WriteLine("On loaded - MainWindowViewModel");

            contentNavigatorLazy.Value.ContentViewModel = contentNavigatorLazy.Value.OverviewContentViewModel;
        }

        public void OnUnloaded()
        {
            Debug.WriteLine("On unloaded - MainWIndowViewModel");
        }
    }
}

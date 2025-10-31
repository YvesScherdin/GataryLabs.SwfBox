using GataryLabs.Mvvm.ViewModels.Abstractions;
using GataryLabs.Mvvm.Views.Abstractions;
using GataryLabs.Mvvm.Views.InternalBehaviors;
using System.Windows;
using System.Windows.Controls;

namespace GataryLabs.Mvvm.Views
{
    /// <summary>
    /// Base class for content views.
    /// </summary>
    /// <see cref="UserControl"/>
    public class ContentView : UserControl, IContentView
    {
        protected ControlBehaviorManager controlBehaviorManager;

        public IViewModel ViewModel => DataContext as IViewModel;

        public ContentView()
        {
            controlBehaviorManager = new ControlBehaviorManager(this);

            controlBehaviorManager.Add(new ViewModelOwnerControlBehavior());

            Unloaded += ContentView_Unloaded;
        }

        private void ContentView_Unloaded(object sender, RoutedEventArgs e)
        {
            Unloaded -= ContentView_Unloaded;

            controlBehaviorManager.Dispose();
            controlBehaviorManager = null;
        }
    }
}

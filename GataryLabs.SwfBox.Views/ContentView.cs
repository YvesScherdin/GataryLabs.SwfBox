using GataryLabs.SwfBox.ViewModels.Abstractions;
using GataryLabs.SwfBox.Views.Abstractions;
using GataryLabs.SwfBox.Views.InternalBehaviors;
using System.Windows;
using System.Windows.Controls;

namespace GataryLabs.SwfBox.Views
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

            this.Unloaded += ContentView_Unloaded;
        }

        private void ContentView_Unloaded(object sender, RoutedEventArgs e)
        {
            this.Unloaded -= ContentView_Unloaded;

            controlBehaviorManager.Dispose();
            controlBehaviorManager = null;
        }
    }
}

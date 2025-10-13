using GataryLabs.SwfBox.Views.InternalBehaviors;
using System.Windows;
using System.Windows.Controls;

namespace GataryLabs.SwfBox.Views
{
    public class MvvmUserControl : UserControl
    {
        protected ControlBehaviorManager controlBehaviorManager;

        public MvvmUserControl()
        {
            controlBehaviorManager = new ControlBehaviorManager(this);

            controlBehaviorManager.Add(new ViewModelOwnerControlBehavior());

            this.Unloaded += MvvmWindowUnloaded;
        }

        private void MvvmWindowUnloaded(object sender, RoutedEventArgs e)
        {
            this.Unloaded -= MvvmWindowUnloaded;

            controlBehaviorManager.Dispose();
            controlBehaviorManager = null;
        }
    }
}

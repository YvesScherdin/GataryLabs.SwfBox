using GataryLabs.Mvvm.Views.InternalBehaviors;
using System.Windows;
using System.Windows.Controls;

namespace GataryLabs.Mvvm.Views
{
    public class MvvmUserControl : UserControl
    {
        protected ControlBehaviorManager controlBehaviorManager;

        public MvvmUserControl()
        {
            controlBehaviorManager = new ControlBehaviorManager(this);

            controlBehaviorManager.Add(new ViewModelOwnerControlBehavior());

            Unloaded += MvvmWindowUnloaded;
        }

        private void MvvmWindowUnloaded(object sender, RoutedEventArgs e)
        {
            Unloaded -= MvvmWindowUnloaded;

            controlBehaviorManager.Dispose();
            controlBehaviorManager = null;
        }
    }
}

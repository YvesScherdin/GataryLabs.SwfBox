using AdonisUI.Controls;
using GataryLabs.Mvvm.Views.InternalBehaviors;
using System.Windows;

namespace GataryLabs.Mvvm.Views
{
    public class MvvmWindow : AdonisWindow
    {
        protected ControlBehaviorManager controlBehaviorManager;

        public MvvmWindow()
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

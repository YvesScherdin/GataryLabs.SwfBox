using AdonisUI.Controls;
using GataryLabs.SwfBox.Views.InternalBehaviors;
using System.Windows;

namespace GataryLabs.SwfBox.Views
{
    public class MvvmWindow : AdonisWindow
    {
        protected ControlBehaviorManager controlBehaviorManager;

        public MvvmWindow()
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

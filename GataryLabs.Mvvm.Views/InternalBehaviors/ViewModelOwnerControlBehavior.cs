using GataryLabs.Mvvm.ViewModels.Abstractions;
using System.Windows;
using System.Windows.Controls;

namespace GataryLabs.Mvvm.Views.InternalBehaviors
{
    public class ViewModelOwnerControlBehavior : IControlBehavior
    {
        private Control control;
        private bool controlLoaded;
        private bool viewModelLoaded;

        public void Initialize(Control control)
        {
            this.control = control;

            this.control.Loaded += Control_Loaded;
            this.control.Unloaded += Control_Unloaded;
            this.control.DataContextChanged += Control_DataContextChanged;
        }

        public void Deinitialize()
        {
            control.Loaded -= Control_Loaded;
            control.Unloaded -= Control_Unloaded;
            control.DataContextChanged -= Control_DataContextChanged;

            controlLoaded = false;

            if (viewModelLoaded && control.DataContext is IViewModel viewModel)
            {
                UnloadViewModel(viewModel);
            }

            control = null;
        }

        private void LoadViewModel(IViewModel viewModel)
        {
            try
            {
                viewModel.OnLoaded();
            }
            finally
            {
                viewModelLoaded = true;
            }
        }

        private void UnloadViewModel(IViewModel viewModel)
        {
            try
            {
                viewModel.OnUnloaded();
            }
            finally
            {
                viewModelLoaded = false;
            }
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            controlLoaded = true;

            if (control.DataContext is IViewModel viewModel)
            {
                LoadViewModel(viewModel);
            }
        }

        private void Control_Unloaded(object sender, RoutedEventArgs e)
        {
            controlLoaded = false;

            if (control.DataContext is IViewModel viewModel)
            {
                UnloadViewModel(viewModel);
            }
        }

        private void Control_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (viewModelLoaded && e.OldValue is IViewModel oldViewModel)
            {
                UnloadViewModel(oldViewModel);
            }

            if (!controlLoaded)
                return;

            if (e.NewValue is IViewModel newViewModel)
            {
                LoadViewModel(newViewModel);
            }
        }
    }
}

using GataryLabs.SwfBox.ViewModels.Abstractions.Commands;
using System;

namespace GataryLabs.SwfBox.ViewModels.Commands
{
    /// <inheritdoc cref="ICommand{T}"/>
    abstract public class Command<T> : Command, ICommand<T>
    {
        /// <inheritdoc/>
        abstract public bool CanExecute(T parameter);

        /// <inheritdoc/>
        override public bool CanExecute(object parameter)
        {
            if (parameter is null)
                return CanExecute(default);

            if (parameter is not T typedParameter)
                throw new ArgumentException($"Invalid command parameter '{parameter}'.");
            
            return CanExecute(typedParameter);
        }

        /// <inheritdoc/>
        abstract public void Execute(T parameter);

        /// <inheritdoc/>
        override public void Execute(object parameter)
        {
            if (parameter is null)
            {
                Execute(default);
                return;
            }

            if (parameter is not T typedParameter)
                throw new ArgumentException($"Invalid command parameter '{parameter}'.");

            Execute(typedParameter);
        }
    }

    /// <inheritdoc cref="System.Windows.Input.ICommand"/>
    abstract public class Command : System.Windows.Input.ICommand, INotifyCanExecuteChanged
    {
        /// <inheritdoc/>
        public event EventHandler CanExecuteChanged;

        /// <inheritdoc/>
        abstract public bool CanExecute(object parameter);

        /// <inheritdoc/>
        abstract public void Execute(object parameter);

        /// <inheritdoc/>
        public void NotifyCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

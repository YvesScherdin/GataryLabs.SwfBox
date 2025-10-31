namespace GataryLabs.Mvvm.ViewModels.Abstractions.Commands
{
    /// <summary>
    /// A generic interface representing a more specific version of <see cref="System.Windows.Input.ICommand"/>.
    /// </summary>
    /// <typeparam name="T">The type used as argument for the interface methods.</typeparam>
    public interface ICommand<in T> : System.Windows.Input.ICommand, INotifyCanExecuteChanged
    {
        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Mandatory data used by the command.</param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        bool CanExecute(T parameter);

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Mandatory data used by the command.</param>
        void Execute(T parameter);
    }
}

namespace GataryLabs.SwfBox.ViewModels.Abstractions.Commands
{
    public interface INotifyCanExecuteChanged
    {
        /// <summary>
        /// Notifies that the <see cref="ICommand.CanExecute"/> property has changed.
        /// </summary>
        void NotifyCanExecuteChanged();
    }
}

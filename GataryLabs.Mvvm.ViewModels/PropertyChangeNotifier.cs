using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GataryLabs.Mvvm.ViewModels
{
    public class PropertyChangeNotifier : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        protected void SetPropertyValue<TValue>(ref TValue currentValue, TValue newValue, [CallerMemberName] string memberName = null)
        {
            if (!Equals(currentValue, newValue))
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(memberName));
                currentValue = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
            }
        }
    }
}

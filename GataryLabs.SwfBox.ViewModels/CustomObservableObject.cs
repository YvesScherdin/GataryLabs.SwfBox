using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GataryLabs.SwfBox.ViewModels
{
    internal class CustomObservableObject : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(field, newValue))
                return;

            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));

            field = newValue;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

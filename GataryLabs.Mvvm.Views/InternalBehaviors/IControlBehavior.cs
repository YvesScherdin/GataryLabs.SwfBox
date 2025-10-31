using System.Windows.Controls;

namespace GataryLabs.Mvvm.Views.InternalBehaviors
{
    public interface IControlBehavior
    {
        void Initialize(Control control);
        void Deinitialize();
    }
}

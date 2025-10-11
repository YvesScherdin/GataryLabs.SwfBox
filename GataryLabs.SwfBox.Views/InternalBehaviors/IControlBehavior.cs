using System.Windows.Controls;


namespace GataryLabs.SwfBox.Views.InternalBehaviors
{
    public interface IControlBehavior
    {
        void Initialize(Control control);
        void Deinitialize();
    }
}

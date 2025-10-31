using GataryLabs.Mvvm.ViewModels.Abstractions;

namespace GataryLabs.Mvvm.Views.Templates
{
    public class ViewModelDataTemplateSelector : InterfaceKeyDataTemplateSelector
    {
        public ViewModelDataTemplateSelector()
        {
            InterfaceType = typeof(IViewModel);
        }
    }
}

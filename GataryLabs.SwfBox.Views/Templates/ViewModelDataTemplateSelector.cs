using GataryLabs.SwfBox.ViewModels.Abstractions;

namespace GataryLabs.SwfBox.Views.Templates
{
    public class ViewModelDataTemplateSelector : InterfaceKeyDataTemplateSelector
    {
        public ViewModelDataTemplateSelector()
        {
            this.InterfaceType = typeof(IViewModel);
        }
    }
}

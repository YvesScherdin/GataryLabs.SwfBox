using GataryLabs.SwfBox.Views.Abstractions;
using System.Windows;

namespace GataryLabs.SwfBox.Views
{
    internal class LocalizationSource : ILocalizationSource
    {
        public string GetText(string id)
        {
            object result = Application.Current.TryFindResource(id);

            if (result is not string textValue)
            {
                return id;
            }

            return textValue;
        }
    }
}

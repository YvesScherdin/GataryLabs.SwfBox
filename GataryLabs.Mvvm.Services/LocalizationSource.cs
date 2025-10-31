using GataryLabs.Mvvm.Services.Abstractions;
using System.Windows;

namespace GataryLabs.Mvvm.Services
{
    public class LocalizationSource : ILocalizationSource
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

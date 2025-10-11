using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GataryLabs.SwfBox.Views.Templates
{
    /// <summary>
    /// The item itself, and not its base classes, should implement the desired interface.
    /// The interface, however, may be extended from the specified interface.
    /// </summary>
    public class InterfaceKeyDataTemplateSelector : DataTemplateSelector
    {
        public Type InterfaceType { get; set; }

        public ResourceDictionary Resources { get; set; } = null;

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (InterfaceType == null) return null;
            if (item == null) return null;
            if (!InterfaceType.IsAssignableFrom(item.GetType())) return null;

            ResourceDictionary source = Resources ?? (container as FrameworkElement)?.Resources;

            if (source == null)
            {
                Debug.WriteLine($"Could not find proper data template for key '{item}'; no resources are resolvable.");
                return null;
            }

            Type inspectedType = item.GetType();
            Type keyInterface = inspectedType.GetInterfaces().FirstOrDefault(InterfaceType.IsAssignableFrom);

            if (keyInterface == null)
            {
                Debug.WriteLine($"Could not find proper interface key for '{inspectedType}'.");
                return null;
            }

            if (!source.Contains(keyInterface))
            {
                Debug.WriteLine($"Could not find proper data template for key '{item}'.");
                return null;
            }

            object result = source[keyInterface];

            if (result is not DataTemplate dataTemplate)
            {
                Debug.WriteLine($"Could not find proper data template for key '{item}'. Found instead: '{result}'.");
                return null;
            }

            return dataTemplate;
        }
    }
}

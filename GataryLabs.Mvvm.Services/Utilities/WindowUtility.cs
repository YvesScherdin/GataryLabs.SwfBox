using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace GataryLabs.Mvvm.Services.Utilities
{
    internal static class WindowUtility
    {
        internal static Window GetFocusedWindow()
        {
            List<Window> windows = Application.Current.Windows.Cast<Window>()
                .Reverse()
                .ToList();

            foreach (Window window in windows)
            {
                if (window.IsFocused)
                    return window;
            }

            Window fallbackWindow = Application.Current.MainWindow ?? windows.LastOrDefault();
            return fallbackWindow;
        }
    }
}

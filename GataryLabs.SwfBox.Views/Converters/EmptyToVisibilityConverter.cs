using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace GataryLabs.SwfBox.Views.Converters
{
    public class EmptyToVisibilityConverter : IValueConverter
    {
        public bool CollapseOnFalse { get; set; } = true;
        public bool Negated { get; set; } = false;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool shallNegate = Negated;

            if (value == null)
                return FromBool(false, shallNegate);

            if (value is IEnumerable enumerable)
            {
                foreach(object _ in enumerable)
                {
                    return FromBool(true, shallNegate);
                }

                return FromBool(false, shallNegate);
            }

            return FromBool(true, shallNegate);
        }

        private Visibility FromBool(bool value, bool shallNegate)
        {
            if (shallNegate)
                value = !value;

            if (value)
                return CollapseOnFalse ? Visibility.Collapsed: Visibility.Hidden;

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

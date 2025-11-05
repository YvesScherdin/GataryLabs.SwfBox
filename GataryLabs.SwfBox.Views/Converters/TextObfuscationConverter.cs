using System;
using System.Globalization;
using System.Windows.Data;

namespace GataryLabs.SwfBox.Views.Converters
{
    public class TextObfuscationConverter : IValueConverter
    {
        private const bool ObfuscationNeeded = true;

        public char? ObfuscationEndChar { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (ObfuscationNeeded)
            {
                if (value is string stringValue)
                {
                    char[] newCharacters = stringValue.ToCharArray();

                    int max = stringValue.Length;

                    if (ObfuscationEndChar != null && stringValue.Contains(ObfuscationEndChar.Value))
                    {
                        max = stringValue.LastIndexOf(ObfuscationEndChar.Value);
                    }

                    for (int i=0; i<max; i++)
                    {
                        newCharacters[i] = (char)new Random(stringValue[i]).Next();
                    }

                    return new string(newCharacters);
                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

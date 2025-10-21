using System;

namespace GataryLabs.SwfBox.Infrastructure
{
    public static class ArgumentValidator
    {
        public static void ThrowIfNull(object value, string name)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
        }
        
        public static void ThrowIfGuidEmpty(Guid value, string name)
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentException(name);
            }
        }

        public static void ThrowIfNullOrEmpty(string value, string name)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(name);
            }
        }

        public static void ThrowIfNullOrWhitespace(string value, string name)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(name);
            }
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using System;

namespace GataryLabs.Mvvm.ViewModels.Utils
{
    /// <summary>
    /// A light version of Microsoft's <see cref="Lazy{T}"/> without thread safety.
    /// </summary>
    /// <typeparam name="T">The required type.</typeparam>
    public class LazyInstance<T>
    {
        private IServiceProvider serviceProvider;
        private T value;

        public LazyInstance(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public T Value
        {
            get
            {
                if (value == null)
                    value = serviceProvider.GetRequiredService<T>();

                return value;
            }
        }
    }
}

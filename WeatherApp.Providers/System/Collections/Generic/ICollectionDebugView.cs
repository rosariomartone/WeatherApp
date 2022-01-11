using Microsoft.Extensions.Configuration;

namespace System.Collections.Generic
{
    internal class ICollectionDebugView<T>
    {
        private IEnumerable<IConfigurationProvider> providers;

        public ICollectionDebugView(IEnumerable<IConfigurationProvider> providers)
        {
            this.providers = providers;
        }

        public object Items { get; internal set; }
    }
}
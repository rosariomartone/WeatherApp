
namespace System.Collections.Generic
{
    internal class IDictionaryDebugView<T1, T2>
    {
        private IDictionary<string, string> data;

        public IDictionaryDebugView(IDictionary<string, string> data)
        {
            this.data = data;
        }
    }
}
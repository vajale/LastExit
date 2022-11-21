using System.Collections.Generic;

namespace Something.Scripts.Architecture.Utilities
{
    public interface ISaveableProgress<T, TOut>
    {
        void Add(T value);
        void Get(T value, out TOut result);
        public IEnumerable<ISaveable> GetAll();
    }
}
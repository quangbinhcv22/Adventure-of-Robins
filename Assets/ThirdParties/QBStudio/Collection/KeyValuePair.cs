using System;
using System.Collections.Generic;

namespace QBStudio.Collection
{
    [Serializable]
    public class KeyValuePair<TKey, TValue>
    {
        public TKey key;
        public TValue value;
    }
}
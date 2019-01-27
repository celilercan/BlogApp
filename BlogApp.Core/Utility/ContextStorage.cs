using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Utility
{
    public abstract class ContextStorage : IContextStorage
    {
        public abstract object this[string key] { get; set; }

        public T Get<T>(string key)
        {
            return (T)(this[key] ?? default(T));
        }

        public void Set<T>(string key, T data)
        {
            this[key] = data;
        }
    }
}

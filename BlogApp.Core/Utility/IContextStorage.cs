using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Utility
{
    public interface IContextStorage
    {
        object this[string key] { get; set; }
        T Get<T>(string key);
        void Set<T>(string key, T data);
    }
}

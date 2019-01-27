using BlogApp.Core.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Data.Infrastructure
{
    public class ContextStorageStub : ContextStorage
    {
        public ContextStorageStub()
        {
            Storage = new Hashtable();
        }
        public Hashtable Storage { get; set; }
        public override object this[string key]
        {
            get { return Storage[key]; }
            set { Storage[key] = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Data.Infrastructure.DatabaseFactory
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private DataContext _dataContext;
        public DataContext Get()
        {
            return _dataContext ?? (_dataContext = new DataContext());
        }

        protected override void DisposeCore()
        {
            if (_dataContext != null) _dataContext.Dispose();
        }
    }
}

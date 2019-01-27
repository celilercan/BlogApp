using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Data.Infrastructure.DatabaseFactory
{
    public interface IDatabaseFactory : IDisposable
    {
        DataContext Get();
    }
}

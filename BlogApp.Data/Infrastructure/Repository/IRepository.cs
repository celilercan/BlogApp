using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlogApp.Data.Infrastructure.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Attach(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, Boolean>> predicate);
        T GetById(long id);
        T GetByKey(string key);
        T Get(Expression<Func<T, Boolean>> where);
        List<T> GetMany(Expression<Func<T, bool>> where);
        IQueryable<T> Query();
        void Include(params string[] paths);
        void Dettach(T entity);
        void RemovePaths();
        void Commit();
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Infrastructure.Repository
{
    public interface IRepository<T> where T : class
    {
        #region sync
        void Add(T entity);
        void Attach(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, Boolean>> predicate);
        T Get(Expression<Func<T, Boolean>> where);
        List<T> GetMany(Expression<Func<T, bool>> where);
        void Dettach(T entity);
        void Commit();
        #endregion

        #region async

        Task AddAsync(T entity);
        Task AttachAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteAsync(Expression<Func<T, Boolean>> predicate);
        Task<T> GetAsync(Expression<Func<T, Boolean>> where);
        Task<List<T>> GetManyAsync(Expression<Func<T, bool>> where);
        Task CommitAsync();
        #endregion

        IQueryable<T> Query();
        void Include(params string[] paths);
        void RemovePaths();
    }
}

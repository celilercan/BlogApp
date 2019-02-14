using BlogApp.Core.Utility;
using BlogApp.Data.Infrastructure.DatabaseFactory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDatabaseFactory _databaseFactory;
        private readonly IContextStorage _contextStorage;
        private readonly string _includeKey = typeof(T).FullName + "_Include";

        public Repository(IDatabaseFactory databaseFactory, IContextStorage contextStorage)
        {
            _databaseFactory = databaseFactory;
            _contextStorage = contextStorage;
        }

        protected DbSet<T> DbSet
        {
            get { return DataContext.Set<T>(); }
        }

        protected DataContext DataContext
        {
            get { return _databaseFactory.Get(); }
        }

        private string[] Paths
        {
            get { return _contextStorage.Get<string[]>(_includeKey); }
            set { _contextStorage.Set(_includeKey, value); }
        }

        protected IQueryable<T> ApplyInclude()
        {
            var result = DbSet.AsQueryable();

            return Paths != null ? Paths.Aggregate(result, (current, path) => current.Include(path)) : result;
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Attach(T entity)
        {
            DbSet.Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            var objects = DbSet.Where(where).AsEnumerable();

            foreach (var obj in objects)
            {
                DbSet.Remove(obj);
            }
        }

        public void Dettach(T entity)
        {
            DataContext.Entry(entity).State = EntityState.Detached;
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return ApplyInclude().Where(where).FirstOrDefault();
        }

        public List<T> GetMany(Expression<Func<T, bool>> where)
        {
            return ApplyInclude().Where(where).ToList();
        }

        public void Include(params string[] paths)
        {
            Paths = paths;
        }

        public IQueryable<T> Query()
        {
            var query = ApplyInclude();
            Paths = null;
            return query;
        }

        public void RemovePaths()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            DataContext.SaveChanges();
        }

        #region Async
        public async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
        }

        public async Task AttachAsync(T entity)
        {
            DbSet.Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(T entity)
        {
            DbSet.Remove(entity);
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            var objects = DbSet.Where(predicate).AsEnumerable();

            foreach (var obj in objects)
            {
                DbSet.Remove(obj);
            }
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> where)
        {
            return await ApplyInclude().Where(where).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetManyAsync(Expression<Func<T, bool>> where)
        {
            return await ApplyInclude().Where(where).ToListAsync();
        }

        public async Task CommitAsync()
        {
            await DataContext.SaveChangesAsync();
        }

        #endregion
    }
}

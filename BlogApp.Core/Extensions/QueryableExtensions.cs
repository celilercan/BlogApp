using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlogApp.Core.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> AppendWhereIf<T>(this IQueryable<T> source, Expression<Func<T, bool>> expression,
                                                     bool condition)
        {
            return condition ? source.Where(expression) : source;
        }

        public static IOrderedQueryable<T> OrderRandom<T>(this IQueryable<T> source)
        {
            return source.OrderBy(x => Guid.NewGuid());
        }

        public static IQueryable<TSource> Page<TSource>(this IQueryable<TSource> source, int page, int pageSize)
        {
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static IEnumerable<TSource> Page<TSource>(this IEnumerable<TSource> source, int page, int pageSize)
        {
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}

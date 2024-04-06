using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Go.ALPR.Sri.SqlServer
{
    public static class QueryableUtils
    {
        #region IOrderedQueryable

        public static IOrderedQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> source, string propertyName) => source.Order(propertyName, true, true);
        public static IOrderedQueryable<TSource> OrderBy<TSource, TKey>(this IQueryable<TSource> source, string propertyName, IComparer<TKey> comparer) => source.Order(propertyName, true, true, comparer);
        public static IOrderedQueryable<TSource> OrderByDescending<TSource>(this IQueryable<TSource> source, string propertyName) => source.Order(propertyName, true, false);
        public static IOrderedQueryable<TSource> OrderByDescending<TSource, TKey>(this IQueryable<TSource> source, string propertyName, IComparer<TKey> comparer) => source.Order(propertyName, true, false, comparer);

        public static IOrderedQueryable<TSource> ThenBy<TSource>(this IOrderedQueryable<TSource> source, string propertyName) => source.Order(propertyName, false, true);
        public static IOrderedQueryable<TSource> ThenBy<TSource, TKey>(this IQueryable<TSource> source, string propertyName, IComparer<TKey> comparer) => source.Order(propertyName, false, true, comparer);
        public static IOrderedQueryable<TSource> ThenByDescending<TSource>(this IOrderedQueryable<TSource> source, string propertyName) => source.Order(propertyName, false, false);
        public static IOrderedQueryable<TSource> ThenByDescending<TSource, TKey>(this IQueryable<TSource> source, string propertyName, IComparer<TKey> comparer) => source.Order(propertyName, false, false, comparer);

        private static IOrderedQueryable<TSource> Order<TSource>(this IQueryable<TSource> source, string propertyName, bool useOrderBy, bool ascending, object comparer = null)
        {
            IOrderedQueryable<TSource> query;

            // LAMBDA: x => x.[PropertyName]
            var parameter = Expression.Parameter(typeof(TSource), "x");
            Expression property = Expression.Property(parameter, propertyName);
            var lambda = Expression.Lambda(property, parameter);

            if (comparer == null)
            {
                // REFLECTION: source.[OrderMethod](x => x.[PropertyName])
                var orderMethod = useOrderBy ?
                    ascending ?
                        typeof(Queryable).GetMethods().First(x => x.Name == nameof(Queryable.OrderBy) && x.GetParameters().Length == 2) :
                        typeof(Queryable).GetMethods().First(x => x.Name == nameof(Queryable.OrderByDescending) && x.GetParameters().Length == 2) :
                    ascending ?
                        typeof(Queryable).GetMethods().First(x => x.Name == nameof(Queryable.ThenBy) && x.GetParameters().Length == 2) :
                        typeof(Queryable).GetMethods().First(x => x.Name == nameof(Queryable.ThenByDescending) && x.GetParameters().Length == 2);

                var orderMethodGeneric = orderMethod.MakeGenericMethod(typeof(TSource), property.Type);

                query = (IOrderedQueryable<TSource>)orderMethodGeneric.Invoke(null, new object[] { source, lambda });
            }
            else
            {
                // REFLECTION: source.[OrderMethod](x => x.[PropertyName], comparer)
                var orderMethod = useOrderBy ?
                    ascending ?
                        typeof(Queryable).GetMethods().First(x => x.Name == nameof(Queryable.OrderBy) && x.GetParameters().Length == 3) :
                        typeof(Queryable).GetMethods().First(x => x.Name == nameof(Queryable.OrderByDescending) && x.GetParameters().Length == 3) :
                    ascending ?
                        typeof(Queryable).GetMethods().First(x => x.Name == nameof(Queryable.ThenBy) && x.GetParameters().Length == 3) :
                        typeof(Queryable).GetMethods().First(x => x.Name == nameof(Queryable.ThenByDescending) && x.GetParameters().Length == 3);

                var orderMethodGeneric = orderMethod.MakeGenericMethod(typeof(TSource), property.Type);

                query = (IOrderedQueryable<TSource>)orderMethodGeneric.Invoke(null, new[] { source, lambda, comparer });
            }

            return query;
        }

        #endregion
    }
}

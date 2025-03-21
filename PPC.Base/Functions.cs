using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Collections;

namespace PPC.Base
{
    public class Functions
    {
        public Functions()
        {

        }

        #region Class Objects

        public static Func<TSource, TTarget> CreateMapper<TSource, TTarget>()
          where TTarget : new()
        {
            var sourceProperties = typeof(TSource)
                .GetProperties()
                .Where(x => x.CanRead);
            var targetProperties = typeof(TTarget)
                .GetProperties()
                .Where(x => x.CanWrite)
                .ToDictionary(x => x.Name, x => x, StringComparer.OrdinalIgnoreCase);

            var source = Expression.Parameter(typeof(TSource), "source");
            var target = Expression.Variable(typeof(TTarget));
            var allocate = Expression.New(typeof(TTarget));
            var assignTarget = Expression.Assign(target, allocate);

            var statements = new List<Expression>();
            statements.Add(assignTarget);

            foreach (var sourceProperty in sourceProperties)
            {
                PropertyInfo targetProperty;
                if (targetProperties.TryGetValue(sourceProperty.Name, out targetProperty))
                {
                    if (targetProperty.PropertyType.Name.Contains("ICollection", StringComparison.CurrentCultureIgnoreCase))
                    {
                        try
                        {
                            
                            var assignProperty = Expression.Assign(
                                Expression.Property(target, targetProperty),
                                Expression.Property(source, sourceProperty));
                            statements.Add(assignProperty);

                        }
                        catch (Exception ex)
                        {
                            //throw;
                        }
                    }
                    else
                    {
                        try
                        {
                            var t = Expression.Property(target, targetProperty);
                            var s = Expression.Property(source, sourceProperty);
                            var assignProperty = Expression.Assign(t, s);
                            statements.Add(assignProperty);
                        }
                        catch(Exception ex) { }
                    }
                }
            }

            statements.Add(target);

            var body = Expression.Block(new[] { target }, statements);

            return Expression.Lambda<Func<TSource, TTarget>>(body, source).Compile();
        }

        //public Func<TSource, TTarget> CreateMapper<TSource, TTarget>()
        // where TTarget : new()
        //{
        //    var sourceProperties = typeof(TSource)
        //        .GetProperties()
        //        .Where(x => x.CanRead);
        //    var targetProperties = typeof(TTarget)
        //        .GetProperties()
        //        .Where(x => x.CanWrite)
        //        .ToDictionary(x => x.Name, x => x, StringComparer.OrdinalIgnoreCase);

        //    var source = Expression.Parameter(typeof(TSource), "source");
        //    var target = Expression.Variable(typeof(TTarget));
        //    var allocate = Expression.New(typeof(TTarget));
        //    var assignTarget = Expression.Assign(target, allocate);

        //    var statements = new List<Expression>();
        //    statements.Add(assignTarget);

        //    foreach (var sourceProperty in sourceProperties)
        //    {
        //        PropertyInfo targetProperty;
        //        if (targetProperties.TryGetValue(sourceProperty.Name, out targetProperty))
        //        {
        //            var assignProperty = Expression.Assign(
        //                Expression.Property(target, targetProperty),
        //                Expression.Property(source, sourceProperty));
        //            statements.Add(assignProperty);
        //        }
        //    }

        //    statements.Add(target);

        //    var body = Expression.Block(new[] { target }, statements);

        //    return Expression.Lambda<Func<TSource, TTarget>>(body, source).Compile();
        //}


        #endregion


    }
}

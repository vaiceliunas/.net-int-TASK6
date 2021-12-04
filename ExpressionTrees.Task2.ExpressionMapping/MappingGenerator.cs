using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace ExpressionTrees.Task2.ExpressionMapping
{
    public class MappingGenerator
    {
        public Mapper<TSource, TDestination> Generate<TSource, TDestination>()
        {
            var sourceParam = Expression.Parameter(typeof(TSource), "source");
            var destinationParam = Expression.Parameter(typeof(TDestination), "source");

            var sourceProperties = sourceParam.Type.GetProperties().Select(t => new KeyValuePair<string,string>(t.Name, t.PropertyType.FullName));
            var destinationProperties = destinationParam.Type.GetProperties().Select(t => new KeyValuePair<string, string>(t.Name, t.PropertyType.FullName));

            var propertiesToCopy = sourceProperties.Where(x => destinationProperties.Contains(x));

            var body = Expression.MemberInit(Expression.New(typeof(TDestination)),
                sourceParam.Type.GetProperties().Where(t => propertiesToCopy.Any(j => j.Key == t.Name)).Select(p =>
                    Expression.Bind(typeof(TDestination).GetProperty(p.Name), Expression.Property(sourceParam, p))));

            var mapFunction =
                Expression.Lambda<Func<TSource, TDestination>>(body,
                    sourceParam
                );

            return new Mapper<TSource, TDestination>(mapFunction.Compile());
        }
    }
}

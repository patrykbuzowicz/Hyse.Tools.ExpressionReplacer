using System;
using System.Linq.Expressions;
using Hyse.Tools.ExpressionReplacer.Replacing;

namespace Hyse.Tools.ExpressionReplacer
{
    public class Generate<T>
    {
        public static Expression<Func<T, TResult>> Expression<TResult>(Expression<Func<T, TResult>> expression)
        {
            var replacer = new ReplacingExpressionVisitor();
            return replacer.Visit(expression) as Expression<Func<T, TResult>>;
        }
    }

    public class Apply
    {
        public static TValue This<T, TValue>(T surname, Expression<Func<T, TValue>> expression)
        {
            return default(TValue);
        }
    }
}

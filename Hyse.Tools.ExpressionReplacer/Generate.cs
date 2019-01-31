using System;
using System.Linq.Expressions;

namespace Hyse.Tools.ExpressionReplacer
{
    public class Generate<T>
    {
        public static Expression<Func<T, TResult>> Expression<TResult>(Expression<Func<T, TResult>> generator)
        {
            return generator;
        }
    }
}

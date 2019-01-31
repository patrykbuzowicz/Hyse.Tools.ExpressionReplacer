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

    public class Apply
    {
        public static TValue This<T, TValue>(T surname, Expression<Func<T, TValue>> twoLastChars)
        {
            return default(TValue);
        }
    }
}

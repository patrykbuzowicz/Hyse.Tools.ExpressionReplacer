using System;
using System.Linq.Expressions;

namespace Hyse.Tools.ExpressionReplacer.Tests.Utilities
{
    internal static class AssertExpressionExtensions
    {
        public static void ShouldBeEquivalentToExpression<T, TResult>(this Expression<Func<T, TResult>> expression,
            Expression<Func<T, TResult>> expected)
        {
            throw new NotImplementedException();
        }
    }
}

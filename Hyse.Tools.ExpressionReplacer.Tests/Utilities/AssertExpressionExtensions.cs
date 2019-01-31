using System;
using System.Linq.Expressions;
using FluentAssertions;

namespace Hyse.Tools.ExpressionReplacer.Tests.Utilities
{
    internal static class AssertExpressionExtensions
    {
        public static void ShouldBeEquivalentToExpression<T, TResult>(this Expression<Func<T, TResult>> expression,
            Expression<Func<T, TResult>> expected)
        {
            expression.ToString().Should().Be(expected.ToString());
        }
    }
}

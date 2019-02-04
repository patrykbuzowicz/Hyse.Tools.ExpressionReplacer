using System;
using System.Linq.Expressions;
using FluentAssertions;

namespace Hyse.Tools.ExpressionReplacer.Tests.Utilities
{
    internal static class AssertExpressionExtensions
    {
        public static void ShouldBeEquivalentToExpression(this Expression expression, Expression expected)
        {
            expression.ToString().Should().Be(expected.ToString());
        }
    }
}

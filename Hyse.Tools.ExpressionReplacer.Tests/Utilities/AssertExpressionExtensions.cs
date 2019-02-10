using FluentAssertions;
using System.Linq.Expressions;

namespace Hyse.Tools.ExpressionReplacer.Tests.Utilities
{
    internal static class AssertExpressionExtensions
    {
        public static void ShouldBeEquivalentToExpression(this Expression expression, Expression expected)
        {
            var comparisonResult = ExpressionComparer.Equality.ExpressionComparer.Compare(expression, expected);
            comparisonResult.Should().BeTrue();
        }
    }
}

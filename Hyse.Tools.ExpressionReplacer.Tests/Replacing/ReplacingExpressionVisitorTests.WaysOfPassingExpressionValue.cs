using System;
using System.Linq.Expressions;
using FluentAssertions;
using Hyse.Tools.ExpressionReplacer.Replacing;
using Hyse.Tools.ExpressionReplacer.Tests.Utilities;
using Xunit;

namespace Hyse.Tools.ExpressionReplacer.Tests.Replacing
{
    public partial class ReplacingExpressionVisitorTests
    {
        public class WaysOfPassingExpressionValue
        {
            private readonly ReplacingExpressionVisitor _subject;

            public WaysOfPassingExpressionValue()
            {
                _subject = new ReplacingExpressionVisitor();
            }

            [Theory]
            [ClassData(typeof(VariousWaysOfPassingExpression))]
            public void TestPositiveCases(TestCase testCase)
            {
                var expressionMethodCall = testCase.Expression.Body;
                var expectedMethodCall = testCase.Expected.Body;

                var result = _subject.Visit(expressionMethodCall);

                result.ShouldBeEquivalentToExpression(expectedMethodCall);
            }

            [Fact]
            public void Given_method_access_of_expression_Then_exception_thrown()
            {
                Expression<Func<ExampleModel, object>> expression = x => Apply.This(x.Surname, GetExpression());

                Action action = () => _subject.Visit(expression.Body);

                action.Should().Throw<ReplacingException>();
            }

            private static Expression<Func<string, string>> GetExpression() => x => x.Substring(x.Length - 2);
        }
    }
}
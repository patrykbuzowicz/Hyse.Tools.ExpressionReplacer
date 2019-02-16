using Hyse.Tools.ExpressionReplacer.Tests.Utilities;
using System;
using System.Linq.Expressions;
using Xunit;

namespace Hyse.Tools.ExpressionReplacer.Tests
{
    public class GenerateTests
    {
        [Fact]
        public void Given_expression_does_not_contain_updates_Then_it_should_return_expression_unchanged()
        {
            Expression<Func<ExampleModel, string>> expression = x => x.Name;
            var result = Generate<ExampleModel>.Expression(expression);

            result.ShouldBeEquivalentToExpression(expression);
        }

        [Fact]
        public void Given_expression_is_updated_with_simple_equality_check_Then_it_should_return_changed_expression()
        {
            Expression<Func<ExampleModel, bool>> expected = x => x.Name == x.Surname.Substring(x.Surname.Length - 2);

            var result = Generate<ExampleModel>.Expression(x => x.Name == Apply.This(x.Surname, ExampleExpressions.TwoLastChars));

            result.ShouldBeEquivalentToExpression(expected);
        }
    }
}

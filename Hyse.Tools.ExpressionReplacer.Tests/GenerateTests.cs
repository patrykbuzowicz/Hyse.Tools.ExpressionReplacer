using System;
using System.Linq.Expressions;
using Hyse.Tools.ExpressionReplacer.Tests.Utilities;
using Xunit;

namespace Hyse.Tools.ExpressionReplacer.Tests
{
    public class GenerateTests
    {
        public class ExpressionTests
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

            [Fact]
            public void Given_expression_is_updated_with_complex_expression_Then_it_should_return_changed_expression()
            {
                Expression<Func<ExampleModel, bool>> expected = x => x.Age > 30 && 
                                                                     x.Name.Substring(0, 1) == x.Surname.Substring(x.Surname.Length - 1);

                var result = Generate<ExampleModel>.Expression(x => x.Age > 30 && 
                                                                    Apply.This(x, ExampleExpressions.TwoStringFieldsAssertion));

                result.ShouldBeEquivalentToExpression(expected);
            }

            [Fact]
            public void Given_expression_is_updated_with_multiple_expression_Then_it_should_return_changed_expression()
            {
                Expression<Func<ExampleModel, bool>> expected = x => x.Name.StartsWith("someone") &&
                                                                     x.Surname.StartsWith("something") &&
                                                                     x.Age > 18;

                var result = Generate<ExampleModel>.Expression(x => Apply.This(x, ExampleExpressions.NameAssertion) &&
                                                                    Apply.This(x, ExampleExpressions.SurnameAssertion) &&
                                                                    Apply.This(x, ExampleExpressions.AgeAssertion));

                result.ShouldBeEquivalentToExpression(expected);
            }
        }
    }
}

using System;
using System.Linq.Expressions;
using FluentAssertions;
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

                result.Should().BeEquivalentTo(expression);
            }
        }
    }
}

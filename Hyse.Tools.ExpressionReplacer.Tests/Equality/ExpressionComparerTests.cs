using FluentAssertions;
using Hyse.Tools.ExpressionReplacer.Equality;
using Xunit;

namespace Hyse.Tools.ExpressionReplacer.Tests.Equality
{
    public class ExpressionComparerTests
    {
        [Theory, ClassData(typeof(ExpressionComparerTestsData))]
        public void Test(TestCase testCase)
        {
            var result = ExpressionComparer.Compare(testCase.Left, testCase.Right);

            result.Should().Be(testCase.Expected);
        }
    }
}

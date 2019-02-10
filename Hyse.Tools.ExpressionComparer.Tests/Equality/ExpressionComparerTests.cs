using FluentAssertions;
using Xunit;

namespace Hyse.Tools.ExpressionComparer.Tests.Equality
{
    public class ExpressionComparerTests
    {
        [Theory, ClassData(typeof(ExpressionComparerTestsData))]
        public void Test(TestCase testCase)
        {
            var result = ExpressionComparer.Equality.ExpressionComparer.Compare(testCase.Left, testCase.Right);

            result.Should().Be(testCase.Expected);
        }
    }
}

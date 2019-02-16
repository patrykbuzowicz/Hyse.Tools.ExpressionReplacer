using Hyse.Tools.ExpressionReplacer.Tests.Utilities;
using Xunit;

namespace Hyse.Tools.ExpressionReplacer.Tests
{
    public class GenerateTests
    {
        [Theory, ClassData(typeof(GenerateTestsData))]
        public void TestExpressionGeneration(TestCase testCase)
        {
            var result = Generate<ExampleModel>.Expression(testCase.Expression);

            result.ShouldBeEquivalentToExpression(testCase.Expected);
        }
    }
}

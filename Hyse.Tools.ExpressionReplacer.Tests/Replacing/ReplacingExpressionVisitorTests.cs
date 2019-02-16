using Hyse.Tools.ExpressionReplacer.Replacing;
using Hyse.Tools.ExpressionReplacer.Tests.Utilities;
using Xunit;

namespace Hyse.Tools.ExpressionReplacer.Tests.Replacing
{
    public partial class ReplacingExpressionVisitorTests
    {
        public class Replacing
        {
            private readonly ReplacingExpressionVisitor _subject;

            public Replacing()
            {
                _subject = new ReplacingExpressionVisitor();
            }

            [Theory]
            [ClassData(typeof(ReplacingExpressionVisitorTestsData))]
            public void Test(TestCase testCase)
            {
                var expressionMethodCall = testCase.Expression.Body;
                var expectedMethodCall = testCase.Expected.Body;

                var result = _subject.Visit(expressionMethodCall);

                result.ShouldBeEquivalentToExpression(expectedMethodCall);
            }
        }
    }
}
